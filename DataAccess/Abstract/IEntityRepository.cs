using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Entities.Abstract;

namespace DataAccess.Abstract
{
    //generic constraint(kısıt)
    //class: referans tip olabilir demek
    // IEntity: IEntity olabilir ya da IEntity implemente eden bir nesne olabilir
    // new() : new lenebilir olmalı
    // <T> olan t type in kısaltmasıdır
    public interface IEntityRepository<T> where T: class,IEntity,new()
    {
        //delege
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
        T GetCarsByBrandId(Expression<Func<T,bool>>filter);
        T GetCarsByColorsId(Expression<Func<T,bool>>filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
