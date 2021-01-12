using System;

namespace Wolf.Systems.Abstracts
{
    /// <summary>
    /// 身份证帮助类
    /// </summary>
    public interface IIdCardProvider
    {
        /// <summary>
        /// 国家
        /// </summary>
        int Nationality { get; }

        /// <summary>
        /// 是否身份证
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        bool IsIdCard(string cardNo);

        /// <summary>
        /// 得到生肖信息
        /// </summary>
        /// <param name="cardNo">身份证号</param>
        /// <returns></returns>
        int? GetAnimal(string cardNo);

        /// <summary>
        /// 得到生日信息
        /// </summary>
        /// <param name="cardNo">身份证号</param>
        /// <returns></returns>
        DateTime? GetBirthday(string cardNo);

        /// <summary>
        /// 得到性别
        /// </summary>
        /// <param name="cardNo">身份证号</param>
        /// <returns></returns>
        int? GetGender(string cardNo);

        /// <summary>
        /// 得到生肖
        /// </summary>
        /// <param name="cardNo">身份证号</param>
        /// <returns></returns>
        int? GetConstellation(string cardNo);
    }
}
