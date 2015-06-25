using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeCamp.Model
{
    //[Table("cc_Events")]
    public class Event
    {
        //[Key]
        //[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string DisplayName { get; set; }

        [Required]
        [MaxLength(32)]
        public string ShortName { get; set; }

        [Required]
        [MaxLength(64)]
        [MinLength(0)]
        public string DisplayDate { get; set; }

        [Required]
        [MaxLength(128)]
        [MinLength(0)]
        public string DisplayLocation { get; set; }

        [Required]
        [MaxLength(128)]
        [MinLength(0)]
        public string RegistrationUrl { get; set; }

        [Required]
        public DateTime SessionSubmissionsOpen { get; set; }

        [Required]
        public DateTime SessionSubmissionsClose { get; set; }

        [Required]
        public bool EventIsPublic { get; set; }

        [Required]
        public Decimal DisplaySortOrder { get; set; }

        /// <summary>
        /// Date of first day of event
        /// </summary>
        [Required]
        public DateTime EventStartDate { get; set; }

        /// <summary>
        /// When true, Presenter who presented at old event where 
        /// Presenter record is not connected to a login is allowed to
        /// edit profile and connect it to new login with same email address.
        /// </summary>
        [Required]
        public bool DisconnectedPresenterProfileConnectionAllowed { get; set; }

        [Required]
        public bool ScheduleIsPublic { get; set; }

        /// <summary>
        /// When true, a Presenter who has presented at an old event
        /// and is creating a profile for a new event will get the data
        /// from the old profile as the defaults for the new profile.
        /// </summary>
        [Required]
        public bool PriorEventProfileReuseAllowed { get; set; }

        /// <summary>
        /// If EventIsPublic is false, but UserIsInRole of this role, user can see event.
        /// </summary>
        [MaxLength(30)]
        public string NonPublicEventPreviewRole { get; set; }

        [Required]
        public bool AgendaIsPublic { get; set; }

        [Required]
        public bool ScheduleVisibleToPresenters { get; set; }

        [MaxLength(172)]
        public string SchedulePdfUrl { get; set; }

        /// <summary>
        /// Used prior to RegistrationUrl being filled
        /// </summary>
        public Nullable<DateTime> AttendeeRegistrationOpens { get; set; }

        /// <summary>
        /// When true, presenter names will be visible when presenters submit their session proposal
        /// </summary>
        [Required]
        public bool PresenterNamesVisibleAtSubmission { get; set; }

        /// <summary>
        /// Event is public for future events page
        /// </summary>
        [Required]
        public bool EventIsPublicForFuture { get; set; }

        private ICollection<Building> _buildings;
        public virtual ICollection<Building> Buildings
        {
            get { return _buildings ?? (_buildings = new List<Building>()); }
            protected set { _buildings = value; }
        }

        private ICollection<EmailCampaign> _emailCampaigns;
        public virtual ICollection<EmailCampaign> EmailCampaigns
        {
            get { return _emailCampaigns ?? (_emailCampaigns = new List<EmailCampaign>()); }
            protected set { _emailCampaigns = value; }
        }

        private ICollection<EmailItem> _emailItems;
        public virtual ICollection<EmailItem> EmailItems
        {
            get { return _emailItems ?? (_emailItems = new List<EmailItem>()); }
            protected set { _emailItems = value; }
        }

        private ICollection<Presenter> _presenters;
        public virtual ICollection<Presenter> Presenters
        {
            get { return _presenters ?? (_presenters = new List<Presenter>()); }
            protected set { _presenters = value; }
        }

        private ICollection<Session> _sessions;
        public virtual ICollection<Session> Sessions
        {
            get { return _sessions ?? (_sessions = new List<Session>()); }
            protected set { _sessions = value; }
        }

        //*** NOTE: 6/9/2015 - Would not get populated by EF because object does not have Event in it
        //private ICollection<SessionPresenter> _sessionPresenters;
        //public virtual ICollection<SessionPresenter> SessionPresenters
        //{
        //    get { return _sessionPresenters ?? (_sessionPresenters = new List<SessionPresenter>()); }
        //    protected set { _sessionPresenters = value; }
        //}

        private ICollection<Sponsor> _sponsors;
        public virtual ICollection<Sponsor> Sponsors
        {
            get { return _sponsors ?? (_sponsors = new List<Sponsor>()); }
            protected set { _sponsors = value; }
        }

        private ICollection<SponsorDisplayType> _sponsorDisplayTypes;
        public virtual ICollection<SponsorDisplayType> SponsorDisplayTypes
        {
            get { return _sponsorDisplayTypes ?? (_sponsorDisplayTypes = new List<SponsorDisplayType>()); }
            protected set { _sponsorDisplayTypes = value; }
        }

        private ICollection<Tag> _tags;
        public virtual ICollection<Tag> Tags
        {
            get { return _tags ?? (_tags = new List<Tag>()); }
            protected set { _tags = value; }
        }

        private ICollection<Timeslot> _timeslots;
        public virtual ICollection<Timeslot> Timeslots
        {
            get { return _timeslots ?? (_timeslots = new List<Timeslot>()); }
            protected set { _timeslots = value; }
        }

    }
}
