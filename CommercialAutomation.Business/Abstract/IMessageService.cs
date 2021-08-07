using CommercialAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialAutomation.Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAll();
        List<Message> GetAllInbox(string parameter);
        List<Message> GetAllSendbox(string parameter);
        Message GetById(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
    }
}
