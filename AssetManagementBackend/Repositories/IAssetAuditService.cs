using AssetManagementSystem.Models;

namespace AssetManagementSystem.Repositories
{
    public interface IAssetAuditService
    {
        List<AssetAudit> GetAllAssetAudits();
        AssetAudit GetAssetAuditById(int id);
        int AddNewAssetAudit(AssetAudit AssetAudit);
        string UpdateAssetAudit(AssetAudit AssetAudit);
        string DeleteAssetAudit(int id);
       

    }
}
