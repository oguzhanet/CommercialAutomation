using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Abstract
{
    public interface ISaleMovementService
    {
        List<SaleMovement> GetAll();
        List<SaleMovement> GetAllByEmployeeId(int id);
        List<SaleMovement> GetAllByCustomerId(int id);
        List<SaleMovement> GetAllBySaleId(int id);
        SaleMovement GetById(int id);
        void Add(SaleMovement saleMovement);
        void Update(SaleMovement saleMovement);
        void Delete(SaleMovement saleMovement);
    }
}
