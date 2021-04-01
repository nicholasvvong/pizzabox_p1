using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Repository;
using Xunit;

namespace PizzaBox.Testing
{
    public class CustomerRepoUnitTest
    {
        [Fact]
        public void Test_AddNewCustomer()
        {
            var options = new DbContextOptionsBuilder<CustomerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb7")
            .Options;

            Customer newCust = new Customer();
            newCust.Email = "Test@Testing.com";
            using (var context = new CustomerContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                CustomerRepository custRepo = new CustomerRepository(context);

                custRepo.AddNewCustomer(newCust);
                context.SaveChanges();
            }

            using (var context = new CustomerContext(options))
            {
                CustomerRepository custRepo = new CustomerRepository(context);

                var testCust = context.Customers.SingleOrDefault(n => n.Email == newCust.Email);

                Assert.Equal(testCust.Email, newCust.Email);
            }
        }

        [Fact]
        public void Test_IsExistingAccountTrue()
        {
            var options = new DbContextOptionsBuilder<CustomerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb8")
            .Options;

            Customer newCust = new Customer();
            newCust.Email = "exist@email.com";
            string expected = "exist@email.com";
            using (var context = new CustomerContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                CustomerRepository custRepo = new CustomerRepository(context);

                custRepo.AddNewCustomer(newCust);
                context.SaveChanges();
            }

            using (var context = new CustomerContext(options))
            {
                CustomerRepository custRepo = new CustomerRepository(context);

                Assert.True(custRepo.IsExistingAccount(expected));
            }
        }
        
        [Theory]
        [InlineData("doesnotexist@email.com")]
        public void Test_IsExistingAccountFalse(string email)
        {
            var options = new DbContextOptionsBuilder<CustomerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb9")
            .Options;

            Customer newCust = new Customer();
            newCust.Email = email;
            string expected = "exist@email.com";
            using (var context = new CustomerContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                CustomerRepository custRepo = new CustomerRepository(context);

                custRepo.AddNewCustomer(newCust);
                context.SaveChanges();
            }

            using (var context = new CustomerContext(options))
            {
                CustomerRepository custRepo = new CustomerRepository(context);

                Assert.False(custRepo.IsExistingAccount(expected));
            }
        }
    
        [Fact]
        public void Test_GetCustomerByEmail()
        {
            var options = new DbContextOptionsBuilder<CustomerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb10")
            .Options;

            string email = "exist@email.com";
            Customer newCust = new Customer();
            newCust.Fname = "TestPerson";
            newCust.Email = email;
            using (var context = new CustomerContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                CustomerRepository custRepo = new CustomerRepository(context);

                custRepo.AddNewCustomer(newCust);
                context.SaveChanges();
            }

            using (var context = new CustomerContext(options))
            {
                CustomerRepository custRepo = new CustomerRepository(context);

                var testCust = custRepo.GetCustomerByEmail(email);

                Assert.Equal(testCust.Fname, newCust.Fname);
            }
        }
    
        [Fact]
        public void Test_GetCustomerByID()
        {
            var options = new DbContextOptionsBuilder<CustomerContext>()
            .UseInMemoryDatabase(databaseName: "TestDb11")
            .Options;
            
            Customer newCust = new Customer();
            newCust.Fname = "TestPerson";
            using (var context = new CustomerContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                CustomerRepository custRepo = new CustomerRepository(context);

                custRepo.AddNewCustomer(newCust);
                context.SaveChanges();
            }

            using (var context = new CustomerContext(options))
            {
                CustomerRepository custRepo = new CustomerRepository(context);

                var testCust = custRepo.GetCustomerByID(newCust.CustomerID);

                Assert.Equal(testCust.Fname, newCust.Fname);
            }
        }
    }
}
