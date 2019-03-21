using System.Collections.Generic;

namespace SES.Data
{
    /// <summary>
    /// Defines what a « statement » is.
    /// </summary>
    public interface IStatementInfo
    {
        /// <summary>
        /// Statement database identifier (primary key).
        /// </summary>
        int StatementId { get; set; }

        /// <summary>
        /// See <see cref="SES.Data.Level"/>.
        /// </summary>
        Level Level { get; set; }

        /// <summary>
        /// Culture <see cref="SEC.Data.ICultureInfo.LanguageCode"/>, or what
        /// truly identifies the unique <see cref="SEC.Data.ICultureInfo"/>.
        /// </summary>
        int LanguageCode { get; set; }

        /// <summary>
        /// Statement status, or what truly identifies
        /// the unique <see cref="IStatementInfo"/>.
        /// </summary>
        int Status { get; set; }

        /// <summary>
        /// Statement agents, or what caused the statement
        /// during the operation : agents are the cause when
        /// statement is the consequence. Can be single or
        /// multiple.
        /// </summary>
        IEnumerable<object> Agents { get; set; }

        /// <summary>
        /// Statement result, or what has been successfully
        /// obtained after operation.
        /// </summary>
        object Result { get; set; }

        /// <summary>
        /// Statement message.
        /// </summary>
        string Text { get; set; }
    }
}
