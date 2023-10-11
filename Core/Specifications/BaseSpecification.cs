using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        //Constructors
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }



        //For linq query eagerLoading - getting productType and Brand from product table relations
        public Expression<Func<T, bool>> Criteria {get;}
        public List<Expression<Func<T, object>>> Includes  {get;} = 
            new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }



        //Sorting 
        public Expression<Func<T, object>> OrderBy {get; private set;}
        public Expression<Func<T, object>> OrderByDesc {get; private set;}

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDesc(Expression<Func<T, object>> orderbyExpressionDesc)
        {
            OrderByDesc = orderbyExpressionDesc;
        }



        //Pagination
        public int Take {get; private set;}
        public int Skip {get; private set;}
        public bool IsPagingEnabled {get; private set;}

        protected void ApplyPaging(int take, int skip)
        {
            Skip =skip;
            Take = take;
            IsPagingEnabled = true;
        }

    }
}