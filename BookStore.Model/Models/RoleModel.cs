using BookStore.Model.Modelview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Model.Models
{
    public class RoleModel

    {
        public RoleModel() { }

        public RoleModel(Role role)
        {
            Id = role.Id;
            Name = role.Name;
            Users = role.Users;
           
        }
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
