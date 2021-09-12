// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Wolf.Systems.ComponentModel;

/// <summary>
/// 名称信息
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public class ENameAttribute : Attribute
{
    /// <summary>
    /// 自定义名称属性
    /// </summary>
    private readonly string _name;

    /// <summary>
    /// 自定义名称属性
    /// </summary>
    public virtual string Name => _name;

    /// <summary>
    /// 名称信息
    /// </summary>
    /// <param name="name"></param>
    public ENameAttribute(string name) => _name = name;
}
