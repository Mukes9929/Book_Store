﻿using BookStore.Model.Modelview;
using BookStore.Models.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/Bookstore")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        UserRepository _repository = new UserRepository();

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {
            User user = _repository.Login(model);
            if (user == null)
                return NotFound();

            UserModel userModel = new UserModel(user);
            return Ok(userModel);
        }

        [HttpPost]
        [Route("registerUser")]
        public IActionResult Register(RegisterModel model)
        {
            User user = _repository.Register(model);
            UserModel userModel = new UserModel(user);
            return Ok(userModel);
        }
    }
}
