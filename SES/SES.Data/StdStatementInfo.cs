using System.Collections.Generic;

namespace SES.Data
{
    /// <summary>
    /// Standard implementation of <see cref="IStatementInfo"/>.
    /// </summary>
    public class StdStatementInfo : IStatementInfo
    {
        /// <summary>
        /// See <see cref="IStatementInfo.StatementId"/>.
        /// </summary>
        public int StatementId { get; set; }

        /// <summary>
        /// See <see cref="IStatementInfo.Level"/>.
        /// </summary>
        public Level Level { get; set; }

        /// <summary>
        /// See <see cref="IStatementInfo.LanguageCode"/>.
        /// </summary>
        public int LanguageCode { get; set; }

        /// <summary>
        /// See <see cref="IStatementInfo.Status"/>.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// See <see cref="IStatementInfo.Agents"/>.
        /// </summary>
        public object Agents { get; set; }

        /// <summary>
        /// See <see cref="IStatementInfo.Result"/>.
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        /// See <see cref="IStatementInfo.Text"/>.
        /// </summary>
        public string Text { get; set; }
    }
}
