using CommercialAutomation.Business.Abstract;
using CommercialAutomation.DataAccess.Abstract;
using CommercialAutomation.Entities.Concrete;
using DevFramework.Core.Aspects.Postsharp.CacheAspects;
using DevFramework.Core.Aspects.Postsharp.PerformanceAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching.Microsoft;
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

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<Message> GetAllInbox(string parameter)
        {
            return _messageDal.GetAll(x => x.ReceiverMail == parameter);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        [PerformanceCounterAspect(5)]
        public List<Message> GetAllSendbox(string parameter)
        {
            return _messageDal.GetAll(x => x.SenderMail == parameter);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId==id);
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
