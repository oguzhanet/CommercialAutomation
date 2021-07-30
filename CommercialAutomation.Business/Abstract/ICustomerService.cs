using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        Customer GetBy(string mail);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}
