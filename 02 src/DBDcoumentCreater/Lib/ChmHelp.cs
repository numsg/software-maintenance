using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using gq.Ext;
/* 变量含义 rootPath:待编译的文件夹 rootParent:rootPath的父目录
 * 1.将rootPath目录下的文件编译成CHM。
 * 2.将编译过程中产生的hhp、hhc、hhk文件均放在rootParent下。
 * 3.基于rootParent，获取待编译文件的相对路径（相对rootParent）。
 */
namespace gq.Common
{
    /// <summary>
    /// Chm辅助类
    /// </summary>
    public class ChmHelp
    {
        #region 成员定义
        //Chm文件保存路径
        public string ChmFileName { get; set; }
        //Chm文件Titie
        public string Title { get; set; }
        //编译文件夹路径
        public string RootPath
        {
            get { return rootPath; }
            set
            {
                rootPath = Path.GetFullPath(value);
                //获取上级目录的完整路径
                //指定文件夹的父目录是作为关键字被文件的完整路径替换的，此时目录必须携带\\
                DirectoryInfo di = new DirectoryInfo(rootPath);
                rootParent = di.Parent.FullName + "\\";
            }
        }
        //默认页面 相对编译文件夹的路径
        public string DefaultPage
        {
            get//编译时路径是相对rootParent
            {
                var rootName = Path.GetFileName(rootPath);
                return rootName + "\\" + defaluePage;
            }
            set //赋值时路径是相对rootPath。
            {
                defaluePage = value;
            }
        }
        public int FileCount { get { return fileCount; } }
        //私有变量
        private string rootParent;
        private string rootPath;
        private string defaluePage;
        private int fileCount = 0;
        //CHM相关文件内容
        private StringBuilder hhcBody = new StringBuilder();
        private StringBuilder hhpBody = new StringBuilder();
        private StringBuilder hhkBody = new StringBuilder();
        private bool deleteTmp = true;
        //日志信息
        private StringBuilder sbMessage = new StringBuilder();
        public event Action<string> logHandle;
        #endregion

        #region hha 方法引入
        [DllImport("hha.dll")]
        private extern static void HHA_CompileHHP(string hhpFile, CompileLog g1, CompileLog g2, int stack);
        delegate bool CompileLog(string log);
        //编译信息
        private bool CompileLoging(string log)
        {
            if (logHandle != null) logHandle(log);
            return true;
        }
        private bool CompileProcess(string log)
        {
            return true;
        }
        #endregion

        #region 构造所需要的文件
        private void Create(string path)
        {
            //获取文件
            var strFileNames = Directory.GetFiles(path);
            //获取子目录
            var strDirectories = Directory.GetDirectories(path);
            //给该目录添加UL标记
            if (strFileNames.Length > 0 || strDirectories.Length > 0)
                hhcBody.AppendLine("	<UL>");
            //处理获取的文件
            foreach (string filename in strFileNames)
            {
                var fileItem = new StringBuilder();
                fileItem.AppendLine("	<LI> <OBJECT type=\"text/sitemap\">");
                fileItem.AppendLine("		<param name=\"Name\" value=\"{0}\">".FormatString(Path.GetFileNameWithoutExtension(filename)));
                fileItem.AppendLine("		<param name=\"Local\" value=\"{0}\">".FormatString(filename.Replace(rootParent, string.Empty)));
                fileItem.AppendLine("		<param name=\"ImageNumber\" value=\"11\">");
                fileItem.AppendLine("		</OBJECT>");
                //添加文件列表到hhp
                hhpBody.AppendLine(filename);
                hhcBody.Append(fileItem.ToString());
                hhkBody.Append(fileItem.ToString());
                //记录待编译文件总数
                fileCount++;
            }
            //遍历获取的目录
            foreach (string dirname in strDirectories)
            {
                hhcBody.AppendLine("	<LI> <OBJECT type=\"text/sitemap\">");
                hhcBody.AppendLine("		<param name=\"Name\" value=\"{0}\">".FormatString(Path.GetFileName(dirname)));
                hhcBody.AppendLine("		<param name=\"ImageNumber\" value=\"1\">");
                hhcBody.AppendLine("		</OBJECT>");
                //递归遍历子文件夹
                Create(dirname);
            }
            //给该目录添加/UL标记
            if (strFileNames.Length > 0 || strDirectories.Length > 0)
            {
                hhcBody.AppendLine("	</UL>");
            }
        }
        private void CreateHHC()
        {
            var code = new StringBuilder();
            code.AppendLine("<!DOCTYPE HTML PUBLIC \"-//IETF//DTD HTML//EN\">");
            code.AppendLine("<HTML>");
            code.AppendLine("<HEAD>");
            code.AppendLine("<meta name=\"GENERATOR\" content=\"EasyCHM.exe  www.zipghost.com\">");
            code.AppendLine("<!-- Sitemap 1.0 -->");
            code.AppendLine("</HEAD><BODY>");
            code.AppendLine("<OBJECT type=\"text/site properties\">");
            code.AppendLine("	<param name=\"ExWindow Styles\" value=\"0x200\">");
            code.AppendLine("	<param name=\"Window Styles\" value=\"0x800025\">");
            code.AppendLine("	<param name=\"Font\" value=\"MS Sans Serif,9,0\">");
            code.AppendLine("</OBJECT>");
            //遍历文件夹 构建hhc文件内容
            code.Append(hhcBody.ToString());
            code.AppendLine("</BODY></HTML>");
            //File.WriteAllText(Path.Combine(SourcePath, "chm.hhc"), code.ToString(), Encoding.GetEncoding("gb2312"));
            File.WriteAllText(".//chm.hhc", code.ToString(), Encoding.GetEncoding("gb2312"));
        }
        private void CreateHHP()
        {
            var code = new StringBuilder();
            code.AppendLine("[OPTIONS]");
            code.AppendLine("CITATION=Made by Chen");//制作人
            code.AppendLine("Compatibility=1.1 or later");//版本
            code.AppendLine(@"Compiled file=" + ChmFileName);//生成chm文件路径
            code.AppendLine("Contents file=chm.HHC");//hhc文件路径
            code.AppendLine("COPYRIGHT=www.jinwin.com");//版权所有
            code.AppendLine(@"Default topic={1}");//CHM文件的首页
            code.AppendLine("Default Window=Main");//目标文件窗体控制参数,这里跳转到Windows小节中，与其一致即可
            code.AppendLine("Display compile notes=Yes");//显示编译信息
            code.AppendLine("Display compile progress=Yes");//显示编译进度
            //code.AppendLine("Error log file=error.Log");//错误日志文件
            code.AppendLine("Full-text search=Yes");//是否支持全文检索信息
            code.AppendLine("Index file=chm.HHK");//hhk文件路径
            code.AppendLine("Title={0}");//CHM文件标题
            //code.AppendLine("Flat=NO");//编译文件不包括文件夹
            code.AppendLine("Enhanced decompilation=yes");//编译文件不包括文件夹
            code.AppendLine();
            code.AppendLine("[WINDOWS]");
            //例子中使用的参数 0x20 表示只显示目录和索引
            code.AppendLine("Main=\"{0}\",\"chm.hhc\",\"chm.hhk\",\"{1}\",\"{1}\",,,,,0x63520,180,0x104E, [0,0,745,509],0x0,0x0,,,,,0");
            //Easy Chm使用的参数 0x63520 表示目录索引搜索收藏夹
            //code.AppendLine("Main=\"{0}\",\"chm.HHC\",\"chm.HHK\",\"{1}\",\"{1}\",,,,,0x63520,271,0x304E,[0,0,745,509],,,,,,,0");
            code.AppendLine();
            code.AppendLine("[MERGE FILES]");
            code.AppendLine();
            code.AppendLine("[FILES]");
            code.Append(hhpBody.ToString());

            // File.WriteAllText(Path.Combine(SourcePath, "chm.hhp"), code.ToString().FormatString(Title, DefaultPage), Encoding.GetEncoding("gb2312"));
            File.WriteAllText(".//chm.hhp", code.ToString().FormatString(Title, DefaultPage), Encoding.GetEncoding("gb2312"));
        }
        private void CreateHHK()
        {
            var code = new StringBuilder();
            code.AppendLine("<!DOCTYPE HTML PUBLIC \"-//IETF//DTD HTML//EN\">");
            code.AppendLine("<HTML>");
            code.AppendLine("<HEAD>");
            code.AppendLine("<meta name=\"GENERATOR\" content=\"EasyCHM.exe  www.zipghost.com\">");
            code.AppendLine("<!-- Sitemap 1.0 -->");
            code.AppendLine("</HEAD><BODY>");
            code.AppendLine("<OBJECT type=\"text/site properties\">");
            code.AppendLine("	<param name=\"ExWindow Styles\" value=\"0x200\">");
            code.AppendLine("	<param name=\"Window Styles\" value=\"0x800025\">");
            code.AppendLine("	<param name=\"Font\" value=\"MS Sans Serif,9,0\">");
            code.AppendLine("</OBJECT>");
            code.AppendLine("<UL>");
            //遍历文件夹 构建hhc文件内容
            code.Append(hhkBody.ToString());
            code.AppendLine("</UL>");
            code.AppendLine("</BODY></HTML>");
            //File.WriteAllText(Path.Combine(SourcePath, "chm.hhk"), code.ToString(), Encoding.GetEncoding("gb2312"));
            File.WriteAllText(".//chm.hhk", code.ToString(), Encoding.GetEncoding("gb2312"));
        }
        #endregion

        /// <summary>
        /// 编译
        /// </summary>
        /// <returns></returns>
        public void Compile()
        {
            //准备hhp hhc hhk文件
            Create(RootPath);
            CreateHHC();
            CreateHHK();
            CreateHHP();
            var path = ".//chm.hhp";
            HHA_CompileHHP(path, CompileLoging, CompileProcess, 0);
            DeleteTmpFile();
        }
        /// <summary>
        /// 使用hhc.exe进行编译
        /// </summary>
        /// <param name="hhpPath"></param>
        private void CompileByHHC(string hhpPath)
        {
            var hhcPath = string.Empty;
            var program = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            if (File.Exists(".//hhc.exe"))
            {
                hhcPath = ".//hhc.exe";
            }
            else if (File.Exists(program + @"\HTML Help Workshop\hhc.exe"))
            {
                hhcPath = program + @"\HTML Help Workshop\hhc.exe";
            }
            else if (File.Exists(program + @" (x86)\HTML Help Workshop\hhc.exe"))
            {
                hhcPath = program + @" (x86)\HTML Help Workshop\hhc.exe";
            }
            else
            {
                throw new Exception("未找到编译核心文件hhc.exe");
            }
            var process = new Process();//创建新的进程，用Process启动HHC.EXE来Compile一个CHM文件
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processInfo.FileName = hhcPath;  //调入HHC.EXE文件 
                processInfo.Arguments = hhpPath;
                processInfo.UseShellExecute = false;
                processInfo.CreateNoWindow = false;
                process.StartInfo = processInfo;
                process.Start();
                process.WaitForExit(); //组件无限期地等待关联进程退出
                if (process.ExitCode == 0)
                {
                    throw new Exception("编译发生异常!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                process.Close();
            }
        }
        /// <summary>
        /// 反编译
        /// </summary>
        /// <returns></returns>
        public bool DeCompile()
        {
            //反编译时，Path作为CHM文件路径
            //得到chm文件的绝对路径
            string ExtportPath = Path.GetDirectoryName(ChmFileName);
            //命令参数含义
            //Path:导出的文件保存的路径
            //ChmPath:Chm文件所在的路径
            string cmd = " -decompile " + ExtportPath + " " + ChmFileName;//反编译命令
            Process p = Process.Start("hh.exe", cmd);//调用hh.exe进行反编译
            p.WaitForExit();
            return true;
        }
        //删除临时文件
        private void DeleteTmpFile()
        {
            if (deleteTmp)
            {
                var arr = new string[] { ".//chm.hhc", ".//chm.hhp", ".//chm.hhk" };
                foreach (var a in arr)
                {
                    if (File.Exists(a))
                    {
                        File.Delete(a);
                    }
                }
            }
        }
    }
}

/*   
hhc,列表文件,确定目标文件中左侧树形列表中"目录"选项卡下的内容.
hhk,索引文件,确定目标文件中左侧树形列表中"索引"选项卡下的内容.
hhp CHM工程文件,CHM目标文件属性95%的参数都在这里被确定.
 几乎就是一个标准的ini文件.分为三个小节Option,Windows,Files.
先看一下Option小节的内容及说明:
Binary index=yes
title="标题"
compatibility=1.1 or later
compiled file="z:\1.chm"
contents file"z:\12.hhc"
Default topic="index.html"
index file="index.hhk"
Full-text search=yes
Default Windows=main
language=0x804
Enhanced decompilation=yes
Flat=Yes
Create CHI file=Yes
error log file=a.log
基本上看字面意思就可以了解其具体内容,
Compatibility是版本,一般不变,下面是完成后CHM文件的位置及列表文件的文件名.
Default topic是目标CHM文件的首页.
Index File是索引文件的位置.
Full-text search是否支持全文检索信息.
Default Windows目标文件窗体控制参数,这里跳转到Windows小节中.
Enhanced Decompilation支持增强反编译
Flat编译文件不包括文件夹.
 
Windows小节中一般只需要一个值:
Main="","Tresss.hhc","Tresss.hhk",,,,,,,0x61520,240,0x104E,[80,60,720,540],0x0,0x0,,0,1,0,0

0x61520是这10个，240第11个，0X104E第12个。
很长,但目标CHM文件的窗口控制几乎都在这里了.
第1个参数,标题,这里为空时会读取Option小节中的"Title"
第2个参数,列表文件.
第3个参数,索引文件.
第4个参数,首页文件,即Option小节中的Default Topic.
第5个参数,主页,如果此项为空时,点击工具栏上的"主页"会打开第四参数的值的地址,如果不为空是则打开此值地址.
第6个参数,自定义链接一地址
第7个参数,自定义链接一标题.
第8个参数,自定义链接二地址.
第9个参数,自定义链接二标题.
    备注:CHM文件中可以有两个自定义链接按钮,即由上面四个参数控制.如果此值为空,则不显示其按钮.
第10个参数,控制工具栏所显示的按钮,其值及意义如下:
    书签=1000
    高级搜索=20000
    搜索=400
    全无=20(去掉)
    自动同步(当前标题改变时目录和索引自动同步)=100
    自动显示隐藏导航面板=1
    显示MSDN菜单=10000(最上面出现一行菜单)
    不显示工具栏=8000
    不显示工具栏按钮文本=40
    保存窗体位置=40000
第十一个参数,目标文件左侧列表栏初始化时的宽度.
第十二个参数,目标文件工具栏显示的按钮.其值及意义如下:
    此项为空时,有"显示/隐藏",有后退,有打印,有选项
    0x2=只有显示隐藏
    0x4=后退
    0x8=前进
    10=停止
    20=刷新
    40=主页
    0x800=只有定位
    0x1000=选项
    2000=打印
    0x40000=自定义按钮及链接一
    80000=自定义链接二
    100000=字体
    0x200000=下一步
    0x400000=上一步
    后面在中括号里的四个参数是确定目标文件初始化时窗体的位置.

第15个参数其实是控制是否置顶等窗口设置，0x8是置顶，其他暂不知道。。。


最后第4个参数,初始化时左侧列表的状态.此值为1时不显示左侧列表,为0时默认显示.
最后第3个参数,初始化时左侧列表的默认选项卡,此值为0时默认显示目录,为1时默认显示索引,为2时默认显示搜索,为3时默认显示书签.
最后第2个参数,初始化时左侧列表的选项卡位置,此值为0时默认显示在上边,为1时显示在左边,为2时显示在右边.
Files小节中是目标CHM文件中所包含的文件列表.这里一般只有htm或html文件,html文件所需要的一些支持文件如gif,css等文件,编译器会自动寻找并添加到目标CHM文件中.

 */
