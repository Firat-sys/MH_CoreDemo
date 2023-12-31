﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.EntityFramework
{
    public class EfNatificationrepository : GenericRepositrory<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
        using(var c=new Context())
            {
                return c.Blogs.Include(c => c.Category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c=new Context())
            {
                return c.Blogs.Include(c => c.Category).Where(c => c.WriterId == id).ToList();
            }
        }
    }
}
