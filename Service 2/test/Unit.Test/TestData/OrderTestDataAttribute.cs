using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit.Sdk;

namespace Unit.Test.TestData
{
    public class OrderTestDataAttribute : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var data = Utils.LoadDataFromJson<List<TestOrderDataModel>>("OrderData.json");
            return data.Select(x => new object[] { x.Value, x.Expected });
        }
    }
}