using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Entities.Fn
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
