using CoffeeShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.Data;

namespace CoffeeShop.Models.Services
{
    public class ContactRepository : IContactRepository
    {
        private readonly CoffeeShopDbContext dbContext;
        public ContactRepository(CoffeeShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void SendContact(Contact contact)
        {
            dbContext.Contact.Add(contact);
            dbContext.SaveChanges();
        }
    }
}
