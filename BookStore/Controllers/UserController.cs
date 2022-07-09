using BookStore.Model.Models;
using BookStore.Model.Modelview;
using BookStore.Models.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository _repository = new UserRepository();

        [HttpGet]
        [Route("list")]
        public IActionResult GetUsers(int pageIndex = 1, int pageSize = 10, string? keyword = "")
        {
            ListResponse<User> response = _repository.GetUsers(pageIndex, pageSize, keyword);
            ListResponse<UserModel> users = new ListResponse<UserModel>()
            {
                results = response.results.Select(u => new UserModel(u)),
                totalresults = response.totalresults,
            };

            return Ok(users);
        }

        [HttpGet]
        [Route("Roles")]
        public IActionResult GetRoles()
        {
            ListResponse<Role> roles = _repository.GetRoles();
            ListResponse<RoleModel> Roles = new ListResponse<RoleModel>()
            {
                results = roles.results.Select(c => new RoleModel(c)),
                totalresults = roles.totalresults,
            };
            return Ok(Roles);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(int id)
        {
            User user = _repository.GetUser(id);
            if (user == null)
                return NotFound();

            UserModel userModel = new UserModel(user);
            return Ok(userModel);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateUser(UserModel model)
        {
            if (model != null)
                return BadRequest();

            User user = new User()
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Email = model.Email,
                Roleid = model.RoleId,
            };

            user = _repository.UpdateUser(user);
            return Ok(user);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteUser(int id)
        {
            bool isDeleted = _repository.DeleteUser(id);
            return Ok(isDeleted);
        }
    }
}
