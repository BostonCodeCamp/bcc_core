using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeCamp.Model
{
    //[Table("cc_SessionPresenters")]
    public class SessionPresenter
    {
        //[Key]
        //[ForeignKey("Presenter")]
        //[Column(Order = 0)]
        public int PresenterId { get; set; }

        [Required]
        public virtual Presenter Presenter { get; set; }

        //[Key]
        //[ForeignKey("Session")]
        //[Column(Order = 1)]
        public int SessionId { get; set; }

        [Required]
        public virtual Session Session { get; set; }
    }
}
