using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Core.Interfaces
{
  public interface IGenericRepository<T> where T : BaseEntity
  {
    Task<T> GetByIdAsync(int id);

    Task<IReadOnlyList<T>> ListAllAsync();

    Task<IEnumerable<T>> RunStoredProc(string spName, Dictionary<string, object> prms);

    Task<IEnumerable<T>> GetAllByExpression(
      Expression<Func<T, bool>> filter = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
      string includeProperties = null // use in child data
      );

    // Returns 1 record only
    Task<T> GetFirstOrDefault(
      Expression<Func<T, bool>> filter = null,
      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
      string includeProperties = null // use in child data
      );

    int GetCount(Expression<Func<T, bool>> filter);

    void Delete(int id);

    void Delete(T item);

    void DeleteWhere(Expression<Func<T, bool>> filter);

    void DeleteRange(IEnumerable<T> items);

    void Add(T item);

    bool UpdateRange(List<T> items);

    Task<bool> AddRangeAsync(List<T> items);

    void Update(T item);

    bool Save();
  }
}
