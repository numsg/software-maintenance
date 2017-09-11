# windbg中常用到的命令

下面这些命令是本人在运维过程中使用windbg常用到的一些命令：

.load C:\WINDOWS\system32\ntdll.dll(.symfix; .reload)

.reload /f

.load C:\Windows\Microsoft.NET\Framework\v4.0.30319\sos.dll

!eeheap -gc

!dumpheap -stat 查看内存所有对象!dumpheap -min 85000

!dumpheap -mt  找到对象对应的地址

!do  查看对象的状态

!do [value] 查看对象的值


Found 1 unique roots (run '!GCRoot -all' to see all roots).

!dumpheap -type WinDBG 查看GC未回收的对象

!gcroot 037b2e00 

sxe CLR 在遇到CRL异常时中断

!clrstack 调用堆栈

!syncblk

 ~*e!clrstack

!runaway

~*kv 查看所有线程的调用堆栈

!threads

~  查看所有线程

~0s 切换到当前第0个线程

使用32位任务管理器，运行：C:\Windows\SysWOW64\taskmgr.exe

.cordll -ve -u -l 查看dll的版本

!analyze -v  dump文件分析


!DumpArray
