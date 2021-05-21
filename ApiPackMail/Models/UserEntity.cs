using System;
namespace ApiPackMail.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }


        public UserEntity()
        {


        }
    }
}
