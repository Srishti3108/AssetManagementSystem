using AssetManagementSystem.Models;

namespace AssetManagementSystem.Repositories
{
    public class AssetServices : IAssetService
    {
        private assetManagementContext _context;
        public AssetServices(assetManagementContext context)
        {
            _context = context;
        }

        public int AddNewAsset(Asset Asset)
        {
            try
            {
                if (Asset != null)
                {
                    _context.Assets.Add(Asset);
                    _context.SaveChanges();
                    return Asset.AssetId;
                }
                else return 0;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

       public string DeleteAsset(int id)
        {
            if (id != null)
            {
                var asset = _context.Assets.FirstOrDefault(x => x.AssetId == id);
                if (asset != null)
                {
                    _context.Assets.Remove(asset);
                    _context.SaveChanges();
                    return "The given Asset id " + id + "Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";
        }

       public List<Asset> GetAllAsset()
        {
            var asset = _context.Assets.ToList();
            if (asset.Count > 0)
            { return asset; }
            else
                return null;
        }

       public Asset GetAssetById(int id)
        {
            if (id != 0 || id != null)
            {
                var asset = _context.Assets.FirstOrDefault(x => x.AssetId == id);
                if (asset != null)
                    return asset;
                else
                    return null;
            }
            return null;
        }

        public List<Asset> SearchByName(string name)
        {
            var asset = _context.Assets.Where(x => x.AssetName.Contains(name)).ToList();
            return asset;
        }
      public  string UpdateAsset(Asset Asset)
        {
            var existingAsset = _context.Assets.FirstOrDefault(x => x.AssetId == Asset.AssetId);
            if (existingAsset != null)
            {
                existingAsset.AssetName = Asset.AssetName;
                existingAsset.AssetCategory = Asset.AssetCategory;
                existingAsset.AssetModel = Asset.AssetModel;
                existingAsset.ManufacturingDate = Asset.ManufacturingDate;
                existingAsset.ExpiryDate = Asset.ExpiryDate;
                existingAsset.AssetValue = Asset.AssetValue;
                existingAsset.Status = Asset.Status;
                existingAsset.CreatedAt = Asset.CreatedAt;
                existingAsset.UpdatedAt = Asset.UpdatedAt;
                _context.Entry(existingAsset).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return "Record Updated successfully";
            }
            else
            {
                return "something went wrong while update";
            }
        }
    }
    }
