using AssetManagementSystem.Models;

namespace AssetManagementSystem.Repositories
{
    public class AssetServiceRequestServices : IAssetServiceRequestService
    {
        private assetManagementContext _context;
        public AssetServiceRequestServices(assetManagementContext context)
        {
            _context = context;
        }
      public  int AddNewAssetServiceRequest(AssetServiceRequest AssetServiceRequest)
        {
            try
            {
                if (AssetServiceRequest != null)
                {
                    _context.AssetServiceRequests.Add(AssetServiceRequest);
                    _context.SaveChanges();
                    return AssetServiceRequest.RequestId;
                }
                else return 0;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public string DeleteAssetServiceRequest(int id)
        {
            if (id != null)
            {
                var assetservicerequest = _context.AssetServiceRequests.FirstOrDefault(x => x.RequestId == id);
                if (assetservicerequest != null)
                {
                    _context.AssetServiceRequests.Remove(assetservicerequest);
                    _context.SaveChanges();
                    return "The given Assetservicerequest id " + id + "Removed";
                }
                else
                    return "Something went wrong with deletion";

            }
            return "Id should not be null or zero";
        }

        public List<AssetServiceRequest> GetAllAssetServiceRequest()
        {

            var assetservicerequest = _context.AssetServiceRequests.ToList();
            if (assetservicerequest.Count > 0)
            { return assetservicerequest; }
            else
                return null;
        }

        public AssetServiceRequest GetAssetServiceRequestById(int id)
        {
            if (id != 0 || id != null)
            {
                var assetservicerequest = _context.AssetServiceRequests.FirstOrDefault(x => x.RequestId == id);
                if (assetservicerequest != null)
                    return assetservicerequest;
                else
                    return null;
            }
            return null;
        }

       public string UpdateAssetServiceRequest(AssetServiceRequest AssetServiceRequest)
        {
            var existingassetservicerequest = _context.AssetServiceRequests.FirstOrDefault(x => x.RequestId == AssetServiceRequest.RequestId);
            if (existingassetservicerequest != null)
            {
                existingassetservicerequest.AssetId = AssetServiceRequest.AssetId;
                existingassetservicerequest.EmployeeId = AssetServiceRequest.EmployeeId;
                existingassetservicerequest.IssueType = AssetServiceRequest.IssueType;
                existingassetservicerequest.Description = AssetServiceRequest.Description;
                existingassetservicerequest.RequestDate = AssetServiceRequest.RequestDate;
                existingassetservicerequest.Status = AssetServiceRequest.Status;
                
                _context.Entry(existingassetservicerequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

