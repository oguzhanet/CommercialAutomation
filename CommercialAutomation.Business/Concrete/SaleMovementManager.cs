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
    public class SaleMovementManager : ISaleMovementService
    {
        ISaleMovementDal _saleMovementDal;

        public SaleMovementManager(ISaleMovementDal saleMovementDal)
        {
            _saleMovementDal = saleMovementDal;
        }

        public void Add(SaleMovement saleMovement)
        {
            _saleMovementDal.Add(saleMovement);
        }

        public void Delete(SaleMovement saleMovement)
        {
            _saleMovementDal.Delete(saleMovement);
        }

        public List<SaleMovement> GetAll()
        {
            return _saleMovementDal.GetAll();
        }

        public List<SaleMovement> GetAllByCustomerId(int id)
        {
            return _saleMovementDal.GetAllById(x => x.CustomerId == id);
        }

        public List<SaleMovement> GetAllByEmployeeId(int id)
        {
            return _saleMovementDal.GetAllById(x => x.EmployeeId == id);
        }

        public SaleMovement GetById(int id)
        {
            return _saleMovementDal.Get(x => x.SaleMovementId == id);
        }

        public void Update(SaleMovement saleMovement)
        {
            _saleMovementDal.Update(saleMovement);
        }
    }
}
