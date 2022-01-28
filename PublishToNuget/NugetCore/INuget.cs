using NugetCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NugetCore
{
    /// <summary>
    /// nuget交互接口定义
    /// </summary>
    internal interface INuget
    {
        /// <summary>
        /// 包查询接口
        /// </summary>
        /// <param name="serverUrl">服务地址</param>
        /// <param name="q">查询关键字</param>
        /// <param name="prerelease">是否包含预发行版</param>
        /// <param name="skip">从第几条数据开始获取</param>
        /// <param name="take">一次获取多少数据</param>
        /// <param name="supportedFramework">支持的框架，格式 supportedFramework=.NETStandard,Version=v2.0&supportedFramework=net6.0</param>
        /// <param name="semVerLevel">不晓得这个参数是。。。</param>
        /// <returns>返回</returns>
        PackageSearchResult Search(string serverUrl, string q, bool prerelease, int skip, int take, List<string> supportedFramework, string semVerLevel = "2.0.0");
    }
}
