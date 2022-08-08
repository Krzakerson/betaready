using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Pracownik
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public int PositionId { get; set; }
    }
}
