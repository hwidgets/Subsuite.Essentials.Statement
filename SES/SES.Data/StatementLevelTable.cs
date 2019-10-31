using CK.Core;
using CK.SqlServer;
using System.Threading.Tasks;

namespace SES.Data
{
    /// <summary>
    /// This table centralizes every single <see cref="IStatementLevelInfo"/>.
    /// </summary>
    [SqlTable("tStatementLevel", Package = typeof(Package))]
    [Versions("1.0.0")]
    public abstract class StatementLevelTable : SqlTable
    {
        void StObjConstruct()
        {
        }

        /// <summary>
        /// Creates a new <see cref="IStatementLevelInfo"/>.
        /// </summary>
        /// <param name="ctx">Current <see cref="ISqlCallContext"/>.</param>
        /// <param name="actorId">Creator's id.</param>
        /// <param name="level">See <see cref="IStatementLevelInfo.Level"/>.</param>
        /// <returns>An <see cref="int"/> which is the created-element id.</returns>
        [SqlProcedure("sStatementLevelCreate")]
        public abstract Task<int> CreateStatementLevelAsync(
            ISqlCallContext ctx,
            int actorId,
            Level level
        );

        /// <summary>
        /// Deletes an <see cref="IStatementLevelInfo"/>.
        /// </summary>
        /// <param name="ctx">Current <see cref="ISqlCallContext"/>.</param>
        /// <param name="actorId">Deletor's id.</param>
        /// <param name="statementLevelId"><see cref="IStatementLevelInfo.StatementLevelId"/>.</param>
        /// <returns>A <see cref="bool"/> which is the deletion result.</returns>
        [SqlProcedure("sStatementLevelDelete")]
        public abstract Task<bool> DeleteStatementLevelAsync(
            ISqlCallContext ctx,
            int actorId,
            int statementLevelId
        );
    }
}
