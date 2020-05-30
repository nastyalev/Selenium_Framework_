using System;
using System.Collections.Generic;
using System.Text;

namespace Lab.business_object
{
    class UserName_Password
    {
        public string InputName { get; set; }
        public string InputPassword { get; set; }

        public UserName_Password(string InputName, string InputPassword)
        {
            this.InputName = InputName;
            this.InputPassword = InputPassword;
        }
    }
}
