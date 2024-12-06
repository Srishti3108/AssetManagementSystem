using AssetManagementSystem.Models;

namespace AssetManagementSystem.Repositories
{
    public interface IAssetBorrowingService
    {
        List<AssetBorrowing> GetAllAssetBorrowing();
        AssetBorrowing GetAssetBorrowingById(int id);
        int AddNewAssetBorrowing(AssetBorrowing AssetBorrowing);
        string UpdateAssetBorrowing(AssetBorrowing AssetBorrowing);
        string DeleteAssetBorrowing(int id);
        List<AssetBorrowing> GetAllBorrowings();


    }
}
