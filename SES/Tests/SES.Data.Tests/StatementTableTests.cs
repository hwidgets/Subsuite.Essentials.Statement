using CK.SqlServer;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

using static CK.Testing.DBSetupTestHelper;

namespace SES.Data.Tests
{
    [TestFixture]
    public class StatementTableTests
    {
        private const int systemId = 1;

        internal class ExtendedStdStatementInfo : StdStatementInfo
        {
            internal ExtendedStdStatementInfo(int sId, Level lvl,
                int langCode, int status)
            {
                StatementId = sId;
                Level = lvl;
                LanguageCode = langCode;
                Status = status;
            }

            internal ExtendedStdStatementInfo(Level lvl, int langCode, int status)
            {
                Level = lvl;
                LanguageCode = langCode;
                Status = status;
            }
        }

        [Test]
        public async Task CreateStatement_withAdmissibleArguments_shouldNotThrowException_and_shouldCreateForesaidStatement()
        {
            using (var ctx = new SqlStandardCallContext())
            {
                var sTable = CK.Core.StObjModelExtension.Obtain<StatementTable>(TestHelper.StObjMap.StObjs);

                // #1. Creates the Statement object that is next going to be inserted in database.
                var stObj = new ExtendedStdStatementInfo(Level.Info, 0, 0);

                // #3. Inserting the Statement object in database should not present issues.
                Func<Task> act = async () => await sTable.CreateStatementAsync(ctx, systemId, stObj.Level, stObj.LanguageCode, stObj.Status, string.Empty);
                act.Should().NotThrow<SqlDetailedException>();

                // #4. Inserts the aforesaid object and asserts that its id is greater than 1.
                var sId = await sTable.CreateStatementAsync(ctx, systemId, stObj.Level, stObj.LanguageCode, stObj.Status, string.Empty);
                Assert.That(sId, Is.GreaterThan(1));
            }
        }
    }
}
