// Copyright (c) zhenlei520 All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Wolf.Systems.Abstracts;
using Wolf.Systems.Core.Common;
using Wolf.Systems.Enum;

namespace Wolf.Systems.Core.Provider.IdCard
{
    /// <summary>
    ///
    /// </summary>
    public class ChinaIdCardProvider : IIdCardProvider
    {
        /// <summary>
        /// 国家
        /// </summary>
        public int Nationality => (int)Enum.Nationality.China;

        #region 是否身份证

        /// <summary>
        /// 是否身份证
        /// </summary>
        /// <param name="cardNo">身份证编号</param>
        /// <returns></returns>
        public bool IsIdCard(string cardNo)
        {
            if (string.IsNullOrEmpty(cardNo))
                return false;
            if (cardNo.Length == 18)
                return CheckIdCard18(cardNo);
            if (cardNo.Length == 15)
                return CheckIdCard15(cardNo);
            return false;
        }

        /// <summary>
        /// 是否为18位身份证号
        /// </summary>
        private static bool CheckIdCard18(string id)
        {
            long n;
            if (long.TryParse(id.Remove(17), out n) == false || n < Math.Pow(10, 16) ||
                long.TryParse(id.Replace('x', '0').Replace('X', '0'), out n) == false)
                return false; //数字验证

            string address =
                "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(id.Remove(2), StringComparison.Ordinal) == -1)
                return false; //省份验证

            string birth = id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
            DateTime time;
            if (DateTime.TryParse(birth, out time) == false)
                return false; //生日验证

            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
            char[] ai = id.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
                sum += int.Parse(wi[i]) * int.Parse(ai[i].ToString());

            int y;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != id.Substring(17, 1).ToLower())
                return false; //校验码验证

            return true; //符合GB11643-1999标准
        }

        /// <summary>
        /// 是否为15位身份证号
        /// </summary>
        private static bool CheckIdCard15(string id)
        {
            long n;
            if (long.TryParse(id, out n) == false || n < Math.Pow(10, 14))
                return false; //数字验证

            string address =
                "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            if (address.IndexOf(id.Remove(2), StringComparison.Ordinal) == -1)
                return false; //省份验证

            string birth = id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            if (DateTime.TryParse(birth, out _) == false)
                return false; //生日验证

            return true; //符合15位身份证标准
        }

        #endregion

        #region 得到生肖信息

        /// <summary>
        /// 得到生肖信息
        /// </summary>
        /// <param name="cardNo">身份证号</param>
        /// <returns></returns>
        public int? GetAnimal(string cardNo)
        {
            if (!IsIdCard(cardNo))
            {
                return null;
            }
            var birthday = GetBirthday(cardNo);
            if (birthday != null)
            {
                var animal = TimeCommon.GetAnimal(birthday.Value.Year);
                if (animal != null)
                {
                    return (int)animal;
                }
            }

            return null;
        }

        #endregion

        #region 得到生日信息

        /// <summary>
        /// 得到生日信息
        /// </summary>
        /// <param name="cardNo">身份证号</param>
        /// <returns></returns>
        public DateTime? GetBirthday(string cardNo)
        {
            if (!IsIdCard(cardNo))
            {
                return null;
            }

            string timeStr = cardNo.Length == 15
                ? "19" + cardNo.Substring(6, 2) + "-" + cardNo.Substring(8, 2) + "-" +
                  cardNo.Substring(10, 2)
                : cardNo.Substring(6, 4) + "-" + cardNo.Substring(10, 2) + "-" + cardNo.Substring(12, 2);
            return timeStr.ConvertToDateTime();
        }

        #endregion

        #region 得到性别

        /// <summary>
        /// 得到性别
        /// </summary>
        /// <param name="cardNo">身份证号</param>
        /// <returns></returns>
        public int? GetGender(string cardNo)
        {
            if (!IsIdCard(cardNo))
            {
                return null;
            }

            int? gender = (cardNo.Length == 15 ? cardNo.Substring(14, 1) : cardNo.Substring(16, 1)).ConvertToInt(null);
            if (gender == null)
            {
                return null;
            }

            return gender % 2 == 0 ? (int)Gender.Girl : (int)Gender.Boy;
        }

        #endregion

        #region 得到生肖

        /// <summary>
        /// 得到生肖
        /// </summary>
        /// <param name="cardNo">身份证号</param>
        /// <returns></returns>
        public int? GetConstellation(string cardNo)
        {
            if (IsIdCard(cardNo))
            {
                if (!cardNo.IsNullOrWhiteSpace())
                {
                    var constellation = GetBirthday(cardNo).GetConstellationFromBirthday();
                    if (constellation != null)
                    {
                        return (int)constellation;
                    }
                }
            }

            return null;
        }

        #endregion
    }
}
