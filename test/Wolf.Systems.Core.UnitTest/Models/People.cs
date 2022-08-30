// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See LICENSE.md in the project root for license information.

namespace Wolf.Systems.Core.UnitTest.Models;

public class People
{
    public string Name { get; set; }

    public int Age { get; set; }

    public People(string name)
    {
        Name = name;
    }

    public People(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public People(int age, string name)
    {
        Name = name + "测试";
        Age = age;
    }
}
