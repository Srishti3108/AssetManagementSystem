using AssetManagementSystem.Models;
using AssetManagementSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{
    [EnableCors("Policy")]
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _service;
        public AssetsController(IAssetService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAllAsset()
        {
            List<Asset> assets = _service.GetAllAsset();
            return Ok(assets);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetAssetById(int id)
        {
            Asset asset = _service.GetAssetById(id);
            return Ok(asset);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateNewAsset( Asset asset)
        {
            int Result = _service.AddNewAsset(asset);
            return Ok(Result);
        }
       // [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateAsset(Asset asset)
        {
            string result = _service.UpdateAsset(asset);
            return Ok(result);
        }
        [HttpGet("search")]
        public IActionResult GetAssetBySearch(string name)
        {
            var asset = _service.SearchByName(name);
            return Ok(asset);
        }
//[Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult DeleteAsset(int id)
        {
            string result = _service.DeleteAsset(id);
            return Ok(result);
        }
    }
}
