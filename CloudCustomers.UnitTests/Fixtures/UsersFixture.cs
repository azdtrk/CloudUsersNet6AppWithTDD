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
            new() {
                new User
                {
                    Name = "Test User 1",
                    Email = "test.user.1@gmail.com",
                    Address = new Address
                    {
                        Street = "123 Market St",
                        City = "Somewhere",
                        ZipCode = "213124",
                    }
                },
                new User
                {
                    Name = "Test User 2",
                    Email = "test.user.2@gmail.com",
                    Address = new Address
                    {
                        Street = "900 Main St",
                        City = "Somewhere",
                        ZipCode = "123456",
                    }
                },
                new User
                {
                    Name = "Test User 3",
                    Email = "test.user.3@gmail.com",
                    Address = new Address
                    {
                        Street = "900 Main St",
                        City = "Somewhere",
                        ZipCode = "123456",
                    }
                }
            };
    }
}
