using AuthDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class BookUser
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }


        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }


        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public bool IsFinished { get; set; } = false;

    }
}
