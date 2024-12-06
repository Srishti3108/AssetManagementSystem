using AssetManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem.Repositories
{
    public class AssetAuditServices : IAssetAuditService
    {
        private assetManagementContext _context;
        public AssetAuditServices(assetManagementContext context) {
            _context = context;

        }
       public int AddNewAssetAudit(AssetAudit AssetAudit)
        {
            try
            {
                if (AssetAudit != null)
                {
                    _context.AssetAudits.Add(AssetAudit);
                    _context.SaveChanges();
                    return AssetAudit.AuditId;
                }
                else return 0;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string DeleteAssetAudit(int id)
        {
            if (id != null)
            {
                var assetaudit = _context.AssetAudits.FirstOrDefault(x => x.AuditId == id);
                if (assetaudit != null)
                {
                    _context.AssetAudits.Remove(assetaudit);
                    _context.SaveChanges();
                    return "The given Asset Audit id " + id + "Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";

        }

        public List<AssetAudit> GetAllAssetAudits()
        {
            var assetaudit = _context.AssetAudits.ToList();
            if (assetaudit.Count > 0)
            { return assetaudit; }
            else
                return null;
        }

       public AssetAudit GetAssetAuditById(int id)
        {
            if (id != 0 || id != null)
            {
                var assetaudit = _context.AssetAudits.FirstOrDefault(x => x.AuditId == id);
                if (assetaudit != null)
                    return assetaudit;
                else
                    return null;
            }
            return null;
        }

        public string UpdateAssetAudit(AssetAudit AssetAudit)
        {
            var existingAssetAudit = _context.AssetAudits.FirstOrDefault(x => x.AuditId == AssetAudit.AuditId);
            if (existingAssetAudit != null)
            {
                existingAssetAudit.AssetId = AssetAudit.AssetId;
                existingAssetAudit.EmployeeId = AssetAudit.EmployeeId;
                existingAssetAudit.AuditDate = AssetAudit.AuditDate;
                existingAssetAudit.Status = AssetAudit.Status;
                
                
                _context.Entry(existingAssetAudit).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
