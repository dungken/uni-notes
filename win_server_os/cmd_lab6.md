# Lab 6 - Hướng dẫn chi tiết Windows Server

## Tổng quan Lab 6

**Mục tiêu:** Triển khai các dịch vụ file server nâng cao bao gồm FSRM, DFS, Load Balancing, Failover Clustering và Windows Server Backup.

**Kiến trúc mạng:**
- **WS2016_<MSSV>** (192.168.1.2) - Primary Domain Controller
- **ALT_WS2016_<MSSV>** (192.168.1.3) - File Server 1
- **ALT2_WS2016_<MSSV>** (192.168.1.4) - File Server 2  
- **ALT3_WS2016_<MSSV>** (192.168.1.5) - File Server 3
- **Win7810_<MSSV>_C** (192.168.1.10) - Client 1
- **Win7810_<MSSV>_D** (192.168.1.11) - Client 2

---

## 1. Cấu hình Quota, File Screening và tạo thống kê lưu trữ

### 1.1 Cài đặt File Server Resource Manager (FSRM)

```powershell
# Trên ALT_WS2016_<MSSV>
Install-WindowsFeature FS-Resource-Manager -IncludeManagementTools
Install-WindowsFeature RSAT-FSRM-Mgmt

# Khởi động dịch vụ FSRM
Start-Service SrmSvc
Set-Service SrmSvc -StartupType Automatic
```

### 1.2 Tạo cấu trúc thư mục và share

```powershell
# Tạo thư mục gốc
New-Item -Path "C:\FileServer" -ItemType Directory
New-Item -Path "C:\FileServer\Users" -ItemType Directory
New-Item -Path "C:\FileServer\Departments" -ItemType Directory
New-Item -Path "C:\FileServer\Projects" -ItemType Directory

# Tạo sub-folders
New-Item -Path "C:\FileServer\Users\<MSSV>us1" -ItemType Directory
New-Item -Path "C:\FileServer\Users\<MSSV>us2" -ItemType Directory
New-Item -Path "C:\FileServer\Departments\IT" -ItemType Directory
New-Item -Path "C:\FileServer\Departments\Sales" -ItemType Directory

# Share các thư mục
New-SmbShare -Name "Users" -Path "C:\FileServer\Users" -FullAccess "Domain Admins" -ChangeAccess "Domain Users"
New-SmbShare -Name "Departments" -Path "C:\FileServer\Departments" -FullAccess "Domain Admins" -ChangeAccess "Domain Users"
New-SmbShare -Name "Projects" -Path "C:\FileServer\Projects" -FullAccess "Domain Admins" -ChangeAccess "Domain Users"
```

### 1.3 Cấu hình Quota Management

```powershell
# Tạo Quota Template
New-FsrmQuotaTemplate -Name "User Quota 1GB" -Size 1GB -SoftLimit:$false -Threshold 85,95 -ThresholdAction Email,Report

# Áp dụng quota cho user folders
New-FsrmQuota -Path "C:\FileServer\Users\<MSSV>us1" -Template "User Quota 1GB"
New-FsrmQuota -Path "C:\FileServer\Users\<MSSV>us2" -Template "User Quota 1GB"

# Tạo Department quota (5GB)
New-FsrmQuotaTemplate -Name "Department Quota 5GB" -Size 5GB -SoftLimit:$false -Threshold 75,90 -ThresholdAction Email,Report
New-FsrmQuota -Path "C:\FileServer\Departments\IT" -Template "Department Quota 5GB"
New-FsrmQuota -Path "C:\FileServer\Departments\Sales" -Template "Department Quota 5GB"

# Kiểm tra quota
Get-FsrmQuota | Format-Table Path, Size, Usage, Status
```

### 1.4 Cấu hình File Screening

```powershell
# Tạo File Group cho các file types bị cấm
New-FsrmFileGroup -Name "Executable Files" -IncludePattern "*.exe", "*.com", "*.cmd", "*.bat", "*.scr"
New-FsrmFileGroup -Name "Audio Video Files" -IncludePattern "*.mp3", "*.mp4", "*.avi", "*.mkv", "*.wmv"

# Tạo File Screen Template
New-FsrmFileScreenTemplate -Name "Block Executables" -IncludeGroup "Executable Files" -Active:$true -Notification Email

# Áp dụng file screening
New-FsrmFileScreen -Path "C:\FileServer\Users" -Template "Block Executables"
New-FsrmFileScreen -Path "C:\FileServer\Departments" -Template "Block Executables"

# Kiểm tra file screen
Get-FsrmFileScreen | Format-Table Path, Template, Active
```

### 1.5 Cấu hình Storage Reports

```powershell
# Tạo Storage Report
New-FsrmStorageReport -Name "Monthly Usage Report" -ReportType DuplicateFiles,FilesByType,LargeFiles,QuotaUsage -Path "C:\FileServer" -Schedule Weekly

# Tạo scheduled report
$action = New-ScheduledTaskAction -Execute "C:\Windows\System32\storrept.exe" -Argument "/task:`"Monthly Usage Report`""
$trigger = New-ScheduledTaskTrigger -Weekly -DaysOfWeek Monday -At "2:00AM"
Register-ScheduledTask -TaskName "FSRM Storage Report" -Action $action -Trigger $trigger

# Generate report ngay lập tức
Start-FsrmStorageReport -Name "Monthly Usage Report" -RunNow
```

### 1.6 Test Quota và File Screening

```powershell
# Test quota - tạo file lớn
$bigFile = "C:\FileServer\Users\<MSSV>us1\bigfile.txt"
$stream = [System.IO.File]::Create($bigFile)
$stream.SetLength(900MB)  # Gần đạt quota 1GB
$stream.Close()

# Test file screening - thử copy file .exe
Copy-Item "C:\Windows\System32\notepad.exe" "C:\FileServer\Users\<MSSV>us1\test.exe"
# Sẽ bị block bởi file screen

# Check quota usage
Get-FsrmQuota -Path "C:\FileServer\Users\<MSSV>us1" | Format-List Path, Size, Usage, Percent*
```

---

## 2. Triển khai cài đặt và cấu hình dịch vụ DFS (Distributed File System)

### 2.1 Cài đặt DFS Role

```powershell
# Trên WS2016_<MSSV> (Domain Controller)
Install-WindowsFeature FS-DFS-Namespace -IncludeManagementTools
Install-WindowsFeature FS-DFS-Replication -IncludeManagementTools

# Trên ALT_WS2016_<MSSV>
Install-WindowsFeature FS-DFS-Namespace -IncludeManagementTools
Install-WindowsFeature FS-DFS-Replication -IncludeManagementTools
```

### 2.2 Tạo DFS Namespace

```powershell
# Trên WS2016_<MSSV>
# Tạo Domain-based DFS Namespace
New-DfsnRoot -TargetPath "\\WS2016_<MSSV>\DFSRoot" -Type DomainV2 -Path "\\<MSSV>.vn\FileShare"

# Tạo thư mục DFS Root
New-Item -Path "C:\DFSRoot" -ItemType Directory
New-SmbShare -Name "DFSRoot" -Path "C:\DFSRoot" -FullAccess "Everyone"

# Kiểm tra DFS Namespace
Get-DfsnRoot | Format-Table Path, Type, State
```

### 2.3 Tạo DFS Folders và Links

```powershell
# Tạo DFS Folders
New-DfsnFolder -Path "\\<MSSV>.vn\FileShare\CompanyData" -TargetPath "\\ALT_WS2016_<MSSV>\Departments"
New-DfsnFolder -Path "\\<MSSV>.vn\FileShare\UserProfiles" -TargetPath "\\ALT_WS2016_<MSSV>\Users"
New-DfsnFolder -Path "\\<MSSV>.vn\FileShare\ProjectFiles" -TargetPath "\\ALT_WS2016_<MSSV>\Projects"

# Thêm multiple targets cho fault tolerance
New-DfsnFolderTarget -Path "\\<MSSV>.vn\FileShare\CompanyData" -TargetPath "\\ALT2_WS2016_<MSSV>\Departments"

# Kiểm tra DFS configuration
Get-DfsnFolder | Format-Table Path, State
Get-DfsnFolderTarget | Format-Table Path, TargetPath, State
```

### 2.4 Test DFS Access

```cmd
# Từ client machine
net use X: \\<MSSV>.vn\FileShare\CompanyData
dir X:\

# Test failover
# Stop sharing service trên ALT_WS2016_<MSSV>
# Client sẽ tự động chuyển sang ALT2_WS2016_<MSSV>
```

---

## 3. Đồng bộ dữ liệu trên 2 Server sử dụng DFS Replication

### 3.1 Chuẩn bị File Servers cho Replication

```powershell
# Trên ALT2_WS2016_<MSSV>
# Tạo folder structure tương tự ALT_WS2016_<MSSV>
New-Item -Path "C:\FileServer" -ItemType Directory
New-Item -Path "C:\FileServer\Users" -ItemType Directory
New-Item -Path "C:\FileServer\Departments" -ItemType Directory
New-Item -Path "C:\FileServer\Projects" -ItemType Directory

# Share folders
New-SmbShare -Name "Users" -Path "C:\FileServer\Users" -FullAccess "Domain Admins" -ChangeAccess "Domain Users"
New-SmbShare -Name "Departments" -Path "C:\FileServer\Departments" -FullAccess "Domain Admins" -ChangeAccess "Domain Users"
New-SmbShare -Name "Projects" -Path "C:\FileServer\Projects" -FullAccess "Domain Admins" -ChangeAccess "Domain Users"
```

### 3.2 Tạo DFS Replication Group

```powershell
# Trên WS2016_<MSSV>
# Tạo Replication Group
New-DfsReplicationGroup -GroupName "FileServer-RG" -DomainName "<MSSV>.vn"

# Thêm members vào replication group
Add-DfsrMember -GroupName "FileServer-RG" -ComputerName "ALT_WS2016_<MSSV>", "ALT2_WS2016_<MSSV>"

# Tạo replicated folders
New-DfsReplicatedFolder -GroupName "FileServer-RG" -FolderName "Departments" -DomainName "<MSSV>.vn"
New-DfsReplicatedFolder -GroupName "FileServer-RG" -FolderName "Users" -DomainName "<MSSV>.vn"
New-DfsReplicatedFolder -GroupName "FileServer-RG" -FolderName "Projects" -DomainName "<MSSV>.vn"
```

### 3.3 Cấu hình Replication Topology

```powershell
# Set primary member (có dữ liệu ban đầu)
Set-DfsrMembership -GroupName "FileServer-RG" -FolderName "Departments" -ComputerName "ALT_WS2016_<MSSV>" -ContentPath "C:\FileServer\Departments" -PrimaryMember $true

Set-DfsrMembership -GroupName "FileServer-RG" -FolderName "Users" -ComputerName "ALT_WS2016_<MSSV>" -ContentPath "C:\FileServer\Users" -PrimaryMember $true

Set-DfsrMembership -GroupName "FileServer-RG" -FolderName "Projects" -ComputerName "ALT_WS2016_<MSSV>" -ContentPath "C:\FileServer\Projects" -PrimaryMember $true

# Set secondary member
Set-DfsrMembership -GroupName "FileServer-RG" -FolderName "Departments" -ComputerName "ALT2_WS2016_<MSSV>" -ContentPath "C:\FileServer\Departments"

Set-DfsrMembership -GroupName "FileServer-RG" -FolderName "Users" -ComputerName "ALT2_WS2016_<MSSV>" -ContentPath "C:\FileServer\Users"

Set-DfsrMembership -GroupName "FileServer-RG" -FolderName "Projects" -ComputerName "ALT2_WS2016_<MSSV>" -ContentPath "C:\FileServer\Projects"

# Tạo connection giữa members
Add-DfsrConnection -GroupName "FileServer-RG" -SourceComputerName "ALT_WS2016_<MSSV>" -DestinationComputerName "ALT2_WS2016_<MSSV>"
```

### 3.4 Monitor DFS Replication

```powershell
# Check replication status
Get-DfsrState -ComputerName "ALT_WS2016_<MSSV>", "ALT2_WS2016_<MSSV>"

# Generate replication report
New-DfsrPropagationTestFile -GroupName "FileServer-RG" -FolderName "Departments" -ReferenceComputerName "ALT_WS2016_<MSSV>"

# Check backlog
Get-DfsrBacklog -GroupName "FileServer-RG" -FolderName "Departments" -SourceComputerName "ALT_WS2016_<MSSV>" -DestinationComputerName "ALT2_WS2016_<MSSV>"

# Force replication
Sync-DfsReplicationGroup -GroupName "FileServer-RG" -SourceComputerName "ALT_WS2016_<MSSV>" -DestinationComputerName "ALT2_WS2016_<MSSV>"
```

### 3.5 Test DFS Replication

```powershell
# Test trên ALT_WS2016_<MSSV>
"Test replication file" | Out-File "C:\FileServer\Departments\IT\test-replication.txt"

# Đợi vài phút rồi check trên ALT2_WS2016_<MSSV>
Get-Content "C:\FileServer\Departments\IT\test-replication.txt"
# File sẽ được replicate tự động
```

---

## 4. Triển khai Network Load Balancing

### 4.1 Cài đặt NLB Feature

```powershell
# Trên ALT_WS2016_<MSSV> và ALT2_WS2016_<MSSV>
Install-WindowsFeature NLB -IncludeManagementTools

# Khởi động NLB service
Start-Service NlbSvc
Set-Service NlbSvc -StartupType Automatic
```

### 4.2 Tạo NLB Cluster

```powershell
# Trên ALT_WS2016_<MSSV> (First node)
# Tạo NLB cluster với Virtual IP
New-NlbCluster -InterfaceName "Ethernet" -ClusterName "FileServer-NLB" -ClusterPrimaryIP "192.168.1.100" -SubnetMask "255.255.255.0"

# Cấu hình cluster parameters
Get-NlbCluster | Set-NlbCluster -ClusterName "FileServer-NLB" -OperationMode Multicast

# Tạo port rule cho SMB (Port 445)
Get-NlbCluster | New-NlbClusterPortRule -StartPort 445 -EndPort 445 -Protocol TCP -Affinity Single
```

### 4.3 Thêm Node thứ hai vào NLB Cluster

```powershell
# Trên ALT2_WS2016_<MSSV>
# Join existing NLB cluster
Add-NlbClusterNode -InterfaceName "Ethernet" -ClusterName "FileServer-NLB" -ClusterPrimaryIP "192.168.1.100" -NewNodeInterface "Ethernet" -NewNodePriority 2

# Kiểm tra cluster status
Get-NlbCluster | Get-NlbClusterNode
```

### 4.4 Cấu hình DNS cho NLB

```powershell
# Trên DNS Server (WS2016_<MSSV>)
# Tạo A record cho Virtual IP
Add-DnsServerResourceRecordA -ZoneName "<MSSV>.vn" -Name "fileserver" -IPv4Address "192.168.1.100"

# Tạo CNAME
Add-DnsServerResourceRecordCName -ZoneName "<MSSV>.vn" -Name "files" -HostNameAlias "fileserver.<MSSV>.vn"
```

### 4.5 Test Network Load Balancing

```cmd
# Từ client
ping fileserver.<MSSV>.vn

# Test file access qua NLB
net use Y: \\fileserver.<MSSV>.vn\Departments
dir Y:\

# Stop một node và test lại
# Stop-NlbClusterNode -HostName "ALT_WS2016_<MSSV>"
# File access vẫn hoạt động qua node còn lại
```

---

## 5. Cấu hình Failover Clustering

### 5.1 Cài đặt Failover Clustering Feature

```powershell
# Trên ALT_WS2016_<MSSV> và ALT2_WS2016_<MSSV>
Install-WindowsFeature Failover-Clustering -IncludeManagementTools

# Validate cluster configuration
Test-Cluster -Node "ALT_WS2016_<MSSV>", "ALT2_WS2016_<MSSV>"
```

### 5.2 Tạo iSCSI Target (Storage Simulation)

```powershell
# Trên ALT3_WS2016_<MSSV> (làm iSCSI Target Server)
Install-WindowsFeature FS-iSCSITarget-Server -IncludeManagementTools

# Tạo virtual disk cho cluster
New-IscsiVirtualDisk -Path "C:\iSCSIVirtualDisks\ClusterDisk1.vhdx" -Size 10GB

# Tạo iSCSI Target
New-IscsiServerTarget -TargetName "FileServerCluster" -InitiatorIds "IQN:iqn.1991-05.com.microsoft:alt-ws2016-<mssv>", "IQN:iqn.1991-05.com.microsoft:alt2-ws2016-<mssv>"

# Add virtual disk to target
Add-IscsiVirtualDiskTargetMapping -TargetName "FileServerCluster" -Path "C:\iSCSIVirtualDisks\ClusterDisk1.vhdx"
```

### 5.3 Cấu hình iSCSI Initiator trên Cluster Nodes

```powershell
# Trên ALT_WS2016_<MSSV> và ALT2_WS2016_<MSSV>
# Start iSCSI service
Start-Service MSiSCSI
Set-Service MSiSCSI -StartupType Automatic

# Connect to iSCSI target
New-IscsiTargetPortal -TargetPortalAddress "192.168.1.5"
Connect-IscsiTarget -NodeAddress "iqn.1991-05.com.microsoft:alt3-ws2016-<mssv>-fileservercluster-target"

# Get disk information
Get-Disk | Where-Object {$_.BusType -eq "iSCSI"}

# Initialize và format shared disk (chỉ trên 1 node)
# Trên ALT_WS2016_<MSSV>
$disk = Get-Disk | Where-Object {$_.BusType -eq "iSCSI" -and $_.PartitionStyle -eq "RAW"}
Initialize-Disk -Number $disk.Number -PartitionStyle GPT
New-Partition -DiskNumber $disk.Number -UseMaximumSize -AssignDriveLetter
Format-Volume -DriveLetter E -FileSystem NTFS -NewFileSystemLabel "ClusterStorage"
```

### 5.4 Tạo Failover Cluster

```powershell
# Trên ALT_WS2016_<MSSV>
# Tạo cluster
New-Cluster -Name "FileServer-Cluster" -Node "ALT_WS2016_<MSSV>", "ALT2_WS2016_<MSSV>" -StaticAddress "192.168.1.101"

# Add shared disk to cluster
Get-ClusterAvailableDisk | Add-ClusterDisk

# Tạo File Server role
Add-ClusterFileServerRole -Name "FS-Cluster" -StaticAddress "192.168.1.102" -Storage "Cluster Disk 1"
```

### 5.5 Cấu hình Clustered File Share

```powershell
# Tạo thư mục trên shared storage
New-Item -Path "E:\ClusterShares" -ItemType Directory
New-Item -Path "E:\ClusterShares\CriticalData" -ItemType Directory

# Tạo clustered file share
New-SmbShare -Name "CriticalData" -Path "E:\ClusterShares\CriticalData" -FullAccess "Domain Admins" -ChangeAccess "Domain Users" -ContinuouslyAvailable $true
```

### 5.6 Test Failover Clustering

```powershell
# Test cluster failover
Move-ClusterGroup -Name "FS-Cluster" -Node "ALT2_WS2016_<MSSV>"

# Từ client test access
net use Z: \\FS-Cluster\CriticalData
echo "Cluster test file" > Z:\test.txt

# Failover lại và test
Move-ClusterGroup -Name "FS-Cluster" -Node "ALT_WS2016_<MSSV>"
dir Z:\  # File vẫn có
```

---

## 6. Sao lưu và phục hồi dữ liệu sử dụng Windows Server Backup

### 6.1 Cài đặt Windows Server Backup

```powershell
# Trên ALT_WS2016_<MSSV>
Install-WindowsFeature Windows-Server-Backup -IncludeManagementTools

# Import backup module
Import-Module WindowsServerBackup
```

### 6.2 Cấu hình Backup Target

```powershell
# Tạo thư mục backup
New-Item -Path "D:\Backups" -ItemType Directory

# Hoặc sử dụng external drive/network location
# Ví dụ: Network backup location
New-Item -Path "\\ALT3_WS2016_<MSSV>\Backups" -ItemType Directory
```

### 6.3 Tạo Backup Policy

```powershell
# Tạo backup policy
$policy = New-WBPolicy

# Add volumes to backup
$volume = Get-WBVolume -VolumePath "C:"
Add-WBVolume -Policy $policy -Volume $volume

# Add file specifications
$fileSpec = New-WBFileSpec -FileSpec "C:\FileServer"
Add-WBFileSpec -Policy $policy -FileSpec $fileSpec

# Set backup target
$target = New-WBBackupTarget -VolumePath "D:"
Add-WBBackupTarget -Policy $policy -Target $target

# Set backup schedule (daily at 2 AM)
Set-WBSchedule -Policy $policy -Schedule "02:00"

# Set policy
Set-WBPolicy -Policy $policy
```

### 6.4 Perform Manual Backup

```powershell
# Backup ngay lập tức
Start-WBBackup -Policy $policy

# Backup specific folders
$fileSpec = New-WBFileSpec -FileSpec "C:\FileServer\Departments"
$target = New-WBBackupTarget -VolumePath "D:"
Start-WBBackup -FileSpec $fileSpec -BackupTarget $target
```

### 6.5 Restore Operations

```powershell
# List available backups
Get-WBBackupSet

# Get specific backup
$backup = Get-WBBackupSet | Sort-Object BackupTime -Descending | Select-Object -First 1

# Restore files
$restoreItem = New-WBRestoreItem -BackupSet $backup -FileSpec "C:\FileServer\Departments"
Start-WBFileRestore -RestoreItem $restoreItem -RestoreToOriginalLocation

# Restore to alternate location
Start-WBFileRestore -RestoreItem $restoreItem -RestoreToAlternateLocation -AlternateLocation "C:\RestoreTemp"
```

### 6.6 Monitor Backup Jobs

```powershell
# Check backup job status
Get-WBJob

# Get backup summary
Get-WBSummary

# Check backup disk usage
Get-WBDisk

# View backup event logs
Get-WinEvent -LogName "Microsoft-Windows-Backup"
```

---

## 7. Automation Scripts và Monitoring

### 7.1 Complete Lab 6 Health Check Script

```powershell
function Test-Lab6Complete {
    Write-Host "========================================" -ForegroundColor Magenta
    Write-Host "         LAB 6 COMPLETE HEALTH CHECK    " -ForegroundColor Magenta  
    Write-Host "========================================" -ForegroundColor Magenta
    
    # Check FSRM
    Write-Host "`n=== FSRM Status ===" -ForegroundColor Green
    $fsrmService = Get-Service SrmSvc -ErrorAction SilentlyContinue
    Write-Host "FSRM Service: $($fsrmService.Status)" -ForegroundColor $(if($fsrmService.Status -eq 'Running'){'Green'}else{'Red'})
    
    $quotas = Get-FsrmQuota -ErrorAction SilentlyContinue
    Write-Host "Quotas configured: $($quotas.Count)" -ForegroundColor Yellow
    
    $fileScreens = Get-FsrmFileScreen -ErrorAction SilentlyContinue  
    Write-Host "File Screens: $($fileScreens.Count)" -ForegroundColor Yellow
    
    # Check DFS
    Write-Host "`n=== DFS Status ===" -ForegroundColor Green
    $dfsNamespace = Get-DfsnRoot -ErrorAction SilentlyContinue
    Write-Host "DFS Namespaces: $($dfsNamespace.Count)" -ForegroundColor Yellow
    
    $dfsReplication = Get-DfsReplicationGroup -ErrorAction SilentlyContinue
    Write-Host "DFS Replication Groups: $($dfsReplication.Count)" -ForegroundColor Yellow
    
    # Check NLB
    Write-Host "`n=== NLB Status ===" -ForegroundColor Green
    $nlbCluster = Get-NlbCluster -ErrorAction SilentlyContinue
    if ($nlbCluster) {
        Write-Host "NLB Cluster: $($nlbCluster.ClusterName)" -ForegroundColor Green
        $nlbNodes = Get-NlbClusterNode
        Write-Host "NLB Nodes: $($nlbNodes.Count)" -ForegroundColor Yellow
    } else {
        Write-Host "NLB Cluster: Not configured" -ForegroundColor Red
    }
    
    # Check Failover Clustering
    Write-Host "`n=== Failover Cluster Status ===" -ForegroundColor Green
    $cluster = Get-Cluster -ErrorAction SilentlyContinue
    if ($cluster) {
        Write-Host "Cluster Name: $($cluster.Name)" -ForegroundColor Green
        $clusterNodes = Get-ClusterNode
        Write-Host "Cluster Nodes: $($clusterNodes.Count)" -ForegroundColor Yellow
        
        $clusterResources = Get-ClusterResource
        Write-Host "Cluster Resources: $($clusterResources.Count)" -ForegroundColor Yellow
    } else {
        Write-Host "Failover Cluster: Not configured" -ForegroundColor Red
    }
    
    # Check Windows Server Backup
    Write-Host "`n=== Backup Status ===" -ForegroundColor Green
    $backupFeature = Get-WindowsFeature Windows-Server-Backup
    Write-Host "Backup Feature: $($backupFeature.InstallState)" -ForegroundColor $(if($backupFeature.InstallState -eq 'Installed'){'Green'}else{'Red'})
    
    $backupPolicy = Get-WBPolicy -ErrorAction SilentlyContinue
    if ($backupPolicy) {
        Write-Host "Backup Policy: Configured" -ForegroundColor Green
    } else {
        Write-Host "Backup Policy: Not configured" -ForegroundColor Yellow
    }
    
    Write-Host "`n========================================" -ForegroundColor Magenta
    Write-Host "         HEALTH CHECK COMPLETED         " -ForegroundColor Magenta
    Write-Host "========================================" -ForegroundColor Magenta
}

Test-Lab6Complete
```