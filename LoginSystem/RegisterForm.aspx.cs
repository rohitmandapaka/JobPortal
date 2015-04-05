using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace LoginSystem
{
    public partial class RegisterForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
                string fname = myTI.ToTitleCase(txtboxfname.Text);
                string lname = myTI.ToTitleCase(txtboxlname.Text);
                string email = txtboxemail.Text.ToLower();
                string password = txtboxpwrd.Text;
                string salt = createSalt(5);
                string hashedpwd = generateSHA256Hash(password, salt);               

                bool result = DataAccess.persistUser(fname, lname, email, hashedpwd, salt);
                Response.Write("Registration:" + result.ToString());
            }

        }

        public string createSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff); 
        }
        public string generateSHA256Hash(string input, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed sha256hashstring = new SHA256Managed();
            byte[] hash = sha256hashstring.ComputeHash(bytes);
            return ByteArrayToHexString(hash);
        }

        public string ByteArrayToHexString(byte[] bytes)
        {
            string hex = BitConverter.ToString(bytes);
            return hex.Replace("-","");
        }

        
    }
}