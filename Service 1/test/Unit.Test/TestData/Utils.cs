using System.IO;
using System.Text.Json;

namespace Unit.Test.TestData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Utils
    {
        public static T LoadDataFromJson<T>(string filePath) => JsonSerializer.Deserialize<T>(System.IO.File.ReadAllText(filePath));
    }
}
