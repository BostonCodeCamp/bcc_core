using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCamp.Model
{
    //[Table("cc_Sponsors")]
    public class Sponsor
    {
        //[Key]
        //[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(1024)]
        public string ImageUrl { get; set; }

        [Required]
        public int ImageHeight { get; set; }

        [Required]
        public int ImageWidth { get; set; }

        //[ForeignKey("Event")]
        public int EventId { get; set; }

        [Required]
        public virtual Event Event { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1024)]
        public string Url { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        /// <summary>
        /// When true, image is displayed on sponsors page.
        /// When false, image is not displayed on sponsors page - instead, text of Name is displayed
        /// </summary>
        [Required]
        public bool DisplayImage { get; set; }

        [Required]
        public bool IncludeInRotation { get; set; }

        public enum SponsorType
        {
            undefined = 0,
            Gold = 10,
            Silver = 20,
            Bronze = 30,
            Friend = 40,
            InKind = 100
        }

        public static SponsorType GetSponsorType(int sponsorTypeId)
        {
            if (typeof(SponsorType).IsEnumDefined(sponsorTypeId))
                return (SponsorType)sponsorTypeId;
            else
                return SponsorType.undefined;
        }

        [Required]
        public int SponsorTypeId { get; set; }

        public virtual SponsorDisplayType SponsorDisplayType { get; set; }

        [NotMapped]
        public SponsorType SponsorTypeVal
        {
            get { return GetSponsorType(SponsorTypeId); }
            set { this.SponsorTypeId = (int)value; }
        }
    }
}
