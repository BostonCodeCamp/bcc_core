using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeCamp.Model
{
    //[Table("cc_Presenters")]
    public class Presenter
    {
        public Presenter()
        {
            this.CreatedUTC = DateTime.UtcNow;
        }

        //[Key]
        //[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey("Event")]
        public int EventId { get; set; }

        [Required]
        public virtual Event Event { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(128)]
        public string LastName { get; set; }

        [MaxLength(128)]
        public string TwitterName { get; set; }

        [Required]
        [MaxLength(128)]
        public string EmailAddress { get; set; }

        //removed 5/13/2015 - anticipating change in auth
        //public virtual SiteUser SiteUser { get; set; }

        [MaxLength(1024)]
        public string WebsiteUrl { get; set; }

        [MaxLength(1024)]
        public string BlogUrl { get; set; }

        //Used for contact on event day(s)
        [MaxLength(20)]
        public string MobilePhone { get; set; }

        public virtual PresenterBiography PresenterBiography { get; set;}

        public string Biography
        {
            get
            {
                if (PresenterBiography != null)
                    return PresenterBiography.Content;
                return null;
            }
        }

        [Required]
        public virtual DateTime CreatedUTC { get; protected set; }

        [MaxLength(128)]
        public string UpdatedBy { get; set; }

        public Nullable<DateTime> UpdatedUTC { get; set; }

        /// <summary>
        /// Visible to presenter and event organizers
        /// </summary>
        [MaxLength(1024)]
        public string PrivateNotes { get; set; }

        /// <summary>
        /// Visible to event organizers
        /// </summary>
        [MaxLength(1024)]
        public string OrganizerNotes { get; set; }

        /// <summary>
        /// Allow for prior events where presenters don't have site users
        /// </summary>
        [MaxLength(128)]
        public string SiteUser2Id { get; set; }

        private ICollection<SessionPresenter> _sessionPresenters;
        public virtual ICollection<SessionPresenter> SessionPresenters
        {
            get { return _sessionPresenters ?? (_sessionPresenters = new List<SessionPresenter>()); }
            protected set { _sessionPresenters = value; }
        }

        private ICollection<EmailItem> _emailItems;
        public virtual ICollection<EmailItem> EmailItems
        {
            get { return _emailItems ?? (_emailItems = new List<EmailItem>()); }
            protected set { _emailItems = value; }
        }
    
    }
}
