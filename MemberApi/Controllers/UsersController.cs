//using MemberApi.Data;
//using MemberApi.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace MemberApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private UserDbContext _context;

//        public UsersController(UserDbContext context)
//        {
//            _context = context;
//        }
        
//        [HttpGet]
//        public IActionResult GetUsers()
//        {
//            return Ok(_context.User);
//        }

//        [HttpPost]
//        public async Task <IActionResult> CreateUser(User user)
//        {
//            _context.User.Add(user);
//            await  _context.SaveChangesAsync();
//            return Ok(user);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateUser(int id,  User user)
//        {
//            if (id != user.Id)
//            {
//                return BadRequest();
//            }
            
//            var oldUser = _context.User.Find(user.Id);

//            if (oldUser == null)
//            {
//                return NotFound();
//            }

//            oldUser.Name = user.Name;
//            await  _context.SaveChangesAsync();
//            return Ok(oldUser);
//        }

//        [HttpDelete("{id}")]
//        public async Task <IActionResult> DeleteUser(int id)
//        {
//            var user = _context.User.Find( id);

//            if (user == null)
//            {
//                return NotFound();
//            }

//            _context.User.Remove(user);
//            await _context.SaveChangesAsync();
//            return Ok(user);
//            // return NoContent();
//        }
//    }
//}
