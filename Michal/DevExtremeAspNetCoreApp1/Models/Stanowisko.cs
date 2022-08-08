using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;






namespace DevExtremeAspNetCoreApp1.Models
{
    public class Stanowisko
    {
        [Key]
        public int PersonId { get; set; }

        public string Position { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
