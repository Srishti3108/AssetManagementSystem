using AssetManagementSystem.Models;

namespace AssetManagementSystem.Repositories
{
    public interface IAssetServiceRequestService
    {
        List<AssetServiceRequest> GetAllAssetServiceRequest();
        AssetServiceRequest GetAssetServiceRequestById(int id);
        int AddNewAssetServiceRequest(AssetServiceRequest AssetServiceRequest);
        string UpdateAssetServiceRequest(AssetServiceRequest AssetServiceRequest);
        string DeleteAssetServiceRequest(int id);
        
    }
}
