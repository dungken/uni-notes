# Lab 4 - Hướng dẫn chi tiết Windows Server

## Tổng quan Lab 4

**Mục tiêu:** Triển khai và quản lý các dịch vụ nâng cao trên Windows Server bao gồm DNS, File Sharing, Offline Files, Group Policy và File Monitoring.

**Kiến trúc mạng:**
- **WS2016_<MSSV>** (192.168.1.2) - Primary Domain Controller
- **ALT_WS2016_<MSSV>** (192.168.1.3) - Secondary Server  
- **ALT2_WS2016_<MSSV>** (192.168.1.4) - Tertiary Server
- **ALT3_WS2016_<MSSV>** (192.168.1.5) - Quaternary Server
- **Win7810_<MSSV>_C** (192.168.1.10) - Client 1
- **Win7810_<MSSV>_D** (192.168.1.11) - Client 2

---

## 1. Cài đặt và cấu hình DNS Server

### 1.1 Cài đặt DNS Server Role

```powershell
# Trên WS2016_<MSSV>
Install-WindowsFeature DNS -IncludeManagementTools

# Kiểm tra cài đặt
Get-WindowsFeature DNS
Get-Service DNS
```

### 1.2 Tạo DNS Zones

```powershell
# Tạo Forward Lookup Zone
Add-DnsServerPrimaryZone -Name "<MSSV>.vn" -ZoneFile "<MSSV>.vn.dns"

# Tạo Reverse Lookup Zone
Add-DnsServerPrimaryZone -NetworkID "192.168.1.0/24" -ZoneFile "1.168.192.in-addr.arpa.dns"
```

### 1.3 Tạo DNS Records

```powershell
# Tạo A Records
Add-DnsServerResourceRecordA -ZoneName "<MSSV>.vn" -Name "dc1" -IPv4Address "192.168.1.2"
Add-DnsServerResourceRecordA -ZoneName "<MSSV>.vn" -Name "web" -IPv4Address "192.168.1.3"
Add-DnsServerResourceRecordA -ZoneName "<MSSV>.vn" -Name "mail" -IPv4Address "192.168.1.4"

# Tạo CNAME Records
Add-DnsServerResourceRecordCName -ZoneName "<MSSV>.vn" -Name "www" -HostNameAlias "web.<MSSV>.vn"
Add-DnsServerResourceRecordCName -ZoneName "<MSSV>.vn" -Name "ftp" -HostNameAlias "web.<MSSV>.vn"

# Tạo MX Record
Add-DnsServerResourceRecordMX -ZoneName "<MSSV>.vn" -Name "." -MailExchange "mail.<MSSV>.vn" -Preference 10

# Tạo PTR Records (Reverse DNS)
Add-DnsServerResourceRecordPtr -ZoneName "1.168.192.in-addr.arpa" -Name "2" -PtrDomainName "dc1.<MSSV>.vn"
Add-DnsServerResourceRecordPtr -ZoneName "1.168.192.in-addr.arpa" -Name "3" -PtrDomainName "web.<MSSV>.vn"
```

### 1.4 Cấu hình DNS Forwarders

```powershell
# Cấu hình DNS Forwarders
Add-DnsServerForwarder -IPAddress "8.8.8.8", "1.1.1.1"

# Kiểm tra cấu hình
Get-DnsServerForwarder
```

### 1.5 Test DNS Resolution

```cmd
# Test DNS resolution
nslookup dc1.<MSSV>.vn
nslookup web.<MSSV>.vn
nslookup www.<MSSV>.vn
nslookup 192.168.1.2

# Test với PowerShell
Resolve-DnsName -Name "dc1.<MSSV>.vn" -Type A
Resolve-DnsName -Name "192.168.1.2" -Type PTR
```

---

## 2. Cấu hình dịch vụ Backup DNS

### 2.1 Cài đặt DNS trên Secondary Server

```powershell
# Trên ALT_WS2016_<MSSV>
Install-WindowsFeature DNS -IncludeManagementTools

# Cấu hình làm Secondary DNS
Add-DnsServerSecondaryZone -Name "<MSSV>.vn" -ZoneFile "<MSSV>.vn.dns" -MasterServers "192.168.1.2"
Add-DnsServerSecondaryZone -Name "1.168.192.in-addr.arpa" -ZoneFile "1.168.192.in-addr.arpa.dns" -MasterServers "192.168.1.2"
```

### 2.2 Cấu hình Zone Transfer

```powershell
# Trên Primary DNS Server (WS2016_<MSSV>)
# Cho phép zone transfer đến secondary server
Set-DnsServerPrimaryZone -Name "<MSSV>.vn" -SecureSecondaries TransferToZoneNameServer
Set-DnsServerZoneTransfer -Name "<MSSV>.vn" -TransferPolicy TransferToZoneNameServer

# Thêm Name Server record
Add-DnsServerResourceRecord -ZoneName "<MSSV>.vn" -Name "." -NS -NameServer "alt.<MSSV>.vn"
Add-DnsServerResourceRecordA -ZoneName "<MSSV>.vn" -Name "alt" -IPv4Address "192.168.1.3"
```

### 2.3 Test Zone Transfer

```powershell
# Force zone transfer
Start-DnsServerZoneTransfer -Name "<MSSV>.vn"

# Kiểm tra zone transfer log
Get-WinEvent -LogName "DNS Server" | Where-Object {$_.LevelDisplayName -eq "Information"}
```

---

## 3. Cấu hình và phân quyền chia sẻ dữ liệu

### 3.1 Tạo cấu trúc thư mục

```powershell
# Trên ALT_WS2016_<MSSV>
# Tạo thư mục gốc
New-Item -Path "C:\SharedData" -ItemType Directory
New-Item -Path "C:\SharedData\IT_<MSSV>" -ItemType Directory
New-Item -Path "C:\SharedData\Sale_<MSSV>" -ItemType Directory
New-Item -Path "C:\SharedData\Public" -ItemType Directory
```

### 3.2 Tạo Groups và Users

```powershell
# Tạo Groups
New-ADGroup -Name "GG_S_IT_<MSSV>" -GroupCategory Security -GroupScope Global -Path "OU=Groups,DC=<MSSV>,DC=vn"
New-ADGroup -Name "GG_S_Sale_<MSSV>" -GroupCategory Security -GroupScope Global -Path "OU=Groups,DC=<MSSV>,DC=vn"

# Tạo Users
New-ADUser -Name "<MSSV>us2" -GivenName "<MSSV>" -Surname "us2" -SamAccountName "<MSSV>us2" -UserPrincipalName "<MSSV>us2@<MSSV>.vn" -AccountPassword (ConvertTo-SecureString "123456a@" -AsPlainText -Force) -Enabled $true

New-ADUser -Name "<MSSV>us6" -GivenName "<MSSV>" -Surname "us6" -SamAccountName "<MSSV>us6" -UserPrincipalName "<MSSV>us6@<MSSV>.vn" -AccountPassword (ConvertTo-SecureString "123456a@" -AsPlainText -Force) -Enabled $true

# Thêm users vào groups
Add-ADGroupMember -Identity "GG_S_IT_<MSSV>" -Members "<MSSV>us2"
Add-ADGroupMember -Identity "GG_S_Sale_<MSSV>" -Members "<MSSV>us6"
```

### 3.3 Cấu hình File Sharing

```powershell
# Share thư mục IT
New-SmbShare -Name "IT_<MSSV>" -Path "C:\SharedData\IT_<MSSV>" -FullAccess "Domain Admins", "GG_S_IT_<MSSV>"

# Share thư mục Sale  
New-SmbShare -Name "Sale_<MSSV>" -Path "C:\SharedData\Sale_<MSSV>" -FullAccess "Domain Admins", "GG_S_Sale_<MSSV>"

# Share thư mục Public
New-SmbShare -Name "Public" -Path "C:\SharedData\Public" -FullAccess "Everyone"
```

### 3.4 Cấu hình NTFS Permissions

```powershell
# Cấu hình NTFS permissions cho IT folder
$acl = Get-Acl "C:\SharedData\IT_<MSSV>"
$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule("GG_S_IT_<MSSV>", "FullControl", "ContainerInherit,ObjectInherit", "None", "Allow")
$acl.SetAccessRule($accessRule)
Set-Acl -Path "C:\SharedData\IT_<MSSV>" -AclObject $acl

# Cấu hình NTFS permissions cho Sale folder
$acl = Get-Acl "C:\SharedData\Sale_<MSSV>"
$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule("GG_S_Sale_<MSSV>", "FullControl", "ContainerInherit,ObjectInherit", "None", "Allow")
$acl.SetAccessRule($accessRule)
Set-Acl -Path "C:\SharedData\Sale_<MSSV>" -AclObject $acl
```

### 3.5 Test File Sharing

```cmd
# Từ client machine
net use Z: \\ALT_WS2016_<MSSV>\IT_<MSSV> /user:<MSSV>\<MSSV>us2 123456a@
net use Y: \\ALT_WS2016_<MSSV>\Sale_<MSSV> /user:<MSSV>\<MSSV>us6 123456a@

# Test write permissions
echo "Test file content" > Z:\test.txt
dir Z:\
```

---

## 4. Cấu hình Offline Files

### 4.1 Enable Offline Files trên Server

```powershell
# Cấu hình offline files cho shared folders
Set-SmbShare -Name "IT_<MSSV>" -CachingMode BranchCache
Set-SmbShare -Name "Sale_<MSSV>" -CachingMode BranchCache

# Kiểm tra cấu hình
Get-SmbShare | Select-Object Name, CachingMode
```

### 4.2 Cấu hình Group Policy cho Offline Files

```powershell
# Tạo GPO mới
New-GPO -Name "Offline Files Policy"

# Link GPO đến OU
New-GPLink -Name "Offline Files Policy" -Target "OU=Computers,DC=<MSSV>,DC=vn"
```

### 4.3 Cấu hình Offline Files trên Client

```cmd
# Enable Offline Files service
sc config "CscService" start= auto
net start "CscService"

# Sync offline files
mobsync /s
```

### 4.4 Test Offline Files

```cmd
# Make files available offline
cscui.exe

# Test offline access
net use Z: /delete
dir Z:\ 
# Should still show cached files
```

---

## 5. Triển khai chính sách GPO cơ bản

### 5.1 Tạo GPO cho Desktop Configuration

```powershell
# Tạo GPO
$gpo = New-GPO -Name "Desktop Configuration Policy"

# Cấu hình Desktop Wallpaper
Set-GPRegistryValue -Name "Desktop Configuration Policy" -Key "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System" -ValueName "Wallpaper" -Type String -Value "C:\Windows\Web\Wallpaper\Windows\img0.jpg"

# Disable Control Panel
Set-GPRegistryValue -Name "Desktop Configuration Policy" -Key "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer" -ValueName "NoControlPanel" -Type DWord -Value 1

# Remove Run command
Set-GPRegistryValue -Name "Desktop Configuration Policy" -Key "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer" -ValueName "NoRun" -Type DWord -Value 1
```

### 5.2 Tạo GPO cho Security Policy

```powershell
# Tạo Security GPO
$secGPO = New-GPO -Name "Security Policy"

# Cấu hình Password Policy
Set-GPRegistryValue -Name "Security Policy" -Key "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Network" -ValueName "MinPwdLen" -Type DWord -Value 8

# Disable USB Storage
Set-GPRegistryValue -Name "Security Policy" -Key "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR" -ValueName "Start" -Type DWord -Value 4

# Disable Task Manager
Set-GPRegistryValue -Name "Security Policy" -Key "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System" -ValueName "DisableTaskMgr" -Type DWord -Value 1
```

### 5.3 Link GPO đến OUs

```powershell
# Link Desktop Policy đến Users OU
New-GPLink -Name "Desktop Configuration Policy" -Target "OU=Users,DC=<MSSV>,DC=vn"

# Link Security Policy đến Computers OU
New-GPLink -Name "Security Policy" -Target "OU=Computers,DC=<MSSV>,DC=vn"
```

### 5.4 Test Group Policy

```cmd
# Force Group Policy update on client
gpupdate /force

# Check applied policies
gpresult /r
gpresult /h gpresult.html
```

---

## 6. Giám sát tệp tin và bắt sự kiện xóa file

### 6.1 Enable File System Auditing

```powershell
# Enable Object Access auditing
auditpol /set /subcategory:"File System" /success:enable /failure:enable

# Cấu hình auditing cho specific folder
$acl = Get-Acl "C:\SharedData\IT_<MSSV>"
$auditRule = New-Object System.Security.AccessControl.FileSystemAuditRule("Everyone", "Delete,DeleteSubdirectoriesAndFiles", "ContainerInherit,ObjectInherit", "None", "Success,Failure")
$acl.SetAuditRule($auditRule)
Set-Acl -Path "C:\SharedData\IT_<MSSV>" -AclObject $acl
```

### 6.2 Tạo GPO cho File System Auditing

```powershell
# Tạo Auditing GPO
$auditGPO = New-GPO -Name "File System Auditing Policy"

# Cấu hình audit policy
Set-GPRegistryValue -Name "File System Auditing Policy" -Key "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\eventlog\Security" -ValueName "MaxSize" -Type DWord -Value 20480
```

### 6.3 Monitor File Operations với PowerShell

```powershell
# Script giám sát file deletion
$watcher = New-Object System.IO.FileSystemWatcher
$watcher.Path = "C:\SharedData\IT_<MSSV>"
$watcher.IncludeSubdirectories = $true
$watcher.EnableRaisingEvents = $true

Register-ObjectEvent -InputObject $watcher -EventName "Deleted" -Action {
    $path = $Event.SourceEventArgs.FullPath
    $changeType = $Event.SourceEventArgs.ChangeType
    $timeStamp = $Event.TimeGenerated
    
    Write-Host "File $changeType at $timeStamp: $path" -ForegroundColor Red
    
    # Log to event log
    Write-EventLog -LogName "Application" -Source "FileMonitor" -EntryType Warning -EventId 1001 -Message "File deleted: $path at $timeStamp"
}
```

### 6.4 Tạo Event Log Source

```powershell
# Tạo custom event log source
New-EventLog -LogName "Application" -Source "FileMonitor"

# Test logging
Write-EventLog -LogName "Application" -Source "FileMonitor" -EntryType Information -EventId 1000 -Message "File monitoring started"
```

### 6.5 Query Security Event Logs

```powershell
# Query file deletion events
Get-WinEvent -LogName Security | Where-Object {$_.Id -eq 4656 -and $_.Message -like "*DELETE*"}

# Query specific timeframe
$startTime = (Get-Date).AddHours(-1)
Get-WinEvent -LogName Security -FilterHashtable @{StartTime=$startTime; ID=4656,4658,4663}

# Export security events
Get-WinEvent -LogName Security | Where-Object {$_.Id -eq 4663} | Export-Csv "C:\AuditLogs\FileAccess.csv" -NoTypeInformation
```

---

## 7. Scripts tự động hóa và monitoring

### 7.1 Health Check Script

```powershell
# Lab 4 Health Check Script
function Test-Lab4Services {
    Write-Host "=== Lab 4 Services Health Check ===" -ForegroundColor Green
    
    # Check DNS Service
    $dnsService = Get-Service DNS -ErrorAction SilentlyContinue
    if ($dnsService) {
        Write-Host "DNS Service: $($dnsService.Status)" -ForegroundColor $(if($dnsService.Status -eq 'Running'){'Green'}else{'Red'})
    }
    
    # Check SMB Shares
    $shares = Get-SmbShare | Where-Object {$_.Name -like "*<MSSV>*"}
    Write-Host "SMB Shares configured: $($shares.Count)" -ForegroundColor Yellow
    
    # Check Group Policy
    $gpos = Get-GPO -All | Where-Object {$_.DisplayName -like "*Policy*"}
    Write-Host "Group Policies: $($gpos.Count)" -ForegroundColor Yellow
    
    # Check Event Log Sources
    try {
        Get-EventLog -LogName Application -Source "FileMonitor" -Newest 1 | Out-Null
        Write-Host "File Monitor Event Source: Available" -ForegroundColor Green
    } catch {
        Write-Host "File Monitor Event Source: Not Available" -ForegroundColor Red
    }
}

Test-Lab4Services
```

### 7.2 Automated Backup Script

```powershell
# Backup DNS zones and GPO
$backupPath = "C:\Lab4Backup"
New-Item -Path $backupPath -ItemType Directory -Force

# Backup DNS zones
Export-DnsServerZone -Name "<MSSV>.vn" -FileName "$backupPath\<MSSV>.vn.backup"

# Backup GPOs
Backup-GPO -All -Path "$backupPath\GPOBackup"

# Backup Event Logs
wevtutil epl Security "$backupPath\Security.evtx"
wevtutil epl Application "$backupPath\Application.evtx"

Write-Host "Backup completed to $backupPath" -ForegroundColor Green
```

---

## 8. Troubleshooting Commands

### 8.1 DNS Troubleshooting

```cmd
# Clear DNS cache
ipconfig /flushdns

# Check DNS configuration
nslookup
> set debug
> <MSSV>.vn

# Test DNS server
dig @192.168.1.2 <MSSV>.vn

# Check DNS event logs
Get-WinEvent -LogName "DNS Server"
```

### 8.2 File Sharing Troubleshooting

```powershell
# Check SMB configuration
Get-SmbServerConfiguration
Get-SmbShare
Get-SmbSession

# Test network connectivity
Test-NetConnection -ComputerName "ALT_WS2016_<MSSV>" -Port 445

# Check file permissions
Get-Acl "C:\SharedData\IT_<MSSV>" | Format-List
```

### 8.3 Group Policy Troubleshooting

```cmd
# Check GP processing
gpresult /r /scope:computer
gpresult /r /scope:user

# Generate detailed report
gpresult /h gpreport.html /f

# Check GP event logs
Get-WinEvent -LogName "Microsoft-Windows-GroupPolicy/Operational"
```

---

## Checklist hoàn thành Lab 4

- [ ] DNS Server được cài đặt và cấu hình
- [ ] DNS zones và records được tạo
- [ ] Secondary DNS được cấu hình
- [ ] File sharing được thiết lập với permissions
- [ ] Groups và users được tạo và phân quyền
- [ ] Offline Files được cấu hình
- [ ] Group Policies được triển khai
- [ ] File system auditing được enable
- [ ] Event monitoring được thiết lập
- [ ] All services được test và hoạt động

**Lưu ý:** Thay thế `<MSSV>` bằng mã số sinh viên thực tế trong tất cả các commands.