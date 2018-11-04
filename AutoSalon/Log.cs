using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalon
{
    public class Roles
    {
        public int id_users { set; get; }
        public String login { set; get; }
        public String password { set; get; }
        public String roles { set; get; }
        public String passwordbd { set; get; }

        public Roles(int id_users, String login, String password, String roles, String passwordbd)
        {
            this.id_users = id_users;
            this.login = login;
            this.password = password;
            this.roles = roles;
            this.passwordbd = passwordbd;
        }
    }
}
