﻿using BookStore.Model.Modelview;
using BookStore.Models.Models;

namespace BookStore.Models.Models
{
    public class UserModel
    {
        public UserModel() { }

        public UserModel(User user)
        {
            Id = user.Id;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Email = user.Email;
            RoleId = user.Roleid;
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
