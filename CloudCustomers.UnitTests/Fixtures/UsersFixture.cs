using CloudCustomers.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudCustomers.UnitTests.Fixtures
{
    public static class UsersFixture
    {
        public static List<User> GetTestUsers() =>
            new()
            {
                new User
                {
                    Name = "Test User 1",
                    Email = "test.user.1@email.com",
                    Address = new Address
                    {
                        Street = "123 St",
                        City = "BirSehir",
                        ZipCode = "212112"
                    }
                },
                new User
                {
                    Name = "Test User 2",
                    Email = "test.user.2@email.com",
                    Address = new Address
                    {
                        Street = "124 St",
                        City = "BirbSehir",
                        ZipCode = "212222"
                    }
                },
                new User
                {
                    Name = "Test User 3",
                    Email = "test.user.3@email.com",
                    Address = new Address
                    {
                        Street = "125 St",
                        City = "BireSehir",
                        ZipCode = "212333"
                    }
                }
            };





    }
}
