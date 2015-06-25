using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCamp.Model
{
    //[Table("cc_PresenterBiographies")]
    public class PresenterBiography
    {
        [Required]
        //[ForeignKey("Presenter")]
        public int PresenterId { get; set; }
        [Required]
        public virtual Presenter Presenter { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Content { get; set; }

    }
}
