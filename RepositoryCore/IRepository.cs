using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RepositoryCore
{
  // anvi change it to internal if possible..
  public interface IRepository<T>
  {
    
    IEnumerable<T> GetAll();
    T GetById(int ID);
    void Insert(T t);
    void Update(T t);
    void Delete(int id);
    void Delete(T entityToDelete);
    bool SaveAllChanges();
    IEnumerable<T> GetbyFilter(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
  }
}
