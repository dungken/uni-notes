# LAB 1 - Commands Chi Tiết Windows Server 2016

## Phần 1: Cài đặt và Cấu hình Ban đầu

### 1.1 Kiểm tra thông tin hệ thống sau khi cài đặt
```cmd
# Kiểm tra thông tin hệ thống
systeminfo
systeminfo | findstr /C:"OS Name" /C:"Total Physical Memory"

# Kiểm tra version Windows
winver

# Kiểm tra thông tin máy tính
hostname
echo %COMPUTERNAME%
echo %USERDOMAIN%

# Kiểm tra thông tin hardware
wmic computersystem get model,name,manufacturer
wmic cpu get name
wmic memorychip get capacity
```

## Phần 2: Computer Management và Local User Management

### 2.1 Quản lý Users qua Command Line

#### Tạo user cục bộ:
```cmd
# Tạo user mới
net user <username> <password> /add
net user ServerWorld P@ssw0rd123 /add

# Tạo user với các thuộc tính chi tiết
net user <username> <password> /add /fullname:"<Full Name>" /comment:"<Description>"
net user ServerWorld P@ssw0rd123 /add /fullname:"Server World User" /comment:"Local admin user"

# Xem danh sách users
net user

# Xem thông tin chi tiết của user
net user <username>
net user ServerWorld
```

#### Thêm user vào group Administrators:
```cmd
# Thêm user vào group Administrators
net localgroup administrators <username> /add
net localgroup administrators ServerWorld /add

# Xem members của group Administrators
net localgroup administrators

# Xem tất cả local groups
net localgroup
```

#### Quản lý user qua PowerShell (nâng cao):
```powershell
# Tạo user với PowerShell
New-LocalUser -Name "ServerWorld" -Password (ConvertTo-SecureString "P@ssw0rd123" -AsPlainText -Force) -FullName "Server World User" -Description "Local admin user"

# Thêm vào group Administrators
Add-LocalGroupMember -Group "Administrators" -Member "ServerWorld"

# Xem tất cả local users
Get-LocalUser

# Xem members của group
Get-LocalGroupMember -Group "Administrators"

# Set password never expires
Set-LocalUser -Name "ServerWorld" -PasswordNeverExpires $true

# Disable/Enable user
Disable-LocalUser -Name "ServerWorld"
Enable-LocalUser -Name "ServerWorld"
```

### 2.2 Mở các công cụ quản lý

```cmd
# Computer Management
compmgmt.msc

# Local Users and Groups
lusrmgr.msc

# System Configuration
msconfig

# System Properties
sysdm.cpl

# Device Manager
devmgmt.msc

# Disk Management
diskmgmt.msc

# Event Viewer
eventvwr.msc

# Services
services.msc

# Task Manager
taskmgr

# Registry Editor
regedit

# Group Policy Editor (nếu có)
gpedit.msc
```

## Phần 3: Cấu hình Tên Máy Tính

### 3.1 Xem tên máy tính hiện tại:
```cmd
hostname
echo %COMPUTERNAME%

# Xem thông tin domain/workgroup
echo %USERDOMAIN%
wmic computersystem get domain,workgroup
```

### 3.2 Đổi tên máy tính:

#### Method 1: Sử dụng Netdom (khuyến nghị):
```cmd
# Đổi tên máy tính và restart
Netdom renamecomputer %ComputerName% /NewName:WS2016_<MSSV> /Force /Reboot

# Ví dụ cụ thể:
Netdom renamecomputer %ComputerName% /NewName:WS2016_635017XXX /Force /Reboot
```

#### Method 2: Sử dụng PowerShell:
```powershell
# Đổi tên và restart
Rename-Computer -NewName "WS2016_<MSSV>" -Force -Restart

# Đổi tên không restart (cần restart manual)
Rename-Computer -NewName "WS2016_<MSSV>" -Force
Restart-Computer
```

#### Method 3: Sử dụng WMIC:
```cmd
# Đổi tên máy tính
wmic computersystem where name="%computername%" call rename name="WS2016_<MSSV>"

# Restart máy
shutdown /r /t 0
```

### 3.3 Verify sau khi đổi tên:
```cmd
# Kiểm tra tên mới sau khi restart
hostname
echo %COMPUTERNAME%
```

## Phần 4: Cấu hình IP Address

### 4.1 Xem cấu hình mạng hiện tại:
```cmd
# Xem tất cả thông tin IP
ipconfig /all

# Xem chỉ IP address
ipconfig

# Xem interface mạng
netsh interface show interface

# Xem IPv4 configuration
netsh interface ipv4 show config
```

### 4.2 Cấu hình IP tĩnh:

#### Method 1: Sử dụng Netsh (khuyến nghị):
```cmd
# Xem tên interface chính xác
netsh interface show interface

# Cấu hình IP tĩnh (thay "Ethernet" bằng tên interface thực tế)
netsh interface ipv4 set address name="Ethernet" static 192.168.1.1 255.255.255.0 192.168.1.1

# Cấu hình DNS
netsh interface ipv4 set dnsserver name="Ethernet" static 192.168.1.1 primary

# Thêm DNS thứ hai (nếu cần)
netsh interface ipv4 add dnsserver name="Ethernet" address=8.8.8.8 index=2

# Xóa DNS servers và cấu hình lại
netsh interface ipv4 set dnsserver name="Ethernet" static 192.168.1.1
```

#### Method 2: Sử dụng PowerShell:
```powershell
# Xem network adapters
Get-NetAdapter

# Cấu hình IP tĩnh
New-NetIPAddress -InterfaceAlias "Ethernet" -IPAddress 192.168.1.1 -PrefixLength 24 -DefaultGateway 192.168.1.1

# Cấu hình DNS
Set-DnsClientServerAddress -InterfaceAlias "Ethernet" -ServerAddresses 192.168.1.1,8.8.8.8

# Xóa IP cũ nếu cần
Remove-NetIPAddress -InterfaceAlias "Ethernet" -Confirm:$false
```

### 4.3 Cấu hình cho bài lab cụ thể:

#### Máy WS2016 (Server chính):
```cmd
netsh interface ipv4 set address name="Ethernet" static 192.168.1.1 255.255.255.0 192.168.1.1
netsh interface ipv4 set dnsserver name="Ethernet" static 192.168.1.1
```

#### Máy Client Window 7/8/10:
```cmd
# Client A
netsh interface ipv4 set address name="Ethernet" static 192.168.1.10 255.255.255.0 192.168.1.1
netsh interface ipv4 set dnsserver name="Ethernet" static 192.168.1.1

# Client B  
netsh interface ipv4 set address name="Ethernet" static 192.168.1.11 255.255.255.0 192.168.1.1
netsh interface ipv4 set dnsserver name="Ethernet" static 192.168.1.1
```

### 4.4 Verify cấu hình mạng:
```cmd
# Kiểm tra cấu hình mới
ipconfig /all

# Test kết nối
ping 192.168.1.1
ping google.com

# Flush DNS cache
ipconfig /flushdns

# Renew IP (nếu dùng DHCP)
ipconfig /release
ipconfig /renew
```

## Phần 5: Network Commands và Troubleshooting

### 5.1 ICMP Commands (ping, tracert, pathping):

#### Ping commands:
```cmd
# Ping cơ bản
ping 192.168.1.1
ping google.com

# Ping liên tục
ping -t 192.168.1.1

# Ping với số packet cụ thể
ping -n 10 192.168.1.1

# Ping với kích thước packet lớn
ping -l 1024 192.168.1.1

# Ping với timeout cụ thể
ping -w 5000 192.168.1.1

# Ping IPv6
ping -6 ::1

# Ping và hiển thị timestamp
ping -D 192.168.1.1
```

#### Tracert commands:
```cmd
# Trace route tới đích
tracert google.com
tracert 192.168.1.1

# Trace route với timeout
tracert -w 1000 google.com

# Trace route với số hops tối đa
tracert -h 15 google.com
```

#### Pathping commands:
```cmd
# Kết hợp ping và tracert
pathping google.com
pathping 192.168.1.1

# Pathping với thời gian test dài hơn
pathping -p 1000 google.com
```

### 5.2 IP Configuration Commands:

```cmd
# Hiển thị tất cả cấu hình
ipconfig /all

# Hiển thị cấu hình cơ bản
ipconfig

# Release IP address
ipconfig /release

# Renew IP address
ipconfig /renew

# Flush DNS cache
ipconfig /flushdns

# Display DNS cache
ipconfig /displaydns

# Register DNS
ipconfig /registerdns

# Release IPv6
ipconfig /release6

# Renew IPv6
ipconfig /renew6
```

### 5.3 Advanced Network Commands:

#### Net commands:
```cmd
# Xem máy tính trong mạng
net view

# Xem shares của máy cụ thể
net view \\192.168.1.10
net view \\computername

# Xem shares local
net share

# Tạo share mới
net share ShareName=C:\SharedFolder /grant:everyone,full

# Xóa share
net share ShareName /delete

# Xem mapped drives
net use

# Map network drive
net use Z: \\server\share

# Disconnect network drive
net use Z: /delete

# Send message (Windows 7 trở xuống)
net send computername "Hello"

# Xem sessions
net session

# Xem statistics
net statistics server
net statistics workstation
```

#### Netsh commands:
```cmd
# Xem tất cả interfaces
netsh interface show interface

# Xem IP configuration
netsh interface ipv4 show config

# Xem DNS configuration
netsh interface ipv4 show dnsserver

# Reset network stack
netsh winsock reset
netsh int ip reset

# Show firewall status
netsh firewall show state
netsh advfirewall show allprofiles

# Disable Windows Firewall
netsh advfirewall set allprofiles state off

# Enable Windows Firewall
netsh advfirewall set allprofiles state on

# Export network configuration
netsh dump > C:\network_config.txt

# Import network configuration
netsh exec C:\network_config.txt
```

#### Netstat commands:
```cmd
# Hiển thị tất cả connections
netstat -an

# Hiển thị với process IDs
netstat -ano

# Hiển thị với executable names
netstat -anb

# Hiển thị routing table
netstat -rn

# Hiển thị statistics
netstat -s

# Hiển thị listening ports only
netstat -an | findstr LISTENING

# Hiển thị established connections
netstat -an | findstr ESTABLISHED

# Monitor connections real-time
netstat -an 1
```

### 5.4 Additional Network Utilities:

```cmd
# ARP table
arp -a
arp -g

# Route table
route print

# Add static route
route add 192.168.2.0 mask 255.255.255.0 192.168.1.1 metric 1

# Delete route
route delete 192.168.2.0

# NSLookup
nslookup google.com
nslookup 8.8.8.8

# Test port connectivity
telnet google.com 80
telnet 192.168.1.1 3389

# Check open files/ports
netstat -an | findstr :80
netstat -an | findstr :3389
```

## Phần 6: Remote Desktop Connection

### 6.1 Enable Remote Desktop:

#### Method 1: Registry:
```cmd
# Enable RDP
reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Terminal Server" /v fDenyTSConnections /t REG_DWORD /d 0 /f

# Enable RDP through firewall
netsh advfirewall firewall set rule group="remote desktop" new enable=Yes
```

#### Method 2: PowerShell:
```powershell
# Enable RDP
Set-ItemProperty -Path 'HKLM:\System\CurrentControlSet\Control\Terminal Server' -name "fDenyTSConnections" -Value 0

# Enable firewall rule
Enable-NetFirewallRule -DisplayGroup "Remote Desktop"

# Set RDP to allow connections from any version
Set-ItemProperty -Path 'HKLM:\System\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp' -name "UserAuthentication" -Value 0
```

### 6.2 Connect to Remote Desktop:

```cmd
# Connect to remote computer
mstsc /v:192.168.1.10
mstsc /v:computername

# Connect with specific user
mstsc /v:192.168.1.10 /user:administrator

# Connect full screen
mstsc /v:192.168.1.10 /f

# Connect with saved connection
mstsc "C:\connection.rdp"
```

### 6.3 Manage RDP sessions:

```cmd
# View current sessions
query session
qwinsta

# View users
query user
quser

# Logoff session
logoff sessionid
logoff 2

# Send message to session
msg sessionid "Your message"
msg * "Broadcast message"
```

## Phần 7: File Sharing Demo

### 7.1 Tạo shared folder:

```cmd
# Tạo thư mục
mkdir C:\Shared_<MSSV>

# Tạo share
net share Shared_<MSSV>=C:\Shared_<MSSV> /grant:everyone,full

# Verify share
net share
```

### 7.2 Set permissions:

```cmd
# Set NTFS permissions
icacls C:\Shared_<MSSV> /grant everyone:(OI)(CI)F

# View permissions
icacls C:\Shared_<MSSV>

# Remove permissions
icacls C:\Shared_<MSSV> /remove everyone
```

### 7.3 Access share từ client:

```cmd
# Connect to share
net use Z: \\192.168.1.1\Shared_<MSSV>

# Access via explorer
explorer \\192.168.1.1\Shared_<MSSV>

# Disconnect share
net use Z: /delete
```

## Phần 8: System Configuration và Services

### 8.1 Windows Update Configuration:

```cmd
# Open Group Policy Editor
gpedit.msc

# Configure via registry
reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU" /v NoAutoUpdate /t REG_DWORD /d 1 /f

# Start Windows Update service
net start wuauserv

# Stop Windows Update service
net stop wuauserv
```

### 8.2 Service Management:

```cmd
# List all services
sc query

# Query specific service
sc query spooler

# Start service
net start spooler
sc start spooler

# Stop service
net stop spooler
sc stop spooler

# Set service startup type
sc config spooler start= auto
sc config spooler start= disabled

# View service dependencies
sc qc spooler
```

## Phần 9: System Monitoring và Troubleshooting

### 9.1 Event Logs:

```cmd
# View system events
wevtutil qe System /c:10 /f:text

# View application events
wevtutil qe Application /c:10 /f:text

# Export event log
wevtutil epl System C:\system_events.evtx

# Clear event log
wevtutil cl System
```

### 9.2 Performance Monitoring:

```cmd
# Task Manager
taskmgr

# Resource Monitor
resmon

# Performance Monitor
perfmon

# System File Checker
sfc /scannow

# Check disk
chkdsk C: /f

# Memory diagnostic
mdsched
```

### 9.3 System Information:

```cmd
# Detailed system info
systeminfo

# Hardware info
wmic cpu get name
wmic memorychip get capacity
wmic diskdrive get size,model

# Process list
tasklist
wmic process list brief

# Installed programs
wmic product get name,version
```

## Phần 10: Active Directory Preparation Commands

### 10.1 Install AD DS Role:

```powershell
# Install Active Directory Domain Services
Install-WindowsFeature -Name AD-Domain-Services -IncludeManagementTools

# Check installation
Get-WindowsFeature -Name AD-Domain-Services
```

### 10.2 Promote to Domain Controller:

```powershell
# Promote server to domain controller
Install-ADDSForest -DomainName "<MSSV>.vn" -SafeModeAdministratorPassword (ConvertTo-SecureString "P@ssw0rd123" -AsPlainText -Force) -Force

# Verify domain controller
Get-ADDomainController
Get-ADDomain
```

## Troubleshooting Common Issues

### Network connectivity:
```cmd
# Test basic connectivity
ping 127.0.0.1
ping 192.168.1.1
ping google.com

# Check firewall
netsh firewall show state
netsh advfirewall show allprofiles state

# Reset network
netsh winsock reset
netsh int ip reset
ipconfig /flushdns
```

### Name resolution:
```cmd
# Test DNS
nslookup google.com
nslookup google.com 8.8.8.8

# Check DNS cache
ipconfig /displaydns
ipconfig /flushdns
```

### Remote access:
```cmd
# Check RDP status
reg query "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Terminal Server" /v fDenyTSConnections

# Check RDP port
netstat -an | findstr :3389

# Test RDP connectivity
telnet targetserver 3389
```