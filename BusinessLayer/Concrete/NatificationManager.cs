﻿using BusinessLayer.Abstruct;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NatificationManager : INatificationService
    {
        INatificationDal _natificationDal;

        public NatificationManager(INatificationDal natificationDal)
        {
            _natificationDal = natificationDal;
        }

        public List<Natification> GetListAll()
        {
            return _natificationDal.GetAllList();
        }

        public void TAdd(Natification t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Natification t)
        {
            throw new NotImplementedException();
        }

        public Natification TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Natification t)
        {
            throw new NotImplementedException();
        }
    }
}
