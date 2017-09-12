# windbg系列之分析程序UI卡住 -1 

## 背景
在升级艾斯美拉达斯过程中，出现如下问题。
在刚升级的某一台视频客户端启动后，UI卡住，进程卡死。

下面再分析如何使用windbg进行分析，

## 分析一台正常启动的客户端

## 分析异常启动的客户端

在load C:\Windows\SysWOW64\python27.dll 这个dll后系统系统就不继续往下走了。

因为这个还是在加载arcgis，初步判断是在加载arcgis的环境时出现了问题。


而我们客户端环境是依赖了arcgis Engine的环境。

于是卸载arcgis engine，重新安装，问题解决。