using CK.SqlServer;
using Dapper;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

using static CK.Testing.DBSetupTestHelper;

namespace SES.Data.Tests
{
    [TestFixture]
    public class StatementLevelTableTests
    {
        private const int systemId = 1;

        internal class ExtendedStdStatementLevelInfo : StdStatementLevelInfo
        {
            internal ExtendedStdStatementLevelInfo(int sLId, Level lvl)
            {
                StatementLevelId = sLId;
                Level = lvl;
            }

            internal ExtendedStdStatementLevelInfo(Level lvl) => Level = lvl;
        }

        [Test]
        public async Task CreateStatementLevel_withAdmissibleArguments_shouldNotThrowException_and_shouldCreateForesaidStatementLevel()
        {
            using (var ctx = new SqlStandardCallContext())
            {
                var sLTable = CK.Core.StObjModelExtension.Obtain<StatementLevelTable>(TestHelper.StObjMap.StObjs);

                // #1. Checks if a Statement Level already exists with the random SLevel Code.
                // If NOT, moves on. ELSE, repeat generation until objective is complete.
                var rdCode = await GenerateAvailableStatementLevelCode(ctx, sLTable);

                // #2. Creates the Statement Level object that is next going to be inserted in database.
                // Remarks: rdCode imitates an easily readable Level enum.
                var stObj = new ExtendedStdStatementLevelInfo((Level)rdCode);

                // #3. Inserting the Statement Level object in database should not present issues.
                Func<Task> act = async () => await sLTable.CreateStatementLevelAsync(ctx, systemId, stObj.Level);
                act.Should().NotThrow<SqlDetailedException>();

                // #4. Back to step 1.
                stObj.Level = (Level)await GenerateAvailableStatementLevelCode(ctx, sLTable);

                // #5. Inserts the aforesaid object and asserts that its id is greater than 1.
                var sLId = await sLTable.CreateStatementLevelAsync(ctx, systemId, stObj.Level);
                Assert.That(sLId, Is.GreaterThan(1));
            }
        }

        [Test]
        public async Task CreateStatementLevel_whenAlreadyExistingStatementLevelCode_shouldThrowSqlDetailedException()
        {
            using (var ctx = new SqlStandardCallContext())
            {
                var sLTable = CK.Core.StObjModelExtension.Obtain<StatementLevelTable>(TestHelper.StObjMap.StObjs);

                // #1. Prepares the function that is going to throw the SQLDetailedException.
                Func<Task> act = async () => await sLTable.CreateStatementLevelAsync(ctx, systemId, 0);

                // #2. Retrieves a supposed already-existing Statement Level object.
                // If does NOT exist, creates & insert a new one in database to next throw an
                // Exception by trying to re-insert it. ELSE, just tries to insert it in db.
                var stObj = await ctx[sLTable].Connection.QueryFirstOrDefaultAsync<StdStatementLevelInfo>
                    ("select * from SES.tStatementLevel where [Level] = 0;");
                if (stObj == null) await sLTable.CreateStatementLevelAsync(ctx, systemId, 0);

                // #3. Inserting the foresaid Statement Level Object should throw an SQLDetailedException.
                act.Should().Throw<SqlDetailedException>();
            }
        }

        [Test]
        public async Task DeleteStatementLevel_whenAlreadyExistingStatementLevel_shouldNotThrowException_and_shouldDeleteForesaidStatementLevel()
        {
            using (var ctx = new SqlStandardCallContext())
            {
                var sLTable = CK.Core.StObjModelExtension.Obtain<StatementLevelTable>(TestHelper.StObjMap.StObjs);

                // #1. Creates the Statement Level object and then inserts it in database.
                var sLId = await sLTable.CreateStatementLevelAsync(ctx, systemId, (Level) await GenerateAvailableStatementLevelCode(ctx, sLTable));

                // #2. Deleting the foresaid Statement Level object should not present issues.
                Func<Task> act = async () => await sLTable.DeleteStatementLevelAsync(ctx, systemId, sLId);
                act.Should().NotThrow<SqlDetailedException>();

                // #3. Asserts that deletion process has been successful.
                var stdObj = await ctx[sLTable].Connection.QueryFirstOrDefaultAsync<StdStatementLevelInfo>
                    ("select * from SES.tStatementLevel where StatementLevelId = @id;", new { id = sLId });
                Assert.That(stdObj, Is.Null);
            }
        }

        private async Task<int> GenerateAvailableStatementLevelCode(ISqlCallContext ctx, StatementLevelTable sLTable, int tried = 0)
        {
            var random = new Random();
            var rdCode = random.Next();
            while (rdCode == tried) random.Next();

            var exists = await ctx[sLTable].Connection.QueryFirstOrDefaultAsync<int>
                ("select StatementLevelId from SES.tStatementLevel where [Level] = @lv;", new { lv = rdCode });
            return (exists != 0) ? await GenerateAvailableStatementLevelCode(ctx, sLTable, exists) : rdCode;
        }
    }
}
