﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repository
{
    // interface générique pour les repositories
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        IList<T> SearchFor(Expression<Func<T, bool>> predicate);
        // sauve l'entité si l'élément n'existe pas déjà -> l'existence se base sur le prédicat
        bool Save(T entity, Expression<Func<T, bool>> predicate);
        IList<T> GetAll();
        T GetById(int id);
    }
}
