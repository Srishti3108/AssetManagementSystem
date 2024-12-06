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
    public class AssetBorrowingsController : ControllerBase
    {
        private readonly IAssetBorrowingService _service;
        public AssetBorrowingsController(IAssetBorrowingService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAllAssetBorrowing()
        {
            List<AssetBorrowing> assetborrowing = _service.GetAllAssetBorrowing();
            return Ok(assetborrowing);
        }
        /* [HttpGet("{id:int}")]
         public IActionResult GetAssetBorrowingById(int id)
         {
             AssetBorrowing assetborrowing = _service.GetAssetBorrowingById(id);
             return Ok(assetborrowing);
         }*/
        [HttpGet("borrowings")]
        public IActionResult GetAllBorrowings()
        {
            try
            {
                var borrowings = _service.GetAllBorrowings();
                return Ok(borrowings);
            }
            catch (Exception e)
            {
                return BadRequest(new { Message = e.Message });
            }
        }

        [HttpPost]
        public IActionResult PostAssetBorrowing(AssetBorrowing assetborrowing)
        {
            int Result = _service.AddNewAssetBorrowing(assetborrowing);
            return Ok(Result);
        }
        [HttpPut]
        public IActionResult PutAssetBorrowing(AssetBorrowing assetborrowing)
        {
            string result = _service.UpdateAssetBorrowing(assetborrowing);
            return Ok(result);
        }

        /*[HttpDelete]
        public IActionResult DeleteAssetBorrowing(int id)
        {
            string result = _service.DeleteAssetBorrowing(id);
            return Ok(result);
        }*/
    }
}
