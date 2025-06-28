# LAB 2 - Commands Chi Tiết Active Directory

## Phần 1: Chuẩn bị và Kiểm tra Domain Controller

### 1.1 Kiểm tra AD DS Installation (từ LAB 1):
```powershell
# Kiểm tra AD DS role đã cài đặt
Get-WindowsFeature -Name AD-Domain-Services

# Kiểm tra domain controller status
Get-ADDomainController
Get-ADDomain
Get-ADForest

# Kiểm tra domain functional level
Get-ADDomain | Select DomainMode
Get-ADForest | Select ForestMode

# Kiểm tra FSMO roles
Get-ADDomainController -Filter * | Select Name,OperationMasterRoles
netdom query fsmo
```

### 1.2 Verify Network và DNS:
```cmd
# Kiểm tra DNS đang trỏ đúng
ipconfig /all | findstr "DNS Servers"

# Test DNS resolution
nslookup <MSSV>.vn
nslookup _ldap._tcp.<MSSV>.vn
ping <MSSV>.vn

# Kiểm tra SRV records
nslookup -type=SRV _ldap._tcp.<MSSV>.vn
```

## Phần 2: Join Máy Client vào Domain

### 2.1 Chuẩn bị máy client:

#### Cấu hình DNS trỏ về Domain Controller:
```cmd
# Xem tên interface
netsh interface show interface

# Cấu hình DNS trỏ về DC
netsh interface ipv4 set dnsserver name="Ethernet" static 192.168.1.1

# Verify DNS configuration
ipconfig /all
nslookup <MSSV>.vn
```

#### Test kết nối tới Domain Controller:
```cmd
# Ping Domain Controller
ping 192.168.1.1
ping <MSSV>.vn

# Test LDAP port
telnet 192.168.1.1 389

# Test Kerberos port
telnet 192.168.1.1 88

# Test SMB
net view \\192.168.1.1
```

### 2.2 Join domain qua Command Line:

#### Method 1: PowerShell (Recommended):
```powershell
# Join domain với credentials
$credential = Get-Credential -Message "Enter Domain Admin Credentials"
Add-Computer -DomainName "<MSSV>.vn" -Credential $credential -Restart -Force

# Hoặc join không restart ngay
Add-Computer -DomainName "<MSSV>.vn" -Credential $credential -Force
Restart-Computer -Force
```

#### Method 2: Netdom:
```cmd
# Join domain
netdom join %computername% /domain:<MSSV>.vn /userd:Administrator /passwordd:* /reboot

# Ví dụ cụ thể:
netdom join Win7810_635017123_A /domain:635017123.vn /userd:Administrator /passwordd:P@ssw0rd123 /reboot
```

### 2.3 Verify domain membership:
```cmd
# Kiểm tra domain membership
echo %USERDOMAIN%
echo %LOGONSERVER%
whoami
systeminfo | findstr Domain

# PowerShell method
Get-ComputerInfo | Select Domain,DomainRole
(Get-WmiObject -Class Win32_ComputerSystem).Domain
```

### 2.4 Troubleshooting join domain issues:
```cmd
# Clear DNS cache
ipconfig /flushdns

# Test domain trust
nltest /dsgetdc:<MSSV>.vn

# Check time sync (important for Kerberos)
w32tm /query /status
w32tm /resync

# Reset computer account
netdom resetpwd /server:192.168.1.1 /userd:Administrator /passwordd:*
```

## Phần 3: Tạo Child Domain

### 3.1 Chuẩn bị máy chủ cho child domain:

#### Cài đặt Server cho child domain:
```cmd
# Đặt tên máy chủ child domain
Netdom renamecomputer %ComputerName% /NewName:SUB_WS2016_<MSSV> /Force /Reboot

# Cấu hình IP cho child domain server
netsh interface ipv4 set address name="Ethernet" static 192.168.1.5 255.255.255.0 192.168.1.1
netsh interface ipv4 set dnsserver name="Ethernet" static 192.168.1.1
```

### 3.2 Install AD DS trên child domain server:
```powershell
# Install AD DS role
Install-WindowsFeature -Name AD-Domain-Services -IncludeManagementTools

# Verify installation
Get-WindowsFeature -Name AD-Domain-Services
```

### 3.3 Create child domain:
```powershell
# Tạo child domain
$SafeModePassword = ConvertTo-SecureString "P@ssw0rd123" -AsPlainText -Force
$Credential = Get-Credential -Message "Enter Enterprise Admin credentials (format: <MSSV>\Administrator)"

Install-ADDSDomain `
    -NewDomainName "sub" `
    -ParentDomainName "<MSSV>.vn" `
    -DomainType ChildDomain `
    -InstallDns:$true `
    -DatabasePath "C:\Windows\NTDS" `
    -LogPath "C:\Windows\NTDS" `
    -SysvolPath "C:\Windows\SYSVOL" `
    -SafeModeAdministratorPassword $SafeModePassword `
    -Credential $Credential `
    -Force
```

### 3.4 Verify child domain:
```powershell
# Kiểm tra child domain
Get-ADDomain -Identity "sub.<MSSV>.vn"
Get-ADForest | Select Domains

# Test trust relationship
nltest /domain_trusts
Get-ADTrust -Filter *

# Test DNS resolution for child domain
nslookup sub.<MSSV>.vn
nslookup _ldap._tcp.sub.<MSSV>.vn
```

## Phần 4: Tạo và Quản lý User Accounts

### 4.1 Tạo users theo mapping table:

#### Script tạo users hàng loạt:
```powershell
# Array chứa thông tin users
$Users = @(
    @{Name="<MSSV>us1"; FirstName="<MSSV>"; LastName="us1"; Password="123456a@"},
    @{Name="<MSSV>us2"; FirstName="<MSSV>"; LastName="us2"; Password="123456a@"},
    @{Name="<MSSV>us3"; FirstName="<MSSV>"; LastName="us3"; Password="123456a@"},
    @{Name="<MSSV>us4"; FirstName="<MSSV>"; LastName="us4"; Password="123456a@"},
    @{Name="<MSSV>us5"; FirstName="<MSSV>"; LastName="us5"; Password="123456a@"},
    @{Name="<MSSV>us6"; FirstName="<MSSV>"; LastName="us6"; Password="123456a@"},
    @{Name="<MSSV>us7"; FirstName="<MSSV>"; LastName="us7"; Password="123456a@"},
    @{Name="<MSSV>us8"; FirstName="<MSSV>"; LastName="us8"; Password="123456a@"}
)

# Tạo users
foreach ($User in $Users) {
    $SecurePassword = ConvertTo-SecureString $User.Password -AsPlainText -Force
    
    New-ADUser `
        -Name $User.Name `
        -GivenName $User.FirstName `
        -Surname $User.LastName `
        -SamAccountName $User.Name `
        -UserPrincipalName "$($User.Name)@<MSSV>.vn" `
        -AccountPassword $SecurePassword `
        -Enabled $true `
        -PasswordNeverExpires $true `
        -Path "CN=Users,DC=<MSSV>,DC=vn"
        
    Write-Host "Created user: $($User.Name)"
}
```

#### Tạo user đơn lẻ:
```powershell
# Tạo user cụ thể
New-ADUser `
    -Name "635017123us1" `
    -GivenName "635017123" `
    -Surname "us1" `
    -DisplayName "635017123 us1" `
    -SamAccountName "635017123us1" `
    -UserPrincipalName "635017123us1@635017123.vn" `
    -AccountPassword (ConvertTo-SecureString "123456a@" -AsPlainText -Force) `
    -Enabled $true `
    -PasswordNeverExpires $true `
    -Description "User created for LAB 2" `
    -Path "CN=Users,DC=635017123,DC=vn"
```

### 4.2 Verify và manage users:
```powershell
# Xem tất cả users
Get-ADUser -Filter * | Select Name,SamAccountName,UserPrincipalName

# Xem user cụ thể
Get-ADUser -Identity "<MSSV>us1" -Properties *

# Set additional properties
Set-ADUser -Identity "<MSSV>us1" -Department "IT" -Title "Test User" -Description "Lab user"

# Reset password
Set-ADAccountPassword -Identity "<MSSV>us1" -NewPassword (ConvertTo-SecureString "NewPassword123!" -AsPlainText -Force) -Reset

# Unlock account
Unlock-ADAccount -Identity "<MSSV>us1"

# Disable/Enable user
Disable-ADAccount -Identity "<MSSV>us1"
Enable-ADAccount -Identity "<MSSV>us1"
```

### 4.3 Bulk operations:
```powershell
# Enable tất cả users bắt đầu với MSSV
Get-ADUser -Filter "SamAccountName -like '<MSSV>*'" | Enable-ADAccount

# Set password never expires cho tất cả
Get-ADUser -Filter "SamAccountName -like '<MSSV>*'" | Set-ADUser -PasswordNeverExpires $true

# Move users to specific OU
Get-ADUser -Filter "SamAccountName -like '<MSSV>*'" | Move-ADObject -TargetPath "OU=TestUsers,DC=<MSSV>,DC=vn"
```

## Phần 5: Tạo OU (Organizational Units)

### 5.1 Tạo OU structure:
```powershell
# Tạo main OU
New-ADOrganizationalUnit -Name "Users" -Path "DC=<MSSV>,DC=vn" -Description "Main Users OU"

# Tạo sub OUs
New-ADOrganizationalUnit -Name "IT" -Path "OU=Users,DC=<MSSV>,DC=vn" -Description "IT Department"
New-ADOrganizationalUnit -Name "Sales" -Path "OU=Users,DC=<MSSV>,DC=vn" -Description "Sales Department"
New-ADOrganizationalUnit -Name "Marketing" -Path "OU=Users,DC=<MSSV>,DC=vn" -Description "Marketing Department"

# Tạo OU cho computers
New-ADOrganizationalUnit -Name "Computers" -Path "DC=<MSSV>,DC=vn" -Description "Computer Accounts"
New-ADOrganizationalUnit -Name "Servers" -Path "OU=Computers,DC=<MSSV>,DC=vn" -Description "Server Accounts"
New-ADOrganizationalUnit -Name "Workstations" -Path "OU=Computers,DC=<MSSV>,DC=vn" -Description "Workstation Accounts"
```

### 5.2 Verify OU creation:
```powershell
# List tất cả OUs
Get-ADOrganizationalUnit -Filter * | Select Name,DistinguishedName

# Xem OU cụ thể
Get-ADOrganizationalUnit -Identity "OU=IT,OU=Users,DC=<MSSV>,DC=vn"

# Xem OU với properties
Get-ADOrganizationalUnit -Filter "Name -eq 'IT'" -Properties *
```

### 5.3 Move objects to OUs:
```powershell
# Move users to specific OUs
Move-ADObject -Identity "CN=<MSSV>us1,CN=Users,DC=<MSSV>,DC=vn" -TargetPath "OU=IT,OU=Users,DC=<MSSV>,DC=vn"
Move-ADObject -Identity "CN=<MSSV>us2,CN=Users,DC=<MSSV>,DC=vn" -TargetPath "OU=IT,OU=Users,DC=<MSSV>,DC=vn"

# Move computer accounts
Move-ADObject -Identity "CN=Win7810_<MSSV>_A,CN=Computers,DC=<MSSV>,DC=vn" -TargetPath "OU=Workstations,OU=Computers,DC=<MSSV>,DC=vn"
```

## Phần 6: Tạo và Quản lý Groups

### 6.1 Tạo security groups:
```powershell
# Tạo groups cho different departments
New-ADGroup -Name "GG_S_IT_<MSSV>" -SamAccountName "GG_S_IT_<MSSV>" -GroupCategory Security -GroupScope Global -Path "OU=IT,OU=Users,DC=<MSSV>,DC=vn" -Description "IT Department Security Group"

New-ADGroup -Name "GG_S_Sales_<MSSV>" -SamAccountName "GG_S_Sales_<MSSV>" -GroupCategory Security -GroupScope Global -Path "OU=Sales,OU=Users,DC=<MSSV>,DC=vn" -Description "Sales Department Security Group"

New-ADGroup -Name "GG_S_Marketing_<MSSV>" -SamAccountName "GG_S_Marketing_<MSSV>" -GroupCategory Security -GroupScope Global -Path "OU=Marketing,OU=Users,DC=<MSSV>,DC=vn" -Description "Marketing Department Security Group"
```

### 6.2 Add users to groups:
```powershell
# Add users to IT group
Add-ADGroupMember -Identity "GG_S_IT_<MSSV>" -Members "<MSSV>us1","<MSSV>us2"

# Add users to Sales group  
Add-ADGroupMember -Identity "GG_S_Sales_<MSSV>" -Members "<MSSV>us3","<MSSV>us4"

# Add users to Marketing group
Add-ADGroupMember -Identity "GG_S_Marketing_<MSSV>" -Members "<MSSV>us5","<MSSV>us6"

# Verify group membership
Get-ADGroupMember -Identity "GG_S_IT_<MSSV>" | Select Name,SamAccountName
```

### 6.3 Group management commands:
```powershell
# Xem tất cả groups
Get-ADGroup -Filter * | Select Name,GroupScope,GroupCategory

# Xem group cụ thể
Get-ADGroup -Identity "GG_S_IT_<MSSV>" -Properties *

# Remove user from group
Remove-ADGroupMember -Identity "GG_S_IT_<MSSV>" -Members "<MSSV>us1" -Confirm:$false

# Add computer to group
Add-ADGroupMember -Identity "GG_S_IT_<MSSV>" -Members "Win7810_<MSSV>_A$"

# Nested groups (add group to group)
Add-ADGroupMember -Identity "Domain Admins" -Members "GG_S_IT_<MSSV>"
```

## Phần 7: Delegation of Control (Phân quyền OU)

### 7.1 Grant permissions using DSACLS:
```cmd
# Grant full control over OU
dsacls "OU=IT,OU=Users,DC=<MSSV>,DC=vn" /G "<MSSV>\<MSSV>us1:GA"

# Grant specific permissions
dsacls "OU=IT,OU=Users,DC=<MSSV>,DC=vn" /G "<MSSV>\GG_S_IT_<MSSV>:CCDC;user"

# Grant reset password permission
dsacls "OU=IT,OU=Users,DC=<MSSV>,DC=vn" /G "<MSSV>\<MSSV>us1:CA;Reset Password;user"

# View current permissions
dsacls "OU=IT,OU=Users,DC=<MSSV>,DC=vn"
```

### 7.2 PowerShell method for delegation:
```powershell
# Import AD module for advanced functions
Import-Module ActiveDirectory

# Get OU object
$OU = Get-ADOrganizationalUnit -Identity "OU=IT,OU=Users,DC=<MSSV>,DC=vn"

# Create ACL rule (example for password reset)
$SID = (Get-ADUser -Identity "<MSSV>us1").SID
$ACL = Get-ACL -Path "AD:\$($OU.DistinguishedName)"

# Add permission (complex example)
$AccessRule = New-Object System.DirectoryServices.ActiveDirectoryAccessRule(
    $SID,
    [System.DirectoryServices.ActiveDirectoryRights]::ExtendedRight,
    [System.Security.AccessControl.AccessControlType]::Allow,
    [System.DirectoryServices.ActiveDirectorySecurityInheritance]::All,
    [Guid]"00299570-246d-11d0-a768-00aa006e0529" # Reset Password GUID
)

$ACL.SetAccessRule($AccessRule)
Set-ACL -Path "AD:\$($OU.DistinguishedName)" -AclObject $ACL
```

### 7.3 Common delegation scenarios:
```cmd
# Delegate user creation
dsacls "OU=IT,OU=Users,DC=<MSSV>,DC=vn" /G "<MSSV>\<MSSV>us1:CC;user"

# Delegate password reset
dsacls "OU=IT,OU=Users,DC=<MSSV>,DC=vn" /G "<MSSV>\<MSSV>us1:CA;Reset Password;user"

# Delegate group membership changes
dsacls "OU=IT,OU=Users,DC=<MSSV>,DC=vn" /G "<MSSV>\<MSSV>us1:WP;member;group"

# Remove delegation
dsacls "OU=IT,OU=Users,DC=<MSSV>,DC=vn" /R "<MSSV>\<MSSV>us1"
```

## Phần 8: Testing và Verification

### 8.1 Test domain functionality:
```powershell
# Test domain controller health
dcdiag /v

# Test replication
repadmin /replsummary
repadmin /showrepl

# Test DNS
dcdiag /test:dns

# Test time sync
w32tm /query /status
w32tm /monitor
```

### 8.2 Test user authentication:
```cmd
# Test user login from client
runas /user:<MSSV>\<MSSV>us1 cmd

# Test Kerberos tickets
klist
klist purge
```

### 8.3 Test group policy application:
```cmd
# Check applied GPOs
gpresult /r
gpresult /h C:\gpreport.html

# Force GP update
gpupdate /force
```

### 8.4 Network connectivity tests:
```cmd
# Test LDAP
nltest /dsgetdc:<MSSV>.vn

# Test ports
telnet <MSSV>.vn 389  # LDAP
telnet <MSSV>.vn 636  # LDAPS
telnet <MSSV>.vn 88   # Kerberos
telnet <MSSV>.vn 445  # SMB

# Test DNS SRV records
nslookup -type=SRV _ldap._tcp.<MSSV>.vn
nslookup -type=SRV _kerberos._tcp.<MSSV>.vn
nslookup -type=SRV _gc._tcp.<MSSV>.vn
```

## Phần 9: Advanced Management Commands

### 9.1 Backup và Restore AD:
```cmd
# Backup System State (includes AD)
wbadmin start systemstatebackup -backuptarget:D: -quiet

# Restore System State
wbadmin start systemstaterecovery -version:XX/XX/XXXX-XX:XX -quiet
```

### 9.2 AD Database maintenance:
```cmd
# Check AD database integrity
ntdsutil
activate instance ntds
files
integrity
quit
quit

# Compact AD database (offline)
ntdsutil
activate instance ntds
files
compact to C:\temp
quit
quit
```

### 9.3 Forest/Domain functional level:
```powershell
# Raise domain functional level
Set-ADDomainMode -Identity <MSSV>.vn -DomainMode Windows2016Domain

# Raise forest functional level
Set-ADForestMode -Identity <MSSV>.vn -ForestMode Windows2016Forest

# Check current levels
Get-ADDomain | Select DomainMode
Get-ADForest | Select ForestMode
```

## Troubleshooting Common Issues

### DNS Issues:
```cmd
# Register DNS records
ipconfig /registerdns

# Clear DNS cache
ipconfig /flushdns

# Test specific DNS
nslookup <MSSV>.vn
nslookup _ldap._tcp.<MSSV>.vn
```

### Time Sync Issues:
```cmd
# Check time
w32tm /query /status

# Sync with DC
w32tm /config /manualpeerlist:"192.168.1.1" /syncfromflags:manual
w32tm /resync
```

### Trust Issues:
```cmd
# Test trust
nltest /domain_trusts
nltest /sc_query:<MSSV>.vn

# Reset secure channel
nltest /sc_reset:<MSSV>.vn
```

### Replication Issues:
```cmd
# Force replication
repadmin /syncall /AdeP

# Check replication status
repadmin /replsummary
repadmin /showrepl
```

## Quick Reference Commands

### Essential AD PowerShell Commands:
```powershell
# Users
Get-ADUser -Filter *
New-ADUser
Set-ADUser
Remove-ADUser
Enable-ADAccount
Disable-ADAccount

# Groups
Get-ADGroup -Filter *
New-ADGroup
Add-ADGroupMember
Remove-ADGroupMember
Get-ADGroupMember

# OUs
Get-ADOrganizationalUnit -Filter *
New-ADOrganizationalUnit
Move-ADObject

# Domain/Forest
Get-ADDomain
Get-ADForest
Get-ADDomainController
```

### Essential CMD Commands:
```cmd
# Domain info
echo %USERDOMAIN%
echo %LOGONSERVER%
whoami
nltest /dsgetdc:%userdomain%

# Testing
ping <domain>
nslookup <domain>
telnet <dc> 389
gpupdate /force
```