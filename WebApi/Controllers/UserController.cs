using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
      
        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<UserModel>> Get()
        {
            return await _userService.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UserModel> Get(string id)
        {
            return await _userService.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<UserModel> Post([FromBody] UserModel user)
        {
            return await _userService.Add(user);
        }
     
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<UserModel> Put([FromBody] UserModel user)
        {
            return await _userService.Update(new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserId = user.UserId,
                Gender = user.Gender,
                HMO = user.HMO,
                DOB = user.DOB,
                Children = user.Children
            });
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _userService.Delete(id);
        }
    }
}
