using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CodeCamp.Model
{
    //[Table("cc_Sessions")]
    public class Session
    {
        public Session()
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
        public string Title { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Description { get; set; }

        [MaxLength(128)]
        public string SessionMaterialsUrl { get; set; }

        [Required]
        public virtual DateTime CreatedUTC { get; protected set; }

        public enum SessionStatus
        {
            Undefined = 0,
            Submitted = 1,
            Cancelled = 2,
            Declined = 3,
            Selected = 4,
            LateCancel = 5,
            /// <summary>
            /// Session is on hold - does not display to public
            /// </summary>
            Hold = 6
        };

        [NotMapped]
        public SessionStatus Status
        {
            get
            {
                return GetSessionStatus(this.SessionStatusId);
            }
            set
            {
                this.SessionStatusId = (int)value;
            }
        }

        public static SessionStatus GetSessionStatus(int sessionStatusId)
        {
            if (typeof(SessionStatus).IsEnumDefined(sessionStatusId))
                return (SessionStatus)sessionStatusId;
            else
                return SessionStatus.Undefined;
        }

        /// <summary>
        /// To be replaced by enum when .Net 4.5 is available 
        /// </summary>
        [Required]
        public int SessionStatusId { get; set; }

        /// <summary>
        /// Visible to presenter and event organizers
        /// </summary>
        [MaxLength(10)]
        public string DesiredRoomSize { get; set; }

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

        public Nullable<DateTime> SelectionAcknowledgedUTC { get; set; }

        //*** Migration - AddEmailItemSession ***
        private ICollection<EmailItem> _emailItems;
        public virtual ICollection<EmailItem> EmailItems
        {
            get { return _emailItems ?? (_emailItems = new List<EmailItem>()); }
            protected set { _emailItems = value; }
        }

        private ICollection<ScheduledSession> _scheduledSessions;
        public virtual ICollection<ScheduledSession> ScheduledSessions
        {
            get { return _scheduledSessions ?? (_scheduledSessions = new List<ScheduledSession>()); }
            protected set { _scheduledSessions = value; }
        }

        private ICollection<SessionPresenter> _sessionPresenters;
        public virtual ICollection<SessionPresenter> SessionPresenters
        {
            get { return _sessionPresenters ?? (_sessionPresenters = new List<SessionPresenter>()); }
            protected set { _sessionPresenters = value; }
        }

        private ICollection<SessionTag> _sessionTags;
        public virtual ICollection<SessionTag> SessionTags
        {
            get { return _sessionTags ?? (_sessionTags = new List<SessionTag>()); }
            protected set { _sessionTags = value; }
        }

    }
}
