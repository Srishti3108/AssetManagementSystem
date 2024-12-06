using AssetManagementSystem.Models;

namespace AssetManagementSystem.Repositories
{
    public interface IAssetService
    {
        List<Asset> GetAllAsset();
        Asset GetAssetById(int id);
        int AddNewAsset(Asset Asset);
        string UpdateAsset(Asset Asset);
        string DeleteAsset(int id);
        List<Asset> SearchByName(string name);

    }
}
