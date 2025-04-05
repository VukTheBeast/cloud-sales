using Crayon.TechExercise.CloudSales.DB.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crayon.TechExercise.CloudSales.DB.Sql.SeedData
{
    public static class DbSeeder
    {
        public static void Seed(this CloudSalesContext context)
        {
            context.Database.Migrate();

            if (!context.Customers.Any())
            {
                var customer1 = new Customer
                {
                    FirstName = "FirstName",
                    LastName = "LastName",
                    Email = "test@test.com",
                    Accounts = new[]
                    {
                        new Account
                        {
                            Name = "Account1",
                            PurchasedSoftwares = new List<PurchasedSoftware>
                            {
                                new PurchasedSoftware
                                {
                                    Name = "Microsoft",
                                    Quantity = 1,
                                    State = SoftwareState.Active,
                                    ValidTo = DateTime.UtcNow.AddDays(5),
                                },
                                 new PurchasedSoftware
                                {
                                    Name = "AWS",
                                    Quantity = 2,
                                    State = SoftwareState.Active,
                                    ValidTo = DateTime.UtcNow.AddDays(18),
                                }
                            }
                        },
                        new Account
                        {
                            Name = "Account2",
                            PurchasedSoftwares = new List<PurchasedSoftware>
                            {
                                new PurchasedSoftware
                                {
                                    Name = "AWS",
                                    Quantity = 2,
                                    State = SoftwareState.Active,
                                    ValidTo = DateTime.UtcNow.AddDays(18),
                                },
                                 new PurchasedSoftware
                                {
                                    Name = "Adove",
                                    Quantity = 3,
                                    State = SoftwareState.Active,
                                    ValidTo = DateTime.UtcNow.AddDays(27),
                                }
                            }
                        },
                        new Account
                        {
                            Name = "Account3",
                            PurchasedSoftwares = new List<PurchasedSoftware>
                            {
                                new PurchasedSoftware
                                {
                                    Name = "Adove",
                                    Quantity = 3,
                                    State = SoftwareState.Active,
                                    ValidTo = DateTime.UtcNow.AddDays(27),
                                }
                            }
                        }
                    }
                };

                var customer2 = new Customer
                {
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    Email = "test2@test2.com",
                    Accounts = new[]
                    {
                        new Account
                        {
                            Name = "Account1",
                            PurchasedSoftwares = new List<PurchasedSoftware>
                            {
                                new PurchasedSoftware
                                {
                                    Name = "Microsoft",
                                    Quantity = 1,
                                    State = SoftwareState.Active,
                                    ValidTo = DateTime.UtcNow.AddDays(5),
                                },
                                 new PurchasedSoftware
                                {
                                    Name = "Adove",
                                    Quantity = 3,
                                    State = SoftwareState.Active,
                                    ValidTo = DateTime.UtcNow.AddDays(27),
                                }
                            }
                        },
                        new Account
                        {
                            Name = "Account2",
                            PurchasedSoftwares = new List<PurchasedSoftware>
                            {
                                new PurchasedSoftware
                                {
                                    Name = "Microsoft",
                                    Quantity = 1,
                                    State = SoftwareState.Active,
                                    ValidTo = DateTime.UtcNow.AddDays(5),
                                },
                                new PurchasedSoftware
                                {
                                    Name = "AWS",
                                    Quantity = 2,
                                    State = SoftwareState.Active,
                                    ValidTo = DateTime.UtcNow.AddDays(18),
                                }
                            }
                        },
                        new Account
                        {
                            Name = "Account3",
                            PurchasedSoftwares = new List<PurchasedSoftware>
                            {
                                new PurchasedSoftware
                                {
                                    Name = "Adove",
                                    Quantity = 3,
                                    State = SoftwareState.Active,
                                    ValidTo = DateTime.UtcNow.AddDays(27),
                                }
                            }
                        }
                    }
                };

                var customer3 = new Customer
                {
                    FirstName = "FirstName3",
                    LastName = "LastName3",
                    Email = "test3@test3.com",
                    Accounts = new[]
                    {
                        new Account
                        {
                            Name = "Account4",
                            PurchasedSoftwares = new List<PurchasedSoftware>
                            {
                                new PurchasedSoftware
                                {
                                    Name = "Microsoft",
                                    Quantity = 1,
                                    State = SoftwareState.Active,
                                    ValidTo = DateTime.UtcNow.AddDays(5),
                                }
                            }
                        },
                        new Account
                        {
                            Name = "Account5",
                            PurchasedSoftwares = new List<PurchasedSoftware>
                            {
                                new PurchasedSoftware
                                {
                                    Name = "AWS",
                                    Quantity = 2,
                                    State = SoftwareState.Active,
                                    ValidTo = DateTime.UtcNow.AddDays(18),
                                }
                            }
                        },
                        new Account
                        {
                            Name = "Account6"
                        }
                    }
                };

                context.Customers.AddRange(customer1, customer2, customer3);
                context.SaveChanges();
            }
        }
    }
}
