using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace RepositoryCore
{
  public class Repository<T> : IRepository<T> where T : class
  {
    private DbSet<T> _dbset;
   // private readonly ScreenerContext screenerContext;
    private readonly DbContext screenerContext;

    public Repository(DbContext context)
    {
      screenerContext = context;  // anvi check this this may be dine by serilization
                                                   // var serializedParent = JsonConvert.SerializeObject(parentInstance); 
                                                  //  Child c = JsonConvert.DeserializeObject<Child>(serializedParent);
      _dbset = context.Set<T>();
    }

    public void Insert(T entity)
    {
      if (entity == null)
        throw new ArgumentNullException("entity");

      _dbset.Add(entity);
    }
    
    public void Update(T t)
    {
      _dbset.Attach(t);
      screenerContext.Entry(t).State = EntityState.Modified;
    }

    public IEnumerable<T> GetAll()
    {
      return _dbset.ToList();
    }

    public T GetById(int id)
    {
      return _dbset.Find(id);
    }

    public void Delete(int id)
    {
      T entityToDelete = _dbset.Find(id);
      Delete(entityToDelete);
    }

    public virtual void Delete(T entityToDelete)
    {
      if (screenerContext.Entry(entityToDelete).State == EntityState.Detached)
      {
        _dbset.Attach(entityToDelete);
      }
      _dbset.Remove(entityToDelete);
    }

    public bool SaveAllChanges()
    {
      screenerContext.SaveChanges();
      return true;
    }

    public virtual IEnumerable<T> GetbyFilter(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
    {
      IQueryable<T> query = _dbset;

      if (filter != null)
      {
        query = query.Where(filter);
      }

      foreach (var includeProperty in includeProperties.Split
          (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
      {
        query = query.Include(includeProperty);
      }

      if (orderBy != null)
      {
        return orderBy(query).ToList();
      }
      else
      {
        return query.ToList();
      }
    }
  }
}
