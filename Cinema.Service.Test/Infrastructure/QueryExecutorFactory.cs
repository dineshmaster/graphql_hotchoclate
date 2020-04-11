using HotChocolate;
using HotChocolate.Execution;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinema.Service.Test.Infrastructure
{
    public class QueryExecutorFactory
    {
        public static IQueryExecutor Create<T>()
        {
            IQueryExecutor queryExecutor = SchemaBuilder.New()
                .AddQueryType(p => p.Name("Query"))
                .AddType<T>()
                .Create()
                .MakeExecutable();
            return queryExecutor;
        }
    }
}
