using BusinessLayer.Abstruct;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _MessageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _MessageDal = messageDal;
        }

        public List<Message> GetListAll()
        {
           return _MessageDal.GetAllList();
        }

        public List<Message> GetInboxListByWriter(String p)
        {
            return _MessageDal.GetAllList(x => x.Receiver == p);
        }

        public void TAdd(Message t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message t)
        {
            throw new NotImplementedException();
        }

        public Message TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message t)
        {
            throw new NotImplementedException();
        }
    }
}
