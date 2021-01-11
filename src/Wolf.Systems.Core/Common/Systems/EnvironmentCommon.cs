﻿// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
#if NETSTANDARD
using System.Runtime.InteropServices;
#endif
using Wolf.Systems.ComponentModel;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Common.Systems
{
    /// <summary>
    /// 环境信息
    /// </summary>
    public static class EnvironmentCommon
    {
        /// <summary>
        /// 操作系统信息
        /// </summary>
        public static OsInfo GetOs => new OsInfo();

        /// <summary>
        /// 得到运行环境
        /// </summary>
        public static RunInfo GetRun => new RunInfo();

        /// <summary>
        /// 操作系统信息
        /// </summary>
        public class OsInfo
        {
            /// <summary>
            /// 是否Windows操作系统
            /// </summary>
            [EName("是否Windows系统")]
            public bool IsWindows()
            {
#if NETSTANDARD
                return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#endif
#if NETFRAMEWORK
                return true;
#endif
            }

            /// <summary>
            /// 是否Linux操作系统
            /// </summary>
            [EName("是否Linux系统")]
            public bool IsLinux()
            {
#if NETSTANDARD
                return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
#endif
#if NETFRAMEWORK
                return false;
#endif
            }

            /// <summary>
            /// 是否苹果操作系统
            /// </summary>
            [EName("是否Mac系统")]
            public bool IsOsx()
            {
#if NETSTANDARD
                return RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
#endif
#if NETFRAMEWORK
                return true;
#endif
            }

            /// <summary>
            /// 当前操作系统
            /// </summary>
            [EName("操作系统")]
            public OsPlatform? GetSystem()
            {
                if (IsWindows())
                {
                    return OsPlatform.Windows;
                }

                if (IsLinux())
                {
                    return OsPlatform.Linux;
                }

                if (IsOsx())
                {
                    return OsPlatform.Osx;
                }

                return null;
            }

            /// <summary>
            /// 得到操作系统版本信息
            /// </summary>
            [EName("操作系统版本")]
            public OperatingSystem Version => Environment.OSVersion;

            /// <summary>
            /// 得到操作系统版本
            /// </summary>
            [EName("操作系统版本")]
            public string VersionStr => Version.ToString();

            /// <summary>
            /// 是否64位操作系统
            /// </summary>
            [EName("是否64位操作系统")]
            public bool Is64BitOperatingSystem => Environment.Is64BitOperatingSystem;

            /// <summary>
            /// OSArchitecture
            /// </summary>
            [EName("平台架构")]
            public string OsArchitecture()
            {
#if NETSTANDARD
                return RuntimeInformation.OSArchitecture.ToString();
#endif

#if NETFRAMEWORK
                if (IntPtr.Size == 8)
                    return "X64";
                return "X86";
#endif
            }

            /// <summary>
            /// 运行框架
            /// </summary>
            [EName("运行框架")]
            public string FrameworkDescription()
            {
#if NETSTANDARD
                return RuntimeInformation.FrameworkDescription;
#endif

#if NETFRAMEWORK
                return ".NET Framework "+Environment.Version.ToString();
#endif
            }
        }

        /// <summary>
        /// 运行信息
        /// </summary>
        public class RunInfo
        {
            /// <summary>
            /// 机器名称
            /// </summary>
            [EName("机器名称")]
            public string MachineName => Environment.MachineName;

            /// <summary>
            /// 得到Cpu核心数
            /// </summary>
            [EName("Cpu核心数")]
            public int ProcessorCount => Environment.ProcessorCount;

            /// <summary>
            /// 用户网络域名
            /// </summary>
            [EName("用户网络域名")]
            public string UserDomainName => Environment.UserDomainName;

            /// <summary>
            /// 分区磁盘
            /// </summary>
            [EName("分区磁盘")]
            public string[] LogicalDrives => Environment.GetLogicalDrives();

            /// <summary>
            /// 得到本地物理磁盘的数量
            /// </summary>
            [EName("分区磁盘数量")]
            public int LogicalDriveCount => LogicalDrives.Length;

            /// <summary>
            /// 系统目录
            /// </summary>
            [EName("系统目录")]
            public string SystemDirectory => Environment.SystemDirectory;

            /// <summary>
            /// 系统已运行时间(毫秒)
            /// </summary>
            [EName("系统已运行时间(毫秒)")]
            public int TickCount => Environment.TickCount;

            /// <summary>
            /// 是否在交互模式中运行
            /// </summary>
            [EName("是否在交互模式中运行")]
            public bool UserInteractive => Environment.UserInteractive;

            /// <summary>
            /// 当前关联用户名
            /// </summary>
            [EName("当前关联用户名")]
            public string UserName => Environment.UserName;

            /// <summary>
            /// Web程序核心框架版本
            /// </summary>
            [EName("Web程序核心框架版本")]
            public string Version => Environment.Version.ToString();

            /// <summary>
            /// 得到当前程序
            /// </summary>
            private Process CurrentProcess => Process.GetCurrentProcess();

            /// <summary>
            /// 得到用使用的物理内存(byte)
            /// </summary>
            [EName("已使用内存(byte)")]
            public decimal UseMemory => CurrentProcess.WorkingSet64;

            /// <summary>
            /// 进程已占耗CPU时间(ms)
            /// </summary>
            [EName("进程已占耗CPU时间(ms)")]
            public TimeSpan TotalProcessorTime => CurrentProcess.TotalProcessorTime;
        }
    }
}
