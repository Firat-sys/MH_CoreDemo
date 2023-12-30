using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstruct
{
   public interface IMessage2Service:IGenericSevice<Message2>
    {
        List<Message2> GetInboxListByWriter(int id);
    }
}
