using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public interface ISpecification<T>
    {
        //For linq query eagerLoading - getting productType and Brand from product table relations
        Expression<Func<T,bool>> Criteria{get; }
        List<Expression<Func<T,object>>> Includes{get;}

        //Sorting - query builder
        Expression<Func<T,object>> OrderBy{get; }
        Expression<Func<T,object>> OrderByDesc{get; }

        //Pagination 
        int Take{get;}
        int Skip{get;}
        bool IsPagingEnabled{get;}
    }
}