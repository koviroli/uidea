using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIdea.Extensions
{
    public static class QueryParamsExtensions
    {
        public static QueryParameters GetQueryParameters(this HttpContext context)
        {
            var dictionary = context.Request.Query.ToDictionary(d => d.Key, d => d.Value.ToString());
            return new QueryParameters(dictionary);
        }
    }

    public class QueryParameters : Dictionary<string, string>
    {
        public QueryParameters() : base() { }
        public QueryParameters(int capacity) : base(capacity) { }
        public QueryParameters(IDictionary<string, string> dictionary) : base(dictionary) { }

        public QueryParameters WithRoute(string routeParam, string routeValue)
        {
            if (!ContainsKey(routeParam))
                Add(routeParam, routeValue);

            return this;
        }
    }
}
