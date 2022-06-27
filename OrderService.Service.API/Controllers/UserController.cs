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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateUserViewModel>>> Get()
        {
            var users = mapper.Map<IEnumerable<User>>(await userService.GetAllUsers());
            return Ok(users);
        }

        [HttpGet("{id}", Name ="GetUser")]
        public async Task<ActionResult<CreateUserViewModel>> GetById(Guid id)
        {
            var users = mapper.Map<User>(await userService.GetById(id));
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserViewModel>> Post([FromBody]CreateUserViewModel user)
        {
            var users = mapper.Map<User>(user);
            var userById = await userService.CreateUser(users);
            return new CreatedAtRouteResult("GetUser", new {id = users.id}, userById);
        }

        [HttpPost("/Admin")]
        public async Task<ActionResult<CreateUserViewModel>> AdminPost([FromBody] CreateUserViewModel user)
        {
            var users = mapper.Map<User>(user);
            var userById = await userService.AdminCreateUser(users);
            return new CreatedAtRouteResult("GetUser", new { id = users.id }, userById);
        }

    }
}