// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Wolf.Systems.Abstracts;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Common
{
  /// <summary>
  /// 身份证帮助类
  /// </summary>
  public static class IdCardCommon
    {
        #region 根据身份证号得到生肖信息 如果身份证号码错误，则返回Null

        /// <summary>
        /// 根据身份证号得到生肖信息 如果身份证号码错误，则返回Null
        /// </summary>
        /// <param name="cardNo">身份证号码</param>
        /// <param name="nationality">国家，默认中国</param>
        /// <returns></returns>
        public static Animal? GetAnimal(string cardNo, Nationality nationality = Nationality.China)
        {
            var animal = GetCardProvider(nationality).GetAnimal(cardNo);
            if (animal != null)
            {
                return (Animal) animal;
            }

            return null;
        }

        #endregion

        #region 根据身份证号码获取出生日期

        /// <summary>
        /// 根据身份证号码获取出生日期
        /// </summary>
        /// <param name="cardNo">身份证号码</param>
        /// <param name="nationality">国家，默认中国</param>
        /// <returns></returns>
        public static DateTime? GetBirthday(string cardNo, Nationality nationality = Nationality.China)=> GetCardProvider(nationality).GetBirthday(cardNo);

        #endregion

        #region 根据身份证号码获取性别

        /// <summary>
        /// 根据身份证号码获取性别
        /// </summary>
        /// <param name="cardNo">身份证号码</param>
        /// <param name="nationality">国家，默认中国</param>
        /// <returns></returns>
        public static Gender? GetGender(string cardNo, Nationality nationality = Nationality.China)
        {
            var gender= GetCardProvider(nationality).GetGender(cardNo);
            if (gender != null)
            {
                return (Gender) gender;
            }

            return null;
        }

        #endregion

        #region 根据身份证号码得到星座信息

        /// <summary>
        /// 根据身份证号码得到星座信息
        /// </summary>
        /// <param name="cardNo">身份证号码</param>
        /// <param name="nationality">国家，默认中国</param>
        /// <returns></returns>
        public static Constellation? GetConstellation(string cardNo, Nationality nationality = Nationality.China)
        {
            var constellation= GetCardProvider(nationality).GetConstellation(cardNo);
            if (constellation != null)
            {
                return (Constellation) constellation;
            }

            return null;
        }

        #endregion

        #region private methods

        #region 得到身份证提供者

        /// <summary>
        /// 得到身份证提供者
        /// </summary>
        /// <param name="nationality">国家</param>
        /// <returns></returns>
        private static IIdCardProvider GetCardProvider(Nationality nationality)=> GlobalConfigurations.Instance.GetIdCardProvider(nationality) ??
                   throw new NotImplementedException("不支持的身份证提供者");

        #endregion

        #endregion
    }
}
