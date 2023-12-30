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
        

        public Blog BlogGetById(int id)
        {
         return   _blogDal.GetById(id);
        }

        public List<Blog> BlogGetListAll()
        {
            return _blogDal.GetAllList();
        }
        public List<Blog> GetListWithCategoryByWriterBM(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetAllList().Take(3).ToList();
        }

        public List<Blog> GetBlogById(int Id)
        {
            return _blogDal.GetAllList(x => x.BlogId == Id);
        }


        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public List<Blog> GetBlogByWriter(int id)
        {
            return _blogDal.GetAllList(x => x.WriterId==id);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
           
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public List<Blog> GetListAll()
        {
            return _blogDal.GetAllList();
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetById(id);
        }
    }
}
