// Copyright (c) zhenlei520 All rights reserved.

namespace Wolf.Systems.Enumerations;

/// <summary>
/// 有序的Guid方式
/// </summary>
public class SequentialGuidType : Enumerations.SeedWork.Enumeration
{
    /// <summary>
    /// 默认Guid
    /// </summary>
    public static SequentialGuidType Default = new SequentialGuidType(1, "DefaultGuid");

    /// <summary>
    ///
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name">描述</param>
    protected SequentialGuidType(int id, string name) : base(id, name)
    {
    }
}
