using CK.Core;

namespace SES.Data
{
    [SqlPackage(
    ResourcePath = "Resources",
    Schema = "SES",
    Database = typeof(SqlDefaultDatabase),
    ResourceType = typeof(Package)),
    Versions("1.0.0")]
    public abstract class Package : SqlPackage
    {
        void StObjConstruct(SEC.Data.Package cPckg)
        {
        }
    }
}
