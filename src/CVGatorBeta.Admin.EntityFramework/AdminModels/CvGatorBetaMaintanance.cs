using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CVGatorBeta.Admin.EntityFramework.AdminModels
{
    [Keyless]
    [Table("_CvGatorBetaMaintanance")]
    public partial class CvGatorBetaMaintanance
    {
        public bool? InitData { get; set; }
    }
}
