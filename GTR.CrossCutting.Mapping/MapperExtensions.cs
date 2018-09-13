using AgileObjects.AgileMapper;
using System.Linq;

namespace GTR.CrossCutting.Mapping
{
    public static class MapperExtensions
    {
        public static IQueryable<TResult> Project<TSource, TResult>(this IQueryable<TSource> queryable)
        {
            return queryable.Project().To<TResult>();
        }
    }
}