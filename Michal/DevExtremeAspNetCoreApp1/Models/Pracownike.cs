using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace DevExtremeAspNetCoreApp1.Models
{
    public class Pracownike
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public string PositionId { get; set; }
    }
}
