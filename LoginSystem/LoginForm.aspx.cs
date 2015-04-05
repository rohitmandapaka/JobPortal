using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using JobPortal;

namespace LoginSystem
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string uname = tbxuname.Text;
            string pword = tbxpwd.Text;

            Tuple<string, string> result =DataAccess.AuthenticateUser(uname, pword);
            string enteredHashedPwd = generateSHA256Hash(pword, result.Item2);
            if (enteredHashedPwd.Equals(result.Item1))
            {
                Session["unm"] = uname;
                Response.Redirect("~/Default.aspx");
                
            }
            else
            {
                Response.Write("Login Failed");
            }

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
            return hex.Replace("-", "");
        }
    }
}