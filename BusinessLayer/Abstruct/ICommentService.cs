using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstruct
{
   public interface ICommentService
    {
        void CommentAdd(Comment Comment);
       // void CategoryDelete(Category category);
        //void CategoryUpdate(Category category);
        List<Comment> GetListAll(int id);
        //Category GetById(int id);
    }
}
