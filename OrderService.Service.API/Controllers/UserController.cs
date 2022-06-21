using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using OrderService.Service.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
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
        public async Task<ActionResult<CreateUserViewModel>> Post([FromBody] CreateUserViewModel user)
        {
            return Ok(await userService.CreateUser(mapper.Map<User>(user)));
        }

        [HttpPost("/Admin")]
        public async Task<ActionResult<CreateUserViewModel>> AdminPost([FromBody] CreateUserViewModel user)
        {
            return Ok(await userService.AdminCreateUser(mapper.Map<User>(user)));
        }

    }
}