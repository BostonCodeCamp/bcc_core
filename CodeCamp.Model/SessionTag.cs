using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeCamp.Model
{
    //[Table("cc_SessionTags")]
    public class SessionTag
    {
        //[Key]
        //[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey("Session")]
        //[Column(Order = 0)]
        public int SessionId { get; set; }

        [Required]
        public virtual Session Session { get; set; }

        //[ForeignKey("Tag")]
        //[Column(Order = 0)]
        public int TagId { get; set; }

        [Required]
        public virtual Tag Tag { get; set; }
    }
}
