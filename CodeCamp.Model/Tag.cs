using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeCamp.Model
{
    //[Table("cc_Tags")]
    public class Tag
    {
        //[Key]
        //[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey("Event")]
        public int EventId { get; set; }

        [Required]
        public virtual Event Event { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        private ICollection<SessionTag> _sessionTags;
        public virtual ICollection<SessionTag> SessionTags
        {
            get { return _sessionTags ?? (_sessionTags = new List<SessionTag>()); }
            protected set { _sessionTags = value; }
        }

    }
}
