using System.Linq.Expressions;

namespace WebAPI.HienThi
{
    public interface LuuTru<R> where R : class
    {
        IQueryable<R> GetAll();
        IQueryable<R> GetPage(int pageNumber, int pageSize);
        IQueryable<R> Search(Expression<Func<R, bool>> searhcExpression, int pageNumber, int pageSize);
        Task<R> GetByIdentifier(object identifier);
        Task Create(R entity);
        Task Update(R entity);
    }
}
