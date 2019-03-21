namespace SES.Data
{
    /// <summary>
    /// Standard implementation of <see cref="IStatementLevelInfo"/>.
    /// </summary>
    public class StdStatementLevelInfo : IStatementLevelInfo
    {
        /// <summary>
        /// See <see cref="IStatementLevelInfo.StatementLevelId"/>.
        /// </summary>
        public int StatementLevelId { get; set; }

        /// <summary>
        /// See <see cref="IStatementLevelInfo.Level"/>.
        /// </summary>
        public Level Level { get; set; }
    }
}
