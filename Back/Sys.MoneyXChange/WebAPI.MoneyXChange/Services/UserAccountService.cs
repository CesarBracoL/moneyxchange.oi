using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using WebAPI.MoneyXChange.Models;
using WebAPI.MoneyXChange.Services.Contracts;

namespace WebAPI.MoneyXChange.Services
{
    public class UserAccountService : IUserAccountService
    {
        private StoreDBContext _context;

        public UserAccountService(StoreDBContext context)
        {
            _context = context;
        }

        public bool Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            var user = _context.UserAccount.SingleOrDefault(x => x.UsaUsername == username);

            // check if username exists
            if (user == null)
                return false;

            MD5 md5Hash = MD5.Create(); 

            if (VerifyMd5Hash(md5Hash, password,user.UsaPassword))
                return true;

            // authentication successful
            return false;
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            
            string hashOfInput = GetMd5Hash(md5Hash, input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
