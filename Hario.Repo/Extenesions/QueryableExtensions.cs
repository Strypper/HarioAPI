﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Hario.Repo.Extenesions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicateIftrue)
            => condition ? query.Where(predicateIftrue) : query;
    }
}
