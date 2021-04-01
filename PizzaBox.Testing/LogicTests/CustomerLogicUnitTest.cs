using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Logic;
using PizzaBox.Repository;
using Xunit;

namespace PizzaBox.Testing
{
    public class CustomerLogicUnitTest
    {
        [Fact]
        public void Test_CreateCustomer()
        {
            var options = new DbContextOptionsBuilder<CustomerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb25")
            .Options;
            
            using(var context = new CustomerContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                CustomerRepository custRepo = new CustomerRepository(context);
                CustomerLogic cl = new CustomerLogic(custRepo);

                RawCustomer rCust = new RawCustomer();
                rCust.Email = "test@email.com";
                rCust.Fname = "Testing";
                rCust.Lname = "Test";
                rCust.Password = "BigTest";

                Customer newCust = cl.CreateCustomer(rCust);
                
                Assert.Equal(rCust.Email, newCust.Email);
            }
        }
   
        [Fact]
        public void Test_LoginCheck()
        {
            var options = new DbContextOptionsBuilder<CustomerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb26")
            .Options;
            
            using(var context = new CustomerContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                CustomerRepository custRepo = new CustomerRepository(context);
                CustomerLogic cl = new CustomerLogic(custRepo);

                string password = "Test";
                Customer newCustomer = new Customer();
                using (var hmac = new HMACSHA512())
                {
                    newCustomer.Fname = "Testing";
                    newCustomer.Lname = "Test";
                    newCustomer.Email = "test@email.com".ToLower();
                    newCustomer.LastStore = Guid.Empty;
                    newCustomer.StoreManger = Guid.Empty;

                    newCustomer.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                    newCustomer.PasswordSalt = hmac.Key;
                }

                context.Add<Customer>(newCustomer);
                context.SaveChanges();

                RawCustomer rCust = new RawCustomer();
                rCust.Email = "test@email.com";
                rCust.Fname = "Testing";
                rCust.Lname = "Test";
                rCust.Password = password;

                Customer newCust = cl.LoginCheck(rCust);
                
                Assert.Equal(newCustomer.Email, newCust.Email);
            }
        }
    }
}
