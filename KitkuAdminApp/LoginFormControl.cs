using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitkuAdminApp
{
    public class LoginFormControl
    {
        public static LoginForm LoginForm
        {
            get
            {
                if (_mainMenu == null)
                {
                    _mainMenu = new LoginForm();
                }
                return _mainMenu;
            }
        }
        private static LoginForm _mainMenu;
    }
}
