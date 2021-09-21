// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Wolf.Systems.Core.Internal.Configuration;
using Wolf.Systems.Enum;
using Wolf.Systems.Exceptions;

namespace Wolf.Systems.Core.Common
{
    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public static class EnumCommon
    {
        private static Hashtable _enumDesciption;

        static EnumCommon()
        {
            _enumDesciption = GetDescriptionContainer();
        }

        private static Hashtable GetDescriptionContainer()
        {
            _enumDesciption = new Hashtable();
            return _enumDesciption;
        }

        #region 得到枚举字典（key对应枚举的值，value对应枚举的注释）

        /// <summary>
        /// 得到枚举字典（key对应枚举的值，value对应枚举的注释）
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> ToDescriptionDictionary<TEnum>()
        {
            Array arrays = System.Enum.GetValues(typeof(TEnum));
            Dictionary<int, string> dics = new Dictionary<int, string>();
            foreach (System.Enum value in arrays)
            {
                dics.Add(Convert.ToInt32(value), value.GetDescription());
            }

            return dics;
        }

        #endregion

        #region 得到枚举字典key的集合

        /// <summary>
        /// 得到枚举字典key的集合（例如：enum Gender{
        ///    Boy=0,
        ///    Girl=1
        /// }）//其中Girl与Boy为Key
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static List<string> GetKeys<TEnum>()
        {
            Array arrays = System.Enum.GetValues(typeof(TEnum));
            List<string> keys = new List<string>();
            foreach (System.Enum key in arrays)
            {
                keys.Add(key.ToString());
            }

            return keys;
        }

        #endregion

        #region 得到枚举字典value的集合

        /// <summary>
        /// 得到枚举字典value的集合
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static List<int> GetValues<TEnum>()
        {
            Array arrays = System.Enum.GetValues(typeof(TEnum));
            List<int> values = new List<int>();
            foreach (System.Enum value in arrays)
            {
                values.Add(Convert.ToInt32(value));
            }

            return values;
        }

        #endregion

        #region 返回枚举项的描述信息

        /// <summary>
        /// 返回枚举项的描述信息。
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        /// <returns>枚举想的描述信息。</returns>
        public static string GetDescription(Type type, object member) => GetCustomerObj<DescriptionAttribute>(type, member)?.Description;

        /// <summary>
        /// 返回枚举项的描述信息。
        /// </summary>
        /// <param name="member">成员名、值、实例均可</param>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns>枚举想的描述信息。</returns>
        public static string GetDescription<TEnum>(object member) => GetDescription(typeof(TEnum), member);

        #endregion

        #region 得到自定义描述

        /// <summary>
        /// 得到自定义描述
        /// </summary>
        /// <param name="member">成员名、值、实例均可</param>
        /// <typeparam name="T">得到自定义描述</typeparam>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static T GetCustomerObj<T, TEnum>(object member)
            where T : Attribute
            => GetCustomerObj<T>(typeof(TEnum), member);

        /// <summary>
        /// 得到自定义描述
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="member">成员名、值、实例均可</param>
        /// <typeparam name="T">得到自定义描述</typeparam>
        /// <returns></returns>
        public static T GetCustomerObj<T>(Type type, object member) where T : Attribute
        {
            int? enumValue = member.ConvertToInt();
            if (enumValue != null && enumValue.Value.IsExist(type))
            {
                return
                    type.GetCustomAttribute<T>(GetKey(type, member));
            }

            return default;
        }

        #endregion

        #region 获取枚举实例

        /// <summary>
        /// 获取枚举实例
        /// </summary>
        /// <param name="member">成员名或者枚举值，例如：Gender中有Boy=1,则传入Boy或者1可获得Gender.Boy</param>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static TEnum Parse<TEnum>(object member)
            where TEnum : System.Enum
        {
            if (TryParse(member, out TEnum value))
            {
                return value;
            }

            throw new BusinessException("转换失败，枚举中未找到当前成员信息", ErrorCode.ParamError);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="member">成员名或者枚举值，例如：Gender中有Boy=1,则传入Boy或者1可获得Gender.Boy</param>
        /// <param name="value"></param>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <returns></returns>
        public static bool TryParse<TEnum>(object member, out TEnum value) where TEnum : System.Enum
        {
            value = default;
            string memberStr = member.SafeString();
            if (string.IsNullOrWhiteSpace(memberStr))
            {
                if (typeof(TEnum).IsGenericType)
                    return false;
                throw new ArgumentNullException(nameof(member));
            }

            value = (TEnum)System.Enum.Parse(typeof(TEnum), memberStr, true);
            var enumValue = value.ConvertToInt(null);
            if (enumValue == null)
            {
                return false;
            }

            return enumValue.Value.IsExist(typeof(TEnum));
        }

        #endregion

        #region 获取枚举的成员名

        /// <summary>
        /// 获取枚举实例
        /// </summary>
        /// <param name="member">枚举类型</param>
        /// <typeparam name="TEnum">成员名或者枚举值，例如：Gender中有Boy=1,则传入Boy或者1或者Gender.Boy可获得其key</typeparam>
        /// <returns></returns>
        public static string GetKey<TEnum>(object member) => GetKey(typeof(TEnum), member);

        /// <summary>
        /// 获取成员名
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名或者枚举值，例如：Gender中有Boy=1,则传入Boy或者1或者Gender.Boy可获得其Key</param>
        public static string GetKey(Type type, object member)
        {
            bool isEnum = false;
#if NET40
            isEnum = type.IsEnum;
#elif !NET40
        isEnum = type.IsEnum();
#endif
            if (type == null || member == null || !isEnum)
                return Const.Empty;
            if (member.IsInt())
            {
                return System.Enum.GetName(type, member.ConvertToInt(0));
            }

            if (member is string)
            {
                return member.ToString();
            }

            return System.Enum.GetName(type, member);
        }

        #endregion

        #region 获取枚举的成员值

        /// <summary>
        /// 获取枚举的成员值
        /// </summary>
        /// <param name="member">枚举类型</param>
        /// <typeparam name="TEnum">成员名或者枚举值，例如：Gender中有Boy=1,则传入Boy或者1或者Gender.Boy可获得其value</typeparam>
        /// <returns></returns>
        public static int? GetValue<TEnum>(object member)
            where TEnum : struct
            => GetValue(typeof(TEnum), member);

        /// <summary>
        /// 获取枚举的成员值
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <param name="member">成员名或者枚举值，例如：Gender中有Boy=1,则传入Boy或者1或者Gender.Boy可获得其value</param>
        public static int? GetValue(Type type, object member)
        {
            bool isEnum = false;
#if NET40
            isEnum = type.IsEnum;
#elif !NET40
        isEnum = type.IsEnum();
#endif
            if (type == null || member == null || !isEnum)
                return null;
            string value = member.SafeString();
            if (value.IsNullOrWhiteSpace())
                return null;
            var val = (System.Enum.Parse(type, value, true));
            return val.ConvertToInt();
        }

        #endregion
    }
}
