using System.Security.Cryptography;
using System.Text;
using PizzaBox.Domain.Models;

namespace PizzaBox.Logic
{
    public class Mapper
    {
        public Customer CustomerMapper(RawCustomer obj)
        {
            using (var hmac = new HMACSHA512())
            {
                Customer newCustomer = new Customer();

                //newCustomer.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(obj.Password));//this returns a byte[] representing the password
                //newCustomer.PasswordSalt = hmac.Key;     // this assigns the randomly generated Key (comes with the HMAC instance) to the salt variable of the user instance,

                return newCustomer;
            }
        }
    }
}