using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCamp.Model
{
    //[Table("cc_EmailItems")]
    public class EmailItem
    {
        public EmailItem()
        {
            CreatedUTC = DateTime.UtcNow;
        }

        /// <summary>
        /// Used for substitutions
        /// </summary>
        public const string lineBreak = @"<br />
";

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey("Event")]
        public int EventId { get; set; }

        [Required]
        public virtual Event Event { get; set; }

        [Required]
        public int SendStatusId { get; set; }

        public enum EmailSendStatus
        {
            NotYetSent = -1,
            Undefined = 0,
            Sent = 1,
            Cancelled = 101,
            BadToAddress = 102,
            SendError = 103,
            MessageCreationError = 104,
        };

        [NotMapped]
        public EmailSendStatus SendStatus
        {
            get
            {
                return GetSendStatus(this.SendStatusId);
            }
            set
            {
                this.SendStatusId = (int)value;
            }
        }

        public static EmailSendStatus GetSendStatus(int sendStatusId)
        {
            if (typeof(EmailSendStatus).IsEnumDefined(sendStatusId))
                return (EmailSendStatus)sendStatusId;
            else
                return EmailSendStatus.Undefined;
        }

        [Required]
        public bool TestMessage { get; set; }

        /// <summary>
        /// Allow for email messages not connected to an EmailCampaign
        /// </summary>
        //[ForeignKey("EmailCampaign")]
        public Nullable<int> EmailCampaignId { get; set; }

        public virtual EmailCampaign EmailCampaign { get; set; }

        [Required]
        [MaxLength(256)]
        public string EmailView { get; set; }

        //removed 5/13/2015 - anticipating change in auth
        //public virtual SiteUser SiteUser { get; set; }

        /// <summary>
        /// Allow for email messages not connected to presenters
        /// </summary>
        //[ForeignKey("Presenter")]
        public Nullable<int> PresenterId { get; set; }

        public virtual Presenter Presenter { get; set; }

        [Required]
        [MaxLength(192)]
        public string EmailTo { get; set; }

        [Required]
        [MaxLength(128)]
        public string FirstName { get; set; }

        [MaxLength(128)]
        public string LastName { get; set; }

        /// <summary>
        /// When editing subject, use this
        /// </summary>
        [Required]
        [MaxLength(192)]
        public string Subject { get; set; }

        /// <summary>
        /// When displaying subject or creating email, use this
        /// </summary>
        public string SubjectToUse
        {
            get
            {
                if (TestMessage)
                {
                    return string.Format("TEST: {0}", Subject);
                }
                return Subject;
            }
        }

        [MaxLength(192)]
        public string ReplyToAddress { get; set; }

        [Required]
        [MaxLength(256)]
        public string Salutation { get; set; }

        [Required]
        public DateTime CreatedUTC { get; protected set; }

        [Required]
        [MaxLength(128)]
        public string CreatedBy { get; set; }

        public Nullable<DateTime> SentUTC { get; set; }

        [MaxLength(256)]
        public string SentBy { get; set; }

        [MaxLength(1024)]
        public string CustomContent1 { get; set; }

        [MaxLength(1024)]
        public string CustomContent2 { get; set; }

        //*** Migration - AddEmailItemSession ***
        /// <summary>
        /// Allow for email messages to optionally include Session information
        /// </summary>
        //[ForeignKey("Session")]
        public Nullable<int> SessionId { get; set; }
        public virtual Session Session { get; set; }

        /// <summary>
        /// Allow for email messages not connected to site users
        /// </summary>
        [MaxLength(128)]
        public string SiteUser2Id { get; set; }
    }
}
