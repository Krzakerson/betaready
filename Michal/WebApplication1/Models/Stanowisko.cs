using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
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
