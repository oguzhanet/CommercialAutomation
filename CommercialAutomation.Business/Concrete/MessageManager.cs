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
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public List<Message> GetAllInbox(string parameter)
        {
            return _messageDal.GetAll(x => x.ReceiverMail == parameter);
        }

        public List<Message> GetAllSendbox(string parameter)
        {
            return _messageDal.GetAll(x => x.SenderMail == parameter);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId==id);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
