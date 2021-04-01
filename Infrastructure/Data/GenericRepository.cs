using Core.Entities;
using Core.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
  public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
  {
    private readonly WMPolicyContext _context;
    internal DbSet<T> _dbSet;

    public GenericRepository(WMPolicyContext context)
    {
      _context = context;
      this._dbSet = _context.Set<T>();
    }
    public int GetCount(Expression<Func<T, bool>> filter)
    {
      IQueryable<T> query = _dbSet;
      query = query.Where(filter);
      return query.Count();
    }

    public void Add(T item)
    {
      _context.Add((item));
    }

    public async Task<T> GetByIdAsync(int id)
    {
      // return await _context.Set<T>().FindAsync(id);
      return await _dbSet.FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
      // return await _context.Set<T>().ToListAsync();
      return await _dbSet.ToListAsync();
    }

    public async Task<bool> AddRangeAsync(List<T> items)
    {
      await _context.AddRangeAsync(items);
      return _context.SaveChanges() >= 0;
    }
    public bool UpdateRange(List<T> items)
    {
      _context.UpdateRange(items);
      return _context.SaveChanges() >= 0;
    }

    public bool Save()
    {
      return _context.SaveChanges() >= 0;
    }

    public void Update(T item)
    {
      _context.Update(item);
    }

    public async Task<IEnumerable<T>> RunStoredProc(
      string spName,
      Dictionary<string, object> prms
      )
    {
      List<SqlParameter> paramList = new List<SqlParameter>();
      foreach (var kvp in prms)
      {
        paramList.Add(new SqlParameter(kvp.Key, kvp.Value));
      }
      var prmArray = paramList.ToArray();
      // return await _dbSet.FromSqlRaw<T>(spName, prmArray).ToListAsync();

      try
      {
        //string instrument = "NZD_USD";
        //string granularity = "D";
        //var result = await _dbSet.FromSqlRaw<T>("dbo.getLatestCandle @instrument, @granularity",
        // new SqlParameter("@instrument", instrument),
        // new SqlParameter("@granularity", granularity)
        // ).ToListAsync();

        return await _dbSet.FromSqlRaw<T>(spName, prmArray).ToListAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }

    }
    public async Task<IEnumerable<T>> GetAllByExpression(Expression<Func<T, bool>> filter = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
      string includeProperties = null)
    {
      IQueryable<T> query = _dbSet;
      if (filter != null)
      {
        query = query.Where(filter);
      }

      if (includeProperties != null)
      {
        foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
          query = query.Include(includeProp);
        }
      }

      if (orderBy != null)
      {
        return await orderBy(query).ToListAsync();
      }

      return await query.ToListAsync();
    }

    public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
      string includeProperties = null)
    {
      IQueryable<T> query = _dbSet;
      if (filter != null)
      {
        query = query.Where(filter);
      }

      if (includeProperties != null)
      {
        foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
          query = query.Include(includeProp);
        }
      }

      if (orderBy != null)
      {
        query = orderBy(query);
      }
      return await query.FirstOrDefaultAsync();
    }

    public void DeleteRange(IEnumerable<T> items)
    {
      _dbSet.RemoveRange(items);
    }
    public void Delete(T item)
    {
      _context.Remove((item));
    }
    public void Delete(int id)
    {
      T item = _dbSet.Find(id);
      Delete(item);
    }
    public void DeleteWhere(Expression<Func<T, bool>> filter)
    {
      IQueryable<T> query = _dbSet;
      query = query.Where(filter);
      _dbSet.RemoveRange(query);
    }

  }
}
