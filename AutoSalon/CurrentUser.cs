using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSalon
{
    public class CurrentUser
    {
        public static int id_users;
        public static String login;
        public static String password;
        public static String roles;
        public static String passwordbd;

        public static void set(int id_usersS, String loginS, String passwordS, String rolesS, String passwordbdS)
        {
            id_users = id_usersS;
            login = loginS;
            password = passwordS;
            roles = rolesS;
            passwordbd = passwordbdS;
        }
    }
}
