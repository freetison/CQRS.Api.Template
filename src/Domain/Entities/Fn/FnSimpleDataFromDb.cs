using System.ComponentModel.DataAnnotations.Schema;
using $safeprojectname$.Interfaces;

namespace $safeprojectname$.Entities.Fn
{
    public class FnSimpleDataFromDb: IFnSimpleDataFromDb
    {
        public const string DbFnName = "Fn_ExistingFunctionInDb";


        [Column("OrderId")]
        public int OrderId { get; set; }

        [Column("Status")]
        public string Status { get; set; }
    }
}
