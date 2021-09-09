namespace Wolf.Systems.Enum
{
    /// <summary>
    ///
    /// </summary>
    public enum SequentialGuidType2
    {
        /// <summary>
        /// The GUID should be sequential when formatted using the <see cref="Guid.ToString()" /> method.
        /// Used by MySql and PostgreSql.
        /// </summary>
        [Description("Used by MySql and PostgreSql.")]
        SequentialAsString = 1,

        /// <summary>
        /// The GUID should be sequential when formatted using the <see cref="Guid.ToByteArray" /> method.
        /// Used by Oracle.
        /// </summary>
        [Description("Used by Oracle.")] SequentialAsBinary = 2,

        /// <summary>
        /// The sequential portion of the GUID should be located at the end of the Data4 block.
        /// Used by SqlServer.
        /// </summary>
        [Description("Used by SqlServer.")] SequentialAtEnd = 3,

        /// <summary>
        /// Default Guid
        /// </summary>
        [Description("Guid")] Guid = 4
    }
}
