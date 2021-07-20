using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace $safeprojectname$.Entities.Sp
{
    public class SpComplexDataFromDb
    {
        public const string DbSpName = "SP_Complex_Data_From_Db";

        [Column("OrderId")]
        public int OrderId { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [Column("Processed")]
        public DateTime Processed  { get; set; }

    }
}

