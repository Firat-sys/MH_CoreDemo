using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstruct
{
   public interface IBlogService:IGenericSevice<Blog>
    {
        List<Blog> GetBlogListWithCategory();
        List<Blog> GetBlogByWriter(int id);
    }
}
