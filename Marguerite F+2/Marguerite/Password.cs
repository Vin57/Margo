using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marguerite
{
    class Password
    {
        private int id_password;
        private string password;
        private List<string> lesIndication = new List<string>();

        public int GetIdPassword
        {
            get
            {
                return id_password;
            }
        }

        public string GetPassword
        {
            get
            {
                return password;
            }
        }

        public List<string> GetLesIndication
        {
            get
            {
                return lesIndication;
            }
            set
            {
                lesIndication = value;
            }
        }

        public Password(int pId_Password,string pPassword)
        {
            id_password = pId_Password;
            password = pPassword;
        }


    }
}
