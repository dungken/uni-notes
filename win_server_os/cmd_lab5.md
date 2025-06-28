# Lab 5 - Hướng dẫn chi tiết Windows Server

## Tổng quan Lab 5

**Mục tiêu:** Triển khai các dịch vụ nâng cao bao gồm WDS, IIS, RODC, VPN Server và VPN Site-to-Site.

**Kiến trúc mạng:**
- **WS2016_<MSSV>** (192.168.1.2) - Primary Domain Controller
- **AWS_<MSSV>** (192.168.1.3) - ALT_WS2016_<MSSV> - WDS/IIS Server
- **AWS2_<MSSV>** (192.168.1.4) - ALT2_WS2016_<MSSV> - RODC
- **AWS3_<MSSV>** (192.168.1.5) - ALT3_WS2016_<MSSV> - VPN Server
- **Win7810_<MSSV>_C** (192.168.1.10) - Client 1
- **Win7810_<MSSV>_D** (192.168.1.11) - Client 2

---

## 1. Cài đặt và cấu hình Windows Deployment Services (WDS)

### 1.1 Cài đặt WDS Role

```powershell
# Trên AWS_<MSSV> server
Install-WindowsFeature WDS -IncludeManagementTools
Install-WindowsFeature WDS-Deployment
Install-WindowsFeature WDS-Transport
```

### 1.2 Cấu hình WDS Server

```powershell
# Initialize WDS
wdsutil /initialize-server /remInst:"C:\RemoteInstall"

# Cấu hình WDS để respond tất cả clients
wdsutil /set-server /answerclients:all

# Cấu hình PXE response delay
wdsutil /set-server /responsedelay:0

# Start WDS service
Start-Service WDSServer
```

### 1.3 Thêm Boot Image

```powershell
# Mount Windows ISO và copy boot.wim
# Giả sử Windows ISO được mount tại D:\

# Add boot image
wdsutil /add-image /imagefile:"D:\sources\boot.wim" /imagetype:boot

# Verify boot image
wdsutil /get-allimages /show:boot
```

### 1.4 Tạo Image Group và thêm Install Image

```powershell
# Tạo image group
wdsutil /add-imagegroup /imagegroup:"<MSSV>"

# Add install image
wdsutil /add-image /imagefile:"D:\sources\install.wim" /imagetype:install /imagegroup:"<MSSV>"

# Verify install images
wdsutil /get-allimages /show:install
```

### 1.5 Cấu hình DHCP Options (nếu DHCP khác server)

```powershell
# Option 66 - Boot Server Host Name
Set-DhcpServerv4OptionValue -OptionId 66 -Value "AWS_<MSSV>.<MSSV>.vn"

# Option 67 - Bootfile Name
Set-DhcpServerv4OptionValue -OptionId 67 -Value "boot\x64\pxeboot.com"
```

### 1.6 Test PXE Boot

```bash
# Trên client machine (Boot từ network)
# 1. Configure BIOS/UEFI để boot từ Network/PXE
# 2. Restart máy
# 3. Máy sẽ nhận IP từ DHCP và connect đến WDS server
# 4. Chọn boot image và install image
```

---

## 2. Triển khai dịch vụ Internet Information Services (IIS)

### 2.1 Cài đặt IIS với các features cần thiết

```powershell
# Trên AWS_<MSSV> server
# Cài đặt IIS với full features
Enable-WindowsOptionalFeature -Online -FeatureName IIS-WebServerRole, IIS-WebServer, IIS-CommonHttpFeatures, IIS-HttpErrors, IIS-HttpRedirect, IIS-ApplicationDevelopment, IIS-NetFxExtensibility45, IIS-HealthAndDiagnostics, IIS-HttpLogging, IIS-Security, IIS-RequestFiltering, IIS-Performance, IIS-WebServerManagementTools, IIS-ManagementConsole, IIS-IIS6ManagementCompatibility, IIS-Metabase

# Hoặc sử dụng Server Manager
Install-WindowsFeature Web-Server -IncludeManagementTools
Install-WindowsFeature Web-Common-Http, Web-Http-Errors, Web-Static-Content, Web-Http-Redirect, Web-Http-Logging, Web-Mgmt-Tools
```

### 2.2 Cấu hình Single Website

```powershell
# Tạo thư mục website
New-Item -Path "C:\inetpub\Website_<MSSV>" -ItemType Directory

# Tạo file index.html
$htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <title>Website <MSSV></title>
</head>
<body>
    <h1>Welcome to <MSSV> Website</h1>
    <p>This is a test website running on IIS</p>
    <p>Server: AWS_<MSSV></p>
</body>
</html>
"@

Set-Content -Path "C:\inetpub\Website_<MSSV>\index.html" -Value $htmlContent

# Tạo website trong IIS
Import-Module WebAdministration
New-Website -Name "Website_<MSSV>" -Port 80 -PhysicalPath "C:\inetpub\Website_<MSSV>"

# Remove Default Web Site
Remove-Website -Name "Default Web Site"
```

### 2.3 Cấu hình Multi Website với DNS

```powershell
# Tạo thêm các thư mục website
New-Item -Path "C:\inetpub\<Ho_ten_SV>" -ItemType Directory
New-Item -Path "C:\inetpub\<Ten_SV>" -ItemType Directory

# Tạo nội dung cho website 2
$htmlContent2 = @"
<!DOCTYPE html>
<html>
<head>
    <title><Ho_ten_SV> Website</title>
</head>
<body>
    <h1>Welcome to <Ho_ten_SV> Website</h1>
    <p>This is the second website</p>
</body>
</html>
"@

Set-Content -Path "C:\inetpub\<Ho_ten_SV>\index.html" -Value $htmlContent2

# Tạo nội dung cho website 3
$htmlContent3 = @"
<!DOCTYPE html>
<html>
<head>
    <title><Ten_SV> Website</title>
</head>
<body>
    <h1>Welcome to <Ten_SV> Website</h1>
    <p>This is the third website</p>
</body>
</html>
"@

Set-Content -Path "C:\inetpub\<Ten_SV>\index.html" -Value $htmlContent3

# Tạo websites với host headers
New-Website -Name "<Ho_ten_SV>" -Port 80 -PhysicalPath "C:\inetpub\<Ho_ten_SV>" -HostHeader "<Ho_ten_SV>.vn"
New-Website -Name "<Ten_SV>" -Port 80 -PhysicalPath "C:\inetpub\<Ten_SV>" -HostHeader "<Ten_SV>.vn"
```

### 2.4 Cấu hình DNS cho Multi Website

```powershell
# Trên DNS Server (WS2016_<MSSV>)
# Thêm A records cho các website
Add-DnsServerResourceRecordA -ZoneName "<MSSV>.vn" -Name "www" -IPv4Address "192.168.1.3"
Add-DnsServerResourceRecordA -ZoneName "<Ho_ten_SV>.vn" -Name "www" -IPv4Address "192.168.1.3"
Add-DnsServerResourceRecordA -ZoneName "<Ten_SV>.vn" -Name "www" -IPv4Address "192.168.1.3"

# Tạo zones mới nếu cần
Add-DnsServerPrimaryZone -Name "<Ho_ten_SV>.vn" -ZoneFile "<Ho_ten_SV>.vn.dns"
Add-DnsServerPrimaryZone -Name "<Ten_SV>.vn" -ZoneFile "<Ten_SV>.vn.dns"
```

### 2.5 Test Websites

```powershell
# Test từ server
Invoke-WebRequest -Uri "http://www.<MSSV>.vn"
Invoke-WebRequest -Uri "http://www.<Ho_ten_SV>.vn"
Invoke-WebRequest -Uri "http://www.<Ten_SV>.vn"

# Test từ client
# Thêm vào hosts file nếu DNS chưa hoạt động
# echo "192.168.1.3 www.<MSSV>.vn" >> C:\Windows\System32\drivers\etc\hosts
```

---

## 3. Cài đặt và cấu hình RODC (Read Only Domain Controller)

### 3.1 Chuẩn bị Server cho RODC

```powershell
# Trên AWS2_<MSSV> server
# Cài đặt AD DS role
Install-WindowsFeature AD-Domain-Services -IncludeManagementTools

# Cấu hình DNS client
Set-DnsClientServerAddress -InterfaceAlias "Ethernet" -ServerAddresses "192.168.1.2"
```

### 3.2 Tạo RODC Account trên Primary DC

```powershell
# Trên WS2016_<MSSV> (Primary DC)
# Tạo RODC account
Add-ADDSReadOnlyDomainControllerAccount -DomainControllerAccountName "AWS2_<MSSV>" -DomainName "<MSSV>.vn" -SiteName "Default-First-Site-Name"

# Cấu hình Password Replication Policy
Add-ADDSReadOnlyDomainControllerAccount -AllowPasswordReplicationAccountName "Domain Users", "Domain Computers"
```

### 3.3 Promote Server thành RODC

```powershell
# Trên AWS2_<MSSV> server
Import-Module ADDSDeployment

# Promote to RODC
Install-ADDSDomainController `
    -DomainName "<MSSV>.vn" `
    -Credential (Get-Credential "<MSSV>\Administrator") `
    -InstallDns:$true `
    -ReadOnlyReplica:$true `
    -SiteName "Default-First-Site-Name" `
    -Force:$true
```

### 3.4 Verify RODC Installation

```powershell
# Check RODC status
Get-ADDomainController -Filter {IsReadOnly -eq $true}

# Check replication
repadmin /showrepl

# Test RODC functionality
Get-ADUser -Filter * -Server "AWS2_<MSSV>"
```

---

## 4. Triển khai cấu hình dịch vụ VPN Server (Client to Site)

### 4.1 Cài đặt Remote Access Role

```powershell
# Trên AWS3_<MSSV> server
Install-WindowsFeature RemoteAccess -IncludeManagementTools
Install-WindowsFeature DirectAccess-VPN -IncludeManagementTools
Install-WindowsFeature Routing -IncludeManagementTools
```

### 4.2 Cấu hình VPN Server

```powershell
# Configure RRAS cho VPN
$VpnServerConfig = @{
    TunnelType = "Pptp", "L2tp", "Sstp"
    IdleDisconnectSeconds = 0
    SAEncryptionType = "RequireEncryption"
}

# Install and configure VPN
Install-RemoteAccess -VpnType VpnS2S

# Configure VPN properties
Set-RemoteAccessConfiguration -DeploymentType VpnS2S
```

### 4.3 Cấu hình User Permissions cho VPN

```powershell
# Tạo VPN Users group
New-ADGroup -Name "VPN Users" -GroupCategory Security -GroupScope Global -Path "OU=Groups,DC=<MSSV>,DC=vn"

# Add users to VPN group
Add-ADGroupMember -Identity "VPN Users" -Members "<MSSV>us1", "<MSSV>us2"

# Set dial-in permissions
Set-ADUser -Identity "<MSSV>us1" -Replace @{msNPAllowDialin=$true}
Set-ADUser -Identity "<MSSV>us2" -Replace @{msNPAllowDialin=$true}
```

### 4.4 Cấu hình IP Pool cho VPN Clients

```powershell
# Configure static IP pool for VPN clients
Set-RemoteAccessIpFilter -AddressRange "192.168.100.1-192.168.100.50"

# Configure DNS and WINS for VPN clients
Set-RemoteAccessConfiguration -ClientDnsServer "192.168.1.2" -ClientWinsServer "192.168.1.2"
```

### 4.5 Tạo Shared Folder cho VPN Test

```powershell
# Tạo thư mục Data_<MSSV>
New-Item -Path "C:\Data_<MSSV>" -ItemType Directory

# Share folder
New-SmbShare -Name "Data_<MSSV>" -Path "C:\Data_<MSSV>" -FullAccess "VPN Users", "Domain Admins"

# Create test files
"VPN Test File" | Out-File "C:\Data_<MSSV>\vpntest.txt"
```

### 4.6 Test VPN Connection từ Client

```cmd
# Trên client machine
# Tạo VPN connection
rasphone -d "VPN to <MSSV>"

# Hoặc sử dụng PowerShell
Add-VpnConnection -Name "VPN to <MSSV>" -ServerAddress "192.168.1.5" -TunnelType Pptp

# Connect VPN
rasdial "VPN to <MSSV>" <MSSV>us1 123456a@

# Test access to shared folder
net use Z: \\192.168.1.5\Data_<MSSV>
dir Z:\
```

---

## 5. Triển khai VPN Site-to-Site

### 5.1 Cấu hình Network Infrastructure

```powershell
# Site 1 (HANOI): 192.168.1.0/24
# Site 2 (HCM): 172.16.1.0/24

# Trên Site 1 VPN Server (AWS3_<MSSV>)
# Configure routing for site-to-site
route add 172.16.1.0 mask 255.255.255.0 192.168.1.5

# Enable IP forwarding
Set-ItemProperty -Path "HKLM:\SYSTEM\CurrentControlSet\Services\Tcpip\Parameters" -Name "IPEnableRouter" -Value 1
```

### 5.2 Cấu hình Site-to-Site VPN Interface

```powershell
# Create site-to-site VPN interface
netsh routing ip add interface name="Site-to-Site VPN" type=full

# Configure VPN demand dial interface
New-VpnS2SInterface -Name "HCM-Site" -Destination "172.16.1.1" -Protocol IKEv2 -SharedSecret "VPNSecret123!"

# Configure routing for remote site
route add 172.16.1.0 mask 255.255.255.0 0.0.0.0 metric 1 if "Site-to-Site VPN"
```

### 5.3 Cấu hình Security cho Site-to-Site VPN

```powershell
# Configure IPSec policies
netsh ipsec static add policy name="Site-to-Site Policy"
netsh ipsec static add filteraction name="Require Auth" action=require_auth

# Configure authentication
Set-VpnS2SInterface -Name "HCM-Site" -AuthenticationMethod PSKOnly -SharedSecret "VPNSecret123!"
```

### 5.4 Test Site-to-Site Connectivity

```cmd
# Test routing
route print

# Test connectivity to remote site
ping 172.16.1.10

# Test file sharing across sites
net use Y: \\172.16.1.5\SharedFolder
```

---

## 6. Cài đặt và cấu hình VPN (Client to Site) – SSTP

### 6.1 Cài đặt SSL Certificate cho SSTP

```powershell
# Create self-signed certificate for SSTP
$cert = New-SelfSignedCertificate -DnsName "vpn.<MSSV>.vn" -CertStoreLocation "cert:\LocalMachine\My" -KeyUsage DigitalSignature, KeyEncipherment

# Bind certificate to SSTP
netsh http add sslcert ipport=0.0.0.0:443 certhash=$($cert.Thumbprint) appid="{00000000-0000-0000-0000-000000000000}"
```

### 6.2 Cấu hình SSTP VPN

```powershell
# Enable SSTP on VPN server
Set-RemoteAccessSslCertificate -Thumbprint $cert.Thumbprint

# Configure SSTP settings
Set-RemoteAccessConfiguration -SslCertificate $cert

# Enable SSTP tunnel type
Set-VpnServerConfiguration -TunnelType Sstp
```

### 6.3 Cấu hình Firewall cho SSTP

```powershell
# Allow HTTPS traffic for SSTP
New-NetFirewallRule -DisplayName "SSTP VPN" -Direction Inbound -Port 443 -Protocol TCP -Action Allow

# Allow VPN traffic
New-NetFirewallRule -DisplayName "VPN Traffic" -Direction Inbound -Protocol 47 -Action Allow
```

### 6.4 Test SSTP VPN Connection

```powershell
# Trên client
# Create SSTP VPN connection
Add-VpnConnection -Name "SSTP VPN to <MSSV>" -ServerAddress "vpn.<MSSV>.vn" -TunnelType Sstp -EncryptionLevel Required

# Connect using SSTP
rasdial "SSTP VPN to <MSSV>" <MSSV>us1 123456a@

# Verify connection
Get-VpnConnection -Name "SSTP VPN to <MSSV>"
```

---

## 7. Monitoring và Troubleshooting Scripts

### 7.1 WDS Health Check

```powershell
function Test-WDSHealth {
    Write-Host "=== WDS Health Check ===" -ForegroundColor Green
    
    # Check WDS Service
    $wdsService = Get-Service WDSServer -ErrorAction SilentlyContinue
    Write-Host "WDS Service: $($wdsService.Status)" -ForegroundColor $(if($wdsService.Status -eq 'Running'){'Green'}else{'Red'})
    
    # Check Boot Images
    $bootImages = wdsutil /get-allimages /show:boot
    Write-Host "Boot Images Available: $(($bootImages | Where-Object {$_ -like '*Image*'}).Count)" -ForegroundColor Yellow
    
    # Check Install Images
    $installImages = wdsutil /get-allimages /show:install
    Write-Host "Install Images Available: $(($installImages | Where-Object {$_ -like '*Image*'}).Count)" -ForegroundColor Yellow
}

Test-WDSHealth
```

### 7.2 IIS Health Check

```powershell
function Test-IISHealth {
    Write-Host "=== IIS Health Check ===" -ForegroundColor Green
    
    # Check IIS Service
    $iisService = Get-Service W3SVC -ErrorAction SilentlyContinue
    Write-Host "IIS Service: $($iisService.Status)" -ForegroundColor $(if($iisService.Status -eq 'Running'){'Green'}else{'Red'})
    
    # Check Websites
    $websites = Get-Website
    Write-Host "Websites configured: $($websites.Count)" -ForegroundColor Yellow
    
    foreach ($site in $websites) {
        Write-Host "  - $($site.Name): $($site.State)" -ForegroundColor Cyan
    }
}

Test-IISHealth
```

### 7.3 VPN Health Check

```powershell
function Test-VPNHealth {
    Write-Host "=== VPN Health Check ===" -ForegroundColor Green
    
    # Check RemoteAccess Service
    $raService = Get-Service RemoteAccess -ErrorAction SilentlyContinue
    Write-Host "RemoteAccess Service: $($raService.Status)" -ForegroundColor $(if($raService.Status -eq 'Running'){'Green'}else{'Red'})
    
    # Check VPN connections
    $vpnSessions = Get-RemoteAccessConnectionStatistics
    Write-Host "Active VPN Sessions: $($vpnSessions.Count)" -ForegroundColor Yellow
    
    # Check VPN configuration
    $vpnConfig = Get-RemoteAccessConfiguration
    Write-Host "VPN Enabled: $($vpnConfig.IsVpnEnabled)" -ForegroundColor Yellow
}

Test-VPNHealth
```

### 7.4 Complete Lab 5 Health Check

```powershell
function Test-Lab5Complete {
    Write-Host "========================================" -ForegroundColor Magenta
    Write-Host "         LAB 5 COMPLETE HEALTH CHECK    " -ForegroundColor Magenta
    Write-Host "========================================" -ForegroundColor Magenta
    
    Test-WDSHealth
    Write-Host ""
    Test-IISHealth
    Write-Host ""
    Test-VPNHealth
    Write-Host ""
    
    # Check RODC
    $rodc = Get-ADDomainController -Filter {IsReadOnly -eq $true} -ErrorAction SilentlyContinue
    if ($rodc) {
        Write-Host "RODC Status: Available ($($rodc.Name))" -ForegroundColor Green
    } else {
        Write-Host "RODC Status: Not Found" -ForegroundColor Red
    }
    
    Write-Host "========================================" -ForegroundColor Magenta
    Write-Host "         HEALTH CHECK COMPLETED         " -ForegroundColor Magenta
    Write-Host "========================================" -ForegroundColor Magenta
}

Test-Lab5Complete
```

---

## 8. Troubleshooting Commands

### 8.1 WDS Troubleshooting

```cmd
# Check WDS configuration
wdsutil /get-server /show:config

# Check WDS event logs
Get-WinEvent -LogName "Microsoft-Windows-Deployment-Services-Diagnostics/Operational"

# Test PXE boot
# Boot client from network and check DHCP/PXE process
```

### 8.2 IIS Troubleshooting

```powershell
# Check IIS configuration
Get-IISServerManager
Get-Website | Format-Table Name, State, PhysicalPath, Bindings

# Check IIS logs
Get-Content "C:\inetpub\logs\LogFiles\W3SVC1\*.log" | Select-Object -Last 10

# Test website connectivity
Test-NetConnection -ComputerName localhost -Port 80
```

### 8.3 VPN Troubleshooting

```cmd
# Check VPN server status
netsh ras show registeredserver

# Check VPN client connections
netsh ras show client

# Check routing table
route print

# Check VPN event logs
Get-WinEvent -LogName "Microsoft-Windows-RemoteAccess/Operational"
```

---

## Checklist hoàn thành Lab 5

- [ ] WDS Server được cài đặt và cấu hình
- [ ] Boot và Install images được thêm vào WDS
- [ ] PXE boot hoạt động từ client
- [ ] IIS được cài đặt với multiple websites
- [ ] DNS được cấu hình cho host headers
- [ ] RODC được triển khai thành công
- [ ] VPN Server (Client-to-Site) hoạt động
- [ ] Site-to-Site VPN được cấu hình
- [ ] SSTP VPN được thiết lập
- [ ] Tất cả services được test và hoạt động

**Lưu ý quan trọng:**
1. Thay thế `<MSSV>`, `<Ho_ten_SV>`, `<Ten_SV>` bằng thông tin thực tế
2. Đảm bảo firewall rules cho các services
3. Test từng component trước khi chuyển sang component tiếp theo
4. Backup cấu hình quan trọng
5. Monitor event logs để troubleshoot issues