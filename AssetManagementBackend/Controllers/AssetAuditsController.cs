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
    public class AssetAuditsController : ControllerBase
    {
        private readonly IAssetAuditService _service;
        public AssetAuditsController(IAssetAuditService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAllAssetAudit()
        {
            List<AssetAudit> assetaudit = _service.GetAllAssetAudits();
            return Ok(assetaudit);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetAssetAuditById(int id)
        {
            AssetAudit assetaudit = _service.GetAssetAuditById(id);
            return Ok(assetaudit);
        }
        [HttpPost]
        public IActionResult PostAssetAudit(AssetAudit assetaudit)
        {
            int Result = _service.AddNewAssetAudit(assetaudit);
            return Ok(Result);
        }
        [HttpPut]
        public IActionResult PutAssetAudit(AssetAudit assetaudit)
        {
            string result = _service.UpdateAssetAudit(assetaudit);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteAssetAudit(int id)
        {
            string result = _service.DeleteAssetAudit(id);
            return Ok(result);
        }
    }
}
