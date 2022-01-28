using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NugetCore
{
    /// <summary>
    /// nuget发送命令
    /// </summary>
    internal class NugetCommand
    {
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="command">命令内容</param>
        /// <returns></returns>
        public static string ExecuteCommand(string command) 
        {
            //实例一个Process类，启动一个独立进程
            var p = new Process();
            //Process类有一个StartInfo属性
            //设定程序名
            p.StartInfo.FileName = "cmd.exe";
            //设定程式执行参数   
            p.StartInfo.Arguments = "/c " + command;
            //关闭Shell的使用  
            p.StartInfo.UseShellExecute = false;
            //重定向标准输入     
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出  
            p.StartInfo.RedirectStandardError = true;
            //设置不显示窗口
            p.StartInfo.CreateNoWindow = true;
            //启动
            p.Start();
            //从输出流取得命令执行结果
            return p.StandardOutput.ReadToEnd();
        }
    }
}
