using AssetManagementSystem.Models;
using AssetManagementSystem.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
    [EnableCors("Policy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AssetServiceRequestsController : ControllerBase
    {
        private readonly IAssetServiceRequestService _service;
        public AssetServiceRequestsController(IAssetServiceRequestService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAllAssetService()
        {
            List<AssetServiceRequest> assetservicerequests = _service.GetAllAssetServiceRequest();
            return Ok(assetservicerequests);
        }
        /*[HttpGet("{id:int}")]
        public IActionResult GetAssetServiceRequestById(int id)
        {
            AssetServiceRequest assetservicerequest = _service.GetAssetServiceRequestById(id);
            return Ok(assetservicerequest);
        }*/
        [HttpPost]
        public IActionResult PostAssetService(AssetServiceRequest assetservicerequest)
        {
            int Result = _service.AddNewAssetServiceRequest(assetservicerequest);
            return Ok(Result);
        }
        [HttpPut]
        public IActionResult PutAssetService(AssetServiceRequest assetServiceRequest)
        {
            string result = _service.UpdateAssetServiceRequest(assetServiceRequest);
            return Ok(result);
        }

       /* [HttpDelete]
        public IActionResult DeleteAssetService(int id)
        {
            string result = _service.DeleteAssetServiceRequest(id);
            return Ok(result);
        }*/
    }
}
