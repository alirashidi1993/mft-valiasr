using MFT.Training.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MFT.Training.Repositories
{
    public class CustomerRepository
    {
        AmlakEntities dbContext;
        public CustomerRepository()
        {
            dbContext = new AmlakEntities();
        }
        public void CreateCustomer(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
        }
        public List<Customer> SearchCustomers(string searchValue="")
        {
            if(string.IsNullOrEmpty(searchValue))
            {
                return 
                    dbContext.Customers
                    .ToList();
            }
            else
            {
                List<Customer> moshtariha=dbContext.Customers
                    .Where(c=>
                    c.FirstName.Contains(searchValue) ||
                    c.LastName.Contains(searchValue) ||
                    c.CodeMelli.Contains(searchValue))
                    .ToList();

                return moshtariha;
            }
            
        }

        public void DeleteCustomer(int id)
        {
            Customer moshtari=dbContext.Customers.FirstOrDefault(c => c.Id == id);
            if(moshtari!=null)
            {
                dbContext.Customers.Remove(moshtari);
                dbContext.SaveChanges();
            }
            
        }
        public void UpdateCustomer(int id, Customer dataJadid)
        {
            Customer moshtari = dbContext.Customers.FirstOrDefault(e => e.Id == id);

            moshtari.FirstName = dataJadid.FirstName;
            moshtari.LastName = dataJadid.LastName;
            moshtari.CodeMelli = dataJadid.CodeMelli;
            moshtari.Mobile = dataJadid.Mobile;
            moshtari.ShahrId = dataJadid.ShahrId;
            dbContext.SaveChanges();
        }

        public Customer GetById(int id)
        {
            Customer moshtari = dbContext.Customers
                .Include(d=>d.Shahr)
                .First(i => i.Id == id);
            return moshtari;
        }
    }
}