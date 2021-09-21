// Copyright (c) zhenlei520 All rights reserved.

namespace Wolf.Systems.Data.Enumerations
{
    /// <summary>
    ///
    /// </summary>
    public class SequentialGuidType : Wolf.Systems.Enumerations.SequentialGuidType
    {
        /// <summary>
        /// Used by MySql and PostgreSql.
        /// </summary>
        public static SequentialGuidType SequentialAsString = new SequentialGuidType(2, "Used by MySql and PostgreSql.");

        /// <summary>
        /// Used by Oracle.
        /// </summary>
        public static SequentialGuidType SequentialAsBinary = new SequentialGuidType(3, "Used by Oracle.");

        /// <summary>
        /// Used by SqlServer.
        /// </summary>
        public static SequentialGuidType SequentialAtEnd = new SequentialGuidType(4, "Used by SqlServer.");

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        protected SequentialGuidType(int id, string name) : base(id, name)
        {
        }
    }
}
