namespace SES.Data
{
    /// <summary>
    /// Defines what a « statement level » is.
    /// </summary>
    public interface IStatementLevelInfo
    {
        /// <summary>
        /// Statement Level database identifier (primary key).
        /// </summary>
        int StatementLevelId { get; set; }

        /// <summary>
        /// See <see cref="IStatementInfo.Level"/>.
        /// </summary>
        Level Level { get; set; }
    }
}
