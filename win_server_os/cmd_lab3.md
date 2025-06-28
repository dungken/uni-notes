# Command chi tiết cho Lab 3 - Windows Server

## 1. Cài đặt và cấu hình quản lý DHCP Server kết hợp với AD

### Cài đặt DHCP Server Role
```powershell
# Cài đặt DHCP Server role
Install-WindowsFeature DHCP -IncludeManagementTools

# Khởi động dịch vụ DHCP
Start-Service DHCPServer

# Kiểm tra trạng thái dịch vụ
Get-Service DHCPServer
```

### Cấu hình DHCP Scope
```powershell
# Tạo DHCP Scope mới
Add-DhcpServerv4Scope -Name "Lab3-Scope" -StartRange 192.168.1.100 -EndRange 192.168.1.200 -SubnetMask 255.255.255.0 -Description "Lab 3 DHCP Scope"

# Cấu hình DHCP Options
Set-DhcpServerv4OptionValue -ScopeId 192.168.1.0 -Router 192.168.1.1
Set-DhcpServerv4OptionValue -ScopeId 192.168.1.0 -DnsServer 192.168.1.2
Set-DhcpServerv4OptionValue -ScopeId 192.168.1.0 -DnsDomain "<MSSV>.vn"

# Kích hoạt Scope
Set-DhcpServerv4Scope -ScopeId 192.168.1.0 -State Active
```

### Authorize DHCP trong AD
```powershell
# Authorize DHCP Server trong Active Directory
Add-DhcpServerInDC -DnsName "WS2016_<MSSV>.<MSSV>.vn" -IPAddress 192.168.1.2
```

## 2. Cài đặt và cấu hình DHCP Relay Agent

### Cài đặt Routing and Remote Access
```powershell
# Cài đặt RRAS role
Install-WindowsFeature RemoteAccess -IncludeManagementTools
Install-WindowsFeature RSAT-RemoteAccess-Mgmt
```

### Cấu hình DHCP Relay Agent qua GUI
1. Mở **Routing and Remote Access**
2. Right-click server name → **Configure and Enable Routing and Remote Access**
3. Chọn **Custom configuration** → **LAN routing**
4. Expand **IP Routing** → Right-click **DHCP Relay Agent** → **New Interface**
5. Chọn network interface và cấu hình DHCP server IP

### Command line cho DHCP Relay
```cmd
# Cấu hình DHCP Relay qua netsh
netsh routing ip relay add dhcpserver 192.168.1.2
netsh routing ip relay add interface "Local Area Connection"
```

## 3. Sao lưu và khôi phục DHCP Server

### Backup DHCP Database
```powershell
# Backup DHCP database
Export-DhcpServer -File "C:\DHCPBackup\DHCP-Backup.xml" -Leases

# Backup qua command line
netsh dhcp server backup "C:\DHCPBackup"
```

### Restore DHCP Database
```powershell
# Restore DHCP database
Import-DhcpServer -File "C:\DHCPBackup\DHCP-Backup.xml" -BackupPath "C:\DHCPBackup"

# Restore qua command line
netsh dhcp server restore "C:\DHCPBackup"
```

## 4. Cài đặt và cấu hình DHCP Failover

### Tạo DHCP Failover Partnership
```powershell
# Cấu hình DHCP Failover
Add-DhcpServerv4Failover -Name "DHCP-Failover" -PartnerServer "ALT_WS2016_<MSSV>" -ScopeId 192.168.1.0 -LoadBalancePercent 50 -MaxClientLeadTime 2:00:00 -StateSwitchInterval 1:00:00

# Kiểm tra Failover status
Get-DhcpServerv4Failover
```

### Cấu hình trên Partner Server
```powershell
# Trên ALT_WS2016_<MSSV> server
# Cài đặt DHCP role trước
Install-WindowsFeature DHCP -IncludeManagementTools

# Import configuration từ primary server
Import-DhcpServer -File "\\WS2016_<MSSV>\C$\DHCPBackup\DHCP-Backup.xml"
```

## 5. Commands kiểm tra và giám sát DHCP

### Kiểm tra DHCP Leases
```powershell
# Xem tất cả DHCP leases
Get-DhcpServerv4Lease -ScopeId 192.168.1.0

# Xem DHCP statistics
Get-DhcpServerv4Statistics

# Kiểm tra DHCP server authorization
Get-DhcpServerInDC
```

### Giám sát DHCP Events
```powershell
# Xem DHCP events trong Event Log
Get-WinEvent -LogName "Microsoft-Windows-DHCP-Server/Operational" | Select-Object -First 10

# Enable DHCP audit logging
Set-DhcpServerAuditLog -Enable $True -Path "C:\Windows\System32\dhcp"
```

## 6. Network Commands hữu ích cho Lab 3

### Client-side commands
```cmd
# Renew IP address từ DHCP
ipconfig /renew

# Release IP address
ipconfig /release

# Xem thông tin DHCP client
ipconfig /all

# Flush DNS cache
ipconfig /flushdns
```

### Testing network connectivity
```cmd
# Test ping đến DHCP server
ping 192.168.1.2

# Test ping đến gateway
ping 192.168.1.1

# Trace route
tracert 8.8.8.8

# Test DNS resolution
nslookup <MSSV>.vn
```

## 7. PowerShell Scripts tự động hóa

### Script kiểm tra DHCP health
```powershell
# DHCP Health Check Script
function Check-DHCPHealth {
    Write-Host "=== DHCP Server Health Check ===" -ForegroundColor Green
    
    # Check DHCP Service
    $dhcpService = Get-Service DHCPServer
    Write-Host "DHCP Service Status: $($dhcpService.Status)" -ForegroundColor Yellow
    
    # Check DHCP Scopes
    $scopes = Get-DhcpServerv4Scope
    Write-Host "Number of Scopes: $($scopes.Count)" -ForegroundColor Yellow
    
    # Check DHCP Statistics
    $stats = Get-DhcpServerv4Statistics
    Write-Host "Total Addresses: $($stats.TotalAddresses)" -ForegroundColor Yellow
    Write-Host "In Use: $($stats.AddressesInUse)" -ForegroundColor Yellow
    Write-Host "Available: $($stats.AddressesAvailable)" -ForegroundColor Yellow
}

Check-DHCPHealth
```

### Script cấu hình DHCP Options hàng loạt
```powershell
# Script cấu hình DHCP Options
$scopeId = "192.168.1.0"
$router = "192.168.1.1"
$dnsServers = @("192.168.1.2", "8.8.8.8")
$domain = "<MSSV>.vn"

# Set Router (Option 3)
Set-DhcpServerv4OptionValue -ScopeId $scopeId -OptionId 3 -Value $router

# Set DNS Servers (Option 6)
Set-DhcpServerv4OptionValue -ScopeId $scopeId -OptionId 6 -Value $dnsServers

# Set Domain Name (Option 15)
Set-DhcpServerv4OptionValue -ScopeId $scopeId -OptionId 15 -Value $domain

# Set Lease Duration (Option 51)
Set-DhcpServerv4OptionValue -ScopeId $scopeId -OptionId 51 -Value 86400

Write-Host "DHCP Options configured successfully!" -ForegroundColor Green
```

## 8. Troubleshooting Commands

### DHCP Server troubleshooting
```powershell
# Check DHCP server configuration
Get-DhcpServerSetting

# Check DHCP database
Test-DhcpServerv4Database

# Reconcile DHCP scopes
Repair-DhcpServerv4IPRecord -ScopeId 192.168.1.0

# Check DHCP conflicts
Get-DhcpServerv4Conflict -ScopeId 192.168.1.0
```

### Network troubleshooting
```cmd
# Check network adapter configuration
netsh interface ip show config

# Check routing table
route print

# Check ARP table
arp -a

# Check network statistics
netstat -s
```

## Lưu ý quan trọng:

1. **Thay thế `<MSSV>`** bằng mã số sinh viên thực tế
2. **Kiểm tra IP addressing** phù hợp với kiến trúc mạng trong lab
3. **Backup cấu hình** trước khi thực hiện thay đổi
4. **Test connectivity** sau mỗi bước cấu hình
5. **Ghi lại logs** để troubleshooting khi cần thiết