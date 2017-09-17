# 一线运维相关资料

背景说明： 由于这个项目服务端和客户端技术都是使用的c#，所以下面提到的一些运维工具也是针对c#特有的(项目具体的背景就不详细介绍了)。

编写目的，主要是整理这些年一线运维的一些经验和技巧，利用这些工具和技巧快速解决问题，为用户提供给好的技术支持。

说明： 由于这个目前还是初稿，后面里面的结构可能会调整~~

## 1 一线运维需要注意几点

1. 沟通技巧（这个最重要）
2. 运维工具选择
3. 排除问题的思路
4. 良好的心态

## 2 沟通技巧

这个由于本人也是技术出身，沟通的能力也不行，在这就不分享了，但在一线运维过程中，沟通这项工作特别特别重要。

## 3 运维工具选择

下面来分享一下本人在现在运维过程中常用到的一些工具(有了这些工具，在运维过程中遇到的问题，基本99%都可以解决)。

### 3.1 .netreflector(c#地面饭编译工具)
这个工具主要是解决修复现场的某些很紧急的BUG缺陷。因为一般在运维现场不会有打包发布的流程，而当我们在现场运维过程中遇到了一些很紧急的BUG的话，而又来不及及时打包，这时我们就可以使用这个工具，对需要修改的dll进行IL注入，修改完成后，通过替换dll来达到修复BUG的目标。

下载地址：[.netreflector](https://www.red-gate.com/dynamic/products/dotnet-development/reflector/download)

[具体示例](https://github.com/numsg/software-maintenance/blob/master/90%20docs/netreflector.md)

### 3.2 ILSpy(c#代码反编译调试工具)
这个工具主要用来调试在运维过程中发现的BUG。在运维过程中，出现问题的概率是很大的，而有些问题，我们通过走查代码又很难发现，这时，ILSpy就派上用场了，通过直接反编译dll，附加到运行的exe进程进行调试，调试方法类似于vs。

[工具下载](https://github.com/numsg/software-maintenance/blob/master/01%20tools/ILSpy-Debugger.zip)

### 3.3 windbg(windows内核调试工具)
这个工具主要是来解决一些疑难杂症。可以清楚知道应用程序的运行的加载过程，可以分析应用程序运行过程中的内存镜像，还可以分析应用程序某一刻运行的内存快照dump文件，还可以分析应用程序运行过程中产生的线程等等。

[windbg常用命令](https://github.com/numsg/software-maintenance/blob/master/90%20docs/windbg-command.md)

[windbg系列之查看内存对象的值](https://github.com/numsg/software-maintenance/blob/master/90%20docs/windbg-memory-value.md)

[windbg系列之分析访问受保护的内存](https://github.com/numsg/software-maintenance/blob/master/90%20docs/windbg-access-protect.md)

[windbg系列之分析程序UI卡住](https://github.com/numsg/software-maintenance/blob/master/90%20docs/windbg-ui.md)

[windbg系列之分析程序UI卡住 -1](https://github.com/numsg/software-maintenance/blob/master/90%20docs/windbg-ui-1.md)


### 3.4 PLSQL

这个主要是用来对数据库的检查的。

### 3.5 PortViewer

这个主要是用来查看某台PC机端口的使用情况。

[端口问题处理](https://github.com/numsg/software-maintenance/blob/master/90%20docs/port-viewer.md)

### 3.6 4GB内存工具

这个主要是用来将客户端程序可使用的内存上限提升到4GB，适用于c# c++ 的exe程序。

[工具下载 c++版本](https://github.com/numsg/software-maintenance/blob/master/01%20tools/authorizetool.zip)

[工具下载 c#版本](https://github.com/numsg/software-maintenance/blob/master/01%20tools/C%23%E7%89%88author.zip)

### 3.7 db_back

这个工具主要是用来对数据基础数据及数据字典进行备份。

[工具使用说明](https://github.com/numsg/software-maintenance/blob/master/90%20docs/db-back.md)

## 4 常见问题分析

### 4.1 分布式事务处理异常

 解决方案: 重新安装msdtc服务，dtc服务允许 出栈和入栈。

 [具体解决方案](https://github.com/numsg/software-maintenance/blob/master/90%20docs/msdtc.md)

### 4.2 win7开机报错

win7开机报错: Windows 7: Runtime Error! Program: C\:windows\system32\nvvsvc.exe。 

解决方案：打开服务管理器，停掉NVIDIA Display Driver Service服务即可 

### 4.3 .netframework找不到对应的provider

主要原因是：ODAC的安装顺序与.netframework的安装顺序不对。
解决方案有两种：
1. 需要执行脚本[oracleforframework.bat](https://github.com/numsg/software-maintenance/blob/master/03%20scripts/oracleforframework.bat)
2. 重新安装一下.netframework

### 4.4 客户端在安装时发现不能安装，提升找不到arcgis9.3

其实我们客户端是没有依赖arcgis9.3环境的，主要原因是使用域控分发策略，使得注册表installer目录下有了老版本的安装包信息，将其删除掉即可。

### 4.5 客户端提升内存溢出

使用4GB内存工具将exe包装一把即可

[内存溢出另类解决方案](https://github.com/numsg/software-maintenance/blob/master/90%20docs/outofmemory.md)

### 4.5 客户端视频都点播不起来，点播起来也需要好长时间

主要检查下客户端杀毒软件及查看防火墙是否关闭

### 4.6 新安装的虚拟机重启后找不到d盘和e盘

主要原因是域控策略禁用了磁盘的挂载，将域控策略禁用即可。

### 4.7 客户端启动后主屏显示混乱

主要原因是客户机有三屏，需要将电脑主屏显示我们软件的主屏。

### 4.8 数据库rac一个节点不能启动

数据库因为调整网络后，一个节点不能起来，报错ora-00603，ora-27504。检查发现用于互联的eth1没有up，也相当于整个节点没有连接到交换机。

解决方案：将eth1 up，启动数据库即可(startup mount； alert database open)

### 4.9 dp无法备份
原因：

1. 磁带库已满
2. GG不能连通
3. 数据库服务器上的tnsnames.ora不准确。

### 4.10 启动客户端出现c++运行时错误

一般是使用c++的动态库错误造成(可以修改使用c++问题，如替换MXD,还可以修改环境变量解决)


待续...



