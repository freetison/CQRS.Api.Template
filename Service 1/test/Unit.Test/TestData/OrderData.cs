namespace Unit.Test.TestData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class OrderTestData
    {
        public static IEnumerable<object[]> QuantityTestData
        {
            get
            {
                yield return new object[] { 0, false };
                yield return new object[] {30, true};
                yield return new object[] {-30, false};
            }
        }

        public static IEnumerable<object[]> QuantityTestExternalData
        {
            get
            {
                var data = Utils.LoadDataFromJson<List<TestOrderDataModel>>("OrderData.json");
                return data.Select(x => new object[] {x.Value, x.Expected});
            }
        }
    }
}
