using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace LoginSystem
{
    public class DataAccess
    {
        public static bool persistUser(string fnm, string lnm, string eml, string pwd, string salt) 
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spRegisterUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@firstname", fnm);
                cmd.Parameters.AddWithValue("@lastname", lnm);
                cmd.Parameters.AddWithValue("@email", eml);
                cmd.Parameters.AddWithValue("@pword", pwd);
                cmd.Parameters.AddWithValue("@salt", salt);

                con.Open();
                cmd.ExecuteNonQuery();
                return true; 
            }
        }

        public static Tuple<string, string> AuthenticateUser(string unmentered, string pwdentered)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAuthUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@email", unmentered);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new Tuple<string, string>(reader.GetString(0), reader.GetString(1));
                    }
                }
                else
                {                    
                    return new Tuple<string, string>("No Item", "Was Found");
                }
                reader.Close();
                return null;                       
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
        public bool matchPasswords(string enteredPassword, string dbPassword, string saltfromdb)
        {
            string dbPasswordInHex = generateSHA256Hash(enteredPassword, saltfromdb);
            if (enteredPassword.Equals(dbPasswordInHex))
                return true;
            else
                return false;
        }
    }
}