using MemberApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemberApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StoreController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var stores = await _context.Stores
                .Select(x => new
                {
                    storeName = x.StoreName,
                    address = x.Address
                })
                .Distinct()
                .ToListAsync();

            return Ok(stores);
        }
    }
}
