# PLSQL 乱码问题解决方案

在我们使用PLSQL查询数据库的一些带中文的记录的时候出现乱码。

## 原因
因为数据库的编号格式和pl /sql developer的编码格式不统一造成的。

## 查看数据库字符集
```
select userenv('language') from dual;
```

查询结果：
```
AMERICAN_AMERICA.AL32UTF8
```

## 修改pl/sql developer 的编码格式

在windows中创 建一个名为“NLS_LANG”的系统环境变量，设置其值为AMERICAN_AMERICA.AL32UTF8，
然后重新启动 pl/sql developer，这样检索出来的中文内容就不会是乱码了。如果想转换为UTF8字符集，可以赋予“NLS_LANG”为 “AMERICAN_AMERICA.UTF8”，然后重新启动 pl/sql developer。其它字符集设置同上

NLS_LANG是一个环境变量，用于定义语言，地域以及字符集属性。对于非英语的字符集，NLS_LANG的设置就非常重要。

NLS：‘National Language Support (NLS)’ 当我们设定一种nls的时候实际上我们是为oracle在存放数据时指定了他的语种所特有的一些表达形式，比如我们选择chinese,那么它的中文字符如何存放,按什么规则排序，货币如何表示，日期格式也就被设定了。
 
NLS_LANG参数由以下部分组成:NLS_LANG=<Language>_<Territory>.<Clients Characterset>
NLS_Language 指定:
- Oracle（错误）信息的语言
- 日和月份的名称
注意：NLS_LANGUAGE与插入和查询的*数据*的语言无关。

NLS_Territory 指定:
- 货币和数字格式
- 计算星期和天数的范围和惯例

客户端字符集（CLIENTS CHARACTERSET）:
- 定义Oracle客户端，客户应用使用的编码
- 或者它要符合您Microsoft Windows代码页 （GUI工具的ACP, 命令提示符的CHCP 值）
- 或者为Unicode WIN32应用设置为UTF8/AL32UTF8。


常见的值可以参见[Oracle Database Client Globalization Support](http://docs.oracle.com/html/B10131_02/gblsupp.htm