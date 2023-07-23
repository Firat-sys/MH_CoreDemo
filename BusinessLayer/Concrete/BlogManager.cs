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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        
        public void BlogAdd(Blog blog)
        {
        
            _blogDal.Insert(blog);
        }

        public void BlogDelete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public Blog BlogGetById(int id)
        {
         return   _blogDal.GetById(id);
        }

        public List<Blog> BlogGetListAll()
        {
            return _blogDal.GetAllList();
        }

        public List<Blog> GetBlogById(int Id)
        {
            return _blogDal.GetAllList(x => x.BlogId == Id);
        }

        public void BlogUpdate(Blog blog)
        {
            _blogDal.Update(blog);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetBlogByWriter(int id)
        {
            return _blogDal.GetAllList(x => x.WriterId==id);
        }
    }
}
