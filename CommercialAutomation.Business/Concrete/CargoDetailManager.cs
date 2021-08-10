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
    public class CargoDetailManager : ICargoDetailService
    {
        private ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public void Add(CargoDetail cargoDetail)
        {
            _cargoDetailDal.Add(cargoDetail);
        }

        public void Delete(CargoDetail cargoDetail)
        {
            _cargoDetailDal.Delete(cargoDetail);
        }

        public List<CargoDetail> GetAll()
        {
            return _cargoDetailDal.GetAll();
        }

        public List<CargoDetail> GetAllByCustomerId(int id)
        {
            return _cargoDetailDal.GetAllById(x => x.CustomerId == id);
        }

        public CargoDetail GetById(int id)
        {
            return _cargoDetailDal.Get(x => x.CargoDetailId == id);
        }

        public void Update(CargoDetail cargoDetail)
        {
            _cargoDetailDal.Update(cargoDetail);
        }
    }
}
