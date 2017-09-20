# dp备份失败

现象： 在巡检的时候发现dp不能备份，在了解到dp不能备份的时间点恰好是客户方在做硬件清灰的时间。

软件方面检查： 检查了DP相关的软件环境(如备份用户，host文件，数据库连接情况等)都正常。

日志查看：dp备份异常日志如下，

```
[Critical] From: UMA@tulcanbackup "HP:MSL G3 Series"  Time: 9/19/2017 10:07:42 AM
[90:59]  	tulcanbackup : Changer1:0:0:1
	Cannot open exchanger control device ([2] The system cannot find the file specified. )
	
RMAN-03009: failure of backup command on dev_0 channel at 09/19/2017 10:04:51
ORA-19506: failed to create sequential file, name="Tulcandb1_pcarchi_inc1_7_2_3_4_5_AM4<pcarchi_4815:955101888:1>.dbf", parms=""
ORA-27028: skgfqcre: sbtbackup returned error
ORA-19511: Error received from media manager layer, error text:
   Vendor specific error: OB2_StartObjectBackup() failed ERR(-17)
```

分析日志：
Data Protector 无法控制 MSL G3 , 可能的问题有：
1.  硬件问题 ( MSL G3 ? SCSI HBA ? SCSI cable ? SCSI terminator ? FC HBA ? FC cable ? SAN Switch ? ) ,  需要检查
2. DP 設定 Media & Device 有問題了 ( 试试 , 重新 Add Device )
3.  MA version 高于 CM version ? 需要检查
4.  MSL G3 driver version 有问题 ?  需要检查 , 更新到当前的版本
5. MSL G3 Firmware 有问题 ?  需要检查
6. SCSI HBA 的 Firmware or driver 有问题?  需要检查
7. FC HBA 的 Firmware or driver 有问题?  需要检查

带着这些怀疑让硬件同事进了客户的机房进行检查，发现磁带库的一个光纤网卡信号灯没有亮。（硬件问题）
