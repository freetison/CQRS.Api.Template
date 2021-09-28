using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;

namespace Api.Filters.FilterExceptionFactory
{
    public class ExceptionFactory
    {
        private readonly Dictionary<string, Func<ApiError>> _facDictionary;


        public ExceptionFactory() => _facDictionary = new Dictionary<string, Func<ApiError>>();

        public void Register(string type, Func<ApiError> factoryClass)
        {
            if(factoryClass is null) return;

            _facDictionary[type] = factoryClass;
        }

        public List<string> RegisteredTypes => _facDictionary.Keys.ToList();

        public ApiError this[string type] => Create(type);

        public ApiError Create(string type) => _facDictionary[type]();
    }
}