using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        //GET ALL

        [HttpGet]
        public async Task<ActionResult<ICollection<User>>> Get()
        {
            return Ok(await userService.GetAllUsers());
        }

        //GET BY EMAIL

        [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetByEmail(string email)
        {
            return Ok(await userService.GetUserByEmail(email));
        }

        //POST

        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            return Ok(userService.CreateUser(user));
        }

    }
}