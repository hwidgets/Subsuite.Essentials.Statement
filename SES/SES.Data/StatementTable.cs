using CK.Core;
using CK.SqlServer;
using System.Threading.Tasks;

namespace SES.Data
{
    /// <summary>
    /// This table centralizes every single <see cref="IStatementInfo"/>.
    /// </summary>
    [SqlTable("tStatement", Package = typeof(Package))]
    [Versions("1.0.0")]
    public abstract class StatementTable : SqlTable
    {
        void StObjConstruct(StatementLevelTable sLTbl, SEC.Data.CultureTable cTbl)
        {
        }

        /// <summary>
        /// Creates a new <see cref="IStatementInfo"/>.
        /// </summary>
        /// <param name="ctx">Current <see cref="ISqlCallContext"/>.</param>
        /// <param name="actorId">Creator's id.</param>
        /// <param name="level">See <see cref="IStatementInfo.Level"/>.</param>
        /// <param name="languageCode">See <see cref="IStatementInfo.LanguageCode"/>.</param>
        /// <param name="status">See <see cref="IStatementInfo.Status"/>.</param>
        /// <param name="text">See <see cref="IStatementInfo.Text"/></param>
        /// <returns>An <see cref="int"/> which is the created-element id.</returns>
        [SqlProcedure("sStatementCreate")]
        public abstract Task<int> CreateStatementAsync(
            ISqlCallContext ctx,
            int actorId,
            Level level,
            int languageCode,
            int status,
            string text
        );

        /// <summary>
        /// Deletes an <see cref="IStatementInfo"/>.
        /// </summary>
        /// <remarks>
        /// This procedure should be used with extreme caution. One must not
        /// delete any already-used statement <see cref="Level"/>.
        /// </remarks>
        /// <param name="ctx">Current <see cref="ISqlCallContext"/>.</param>
        /// <param name="actorId">Deletor's id.</param>
        /// <param name="statementId">See <see cref="IStatementInfo.StatementId"/>.</param>
        /// <returns>A <see cref="bool"/> which is the deletion result.</returns>
        [SqlProcedure("sStatementDelete")]
        public abstract Task<bool> DeleteStatementAsync(
            ISqlCallContext ctx,
            int actorId,
            int statementId
        );

        /// <summary>
        /// Updates an <see cref="IStatementInfo"/>.
        /// </summary>
        /// <param name="ctx">Current <see cref="ISqlCallContext"/>.</param>
        /// <param name="actorId">Updator's id.</param>
        /// <param name="statementId">Target's id.</param>
        /// <param name="status">Target's wanted new status code.</param>
        /// <param name="text">Target's wanted new text.</param>
        /// <returns>A <see cref="bool"/> which indicates that at least one update has been made or not.</returns>
        [SqlProcedure("sStatementUpdate")]
        public abstract Task<bool> UpdateStatementAsync(
            ISqlCallContext ctx,
            int actorId,
            int statementId,
            string text,
            int? status
        );
    }
}
