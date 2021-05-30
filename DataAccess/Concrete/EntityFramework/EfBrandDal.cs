﻿using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (RecapContext context = new RecapContext())
            {
                var addedEnttiy = context.Entry(entity);
                addedEnttiy.State = EntityState.Added;
                context.SaveChanges();
            }        
        }

        public void Delete(Brand entity)
        {
            using (RecapContext context = new RecapContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (RecapContext context = new RecapContext())
            {
                
                return context.Set<Brand>().SingleOrDefault(filter);
            }

        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (RecapContext context = new RecapContext())
            {

                return filter != null ? context.Set<Brand>().Where(filter).ToList() :
                    context.Set<Brand>().ToList();
            }
        }

        public void Update(Brand entity)
        {
            using (RecapContext context = new RecapContext())
            {
                var updatedEnttiy = context.Entry(entity);
                updatedEnttiy.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
