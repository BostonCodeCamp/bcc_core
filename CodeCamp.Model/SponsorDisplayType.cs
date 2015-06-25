using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeCamp.Model
{
    //[Table("cc_SponsorDisplayTypes")]
    public class SponsorDisplayType
    {
        //[Key]
        //[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey("Event")]
        public int EventId { get; set; }

        [Required]
        public virtual Event Event { get; set; }

        [MaxLength(256)]
        [Required]
        public string Name { get; set; }

        private ICollection<Sponsor> _sponsors;
        public virtual ICollection<Sponsor> Sponsors
        {
            get { return _sponsors ?? (_sponsors = new List<Sponsor>()); }
            protected set { _sponsors = value; }
        }
    }
}
