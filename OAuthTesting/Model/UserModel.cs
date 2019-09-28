using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OAuthTesting.Model
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(30)")][MaxLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "varchar(20)")][MaxLength(20)][Required]
        public string Username { get; set; }
        
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Password { get; set; }
    }
}
