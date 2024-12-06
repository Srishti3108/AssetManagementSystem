using AssetManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Repositories
{
    public class AssetBorrowingServices : IAssetBorrowingService
    {
        private assetManagementContext _context;
        public AssetBorrowingServices(assetManagementContext context)
        {
            _context = context;
        }

        public int AddNewAssetBorrowing(AssetBorrowing AssetBorrowing)
        {
            try
            {
                if (AssetBorrowing != null)
                {
                    _context.AssetBorrowings.Add(AssetBorrowing);
                    _context.SaveChanges();
                    return AssetBorrowing.BorrowId;
                }
                else return 0;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public List<AssetBorrowing> GetAllBorrowings()
        {
            var borrowings = _context.AssetBorrowings
                .Include(b => b.Asset) // Includes the related asset details
                .Include(b => b.Employee) // Includes the related employee details
                .ToList();

            return borrowings;
        }

        public string DeleteAssetBorrowing(int id)
        {
            if (id != null)
            {
                var AssetBorrowing = _context.AssetBorrowings.FirstOrDefault(x => x.BorrowId == id);
                if (AssetBorrowing != null)
                {
                    _context.AssetBorrowings.Remove(AssetBorrowing);
                    _context.SaveChanges();
                    return "The given AssetBorrowing id " + id + "Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";
        }

         public  List<AssetBorrowing> GetAllAssetBorrowing()
        {
            var assetborrowing = _context.AssetBorrowings.ToList();
            if (assetborrowing.Count > 0)
            { return assetborrowing; }
            else
                return null;
        }

        public AssetBorrowing GetAssetBorrowingById(int id)
        {
            if (id != 0 || id != null)
            {
                var assetborrowing = _context.AssetBorrowings.FirstOrDefault(x => x.BorrowId == id);
                if (assetborrowing != null)
                    return assetborrowing;
                else
                    return null;
            }
            return null;

        }

        public string UpdateAssetBorrowing(AssetBorrowing AssetBorrowing)
        {
            var existingAssetBorrowing = _context.AssetBorrowings.FirstOrDefault(x => x.BorrowId == AssetBorrowing.BorrowId);
            if (existingAssetBorrowing != null)
            {
                existingAssetBorrowing.EmployeeId = AssetBorrowing.EmployeeId;
                existingAssetBorrowing.AssetId = AssetBorrowing.AssetId;
                existingAssetBorrowing.BorrowDate = AssetBorrowing.BorrowDate;
                existingAssetBorrowing.ReturnDate = AssetBorrowing.ReturnDate;
                existingAssetBorrowing.Status = AssetBorrowing.Status;
                
                _context.Entry(existingAssetBorrowing).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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