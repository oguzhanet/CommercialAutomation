using CommercialAutomation.Business.Abstract;
using CommercialAutomation.DataAccess.Abstract;
using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Add(Customer customer)
        {
            CheckIfCustomerExists(customer);
            _customerDal.Add(customer);
        }

        public void Delete(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerDal.Get(x => x.CustomerId == id);
        }

        public Customer GetBy(string mail)
        {
            return _customerDal.Get(x => x.CustomerMail == mail);
        }

        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }

        private void CheckIfCustomerExists(Customer customer)
        {
            if (_customerDal.Get(x => x.CustomerMail == customer.CustomerMail) != null)
            {
                throw new Exception("Bu kullanıcı daha önce kayıt olmuştur.");
            }
        }
    }
}
