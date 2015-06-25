using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCamp.Model
{
    //[Table("cc_EmailCampaigns")]
    public class EmailCampaign
    {
        public EmailCampaign()
        {
            CreatedUTC = DateTime.UtcNow;
        }

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey("Event")]
        public int EventId { get; set; }

        [Required]
        public virtual Event Event { get; set; }

        public enum EmailCampaignStatus
        {
            /// <summary>
            /// Campaign is on hold - emails cannot be sent or added.
            /// </summary>
            Hold = -2,
            /// <summary>
            /// Campaign is pending - emails can be added, but not sent
            /// </summary>
            Pending = -1,
            /// <summary>
            /// Campaign status is unknown
            /// </summary>
            Undefined = 0,
            /// <summary>
            /// Campaign is active - emails can be sent, but not added.
            /// </summary>
            Active,
            /// <summary>
            /// Campaign is cancelled - emails cannot be sent or added.
            /// </summary>
            Cancelled,
            /// <summary>
            /// Campaign has been cancelled - emails cannot be sent or added.
            /// </summary>
            Completed,
            /// <summary>
            /// Campaign is ongoing - emails can be sent and can be added.
            /// </summary>
            Ongoing,
        }

        [Required]
        public int CampaignStatusId { get; set; }

        [NotMapped]
        public EmailCampaignStatus CampaignStatus
        {
            get
            {
                return GetCampaignStatus(this.CampaignStatusId);
            }
            set
            {
                this.CampaignStatusId = (int)value;
            }
        }

        public static EmailCampaignStatus GetCampaignStatus(int campaignStatusId)
        {
            if (typeof(EmailCampaignStatus).IsEnumDefined(campaignStatusId))
                return (EmailCampaignStatus)campaignStatusId;
            else
                return EmailCampaignStatus.Undefined;
        }

        [Required]
        public int RecipientTypeId { get; set; }

        public enum EmailRecipientType
        {
            TestEventPresenters = -4,
            TestAllSitePresenters = -3,
            Test = -2,
            Individual = -1,
            Undefined = 0,
            AllSiteUsers,
            AllSitePresenters,
            EventPresenters
        }

        [NotMapped]
        public EmailRecipientType RecipientType
        {
            get
            {
                return GetRecipientType(this.RecipientTypeId);
            }
            set
            {
                this.RecipientTypeId = (int)value;
            }
        }

        public static EmailRecipientType GetRecipientType(int recipientTypeId)
        {
            if (typeof(EmailRecipientType).IsEnumDefined(recipientTypeId))
                return (EmailRecipientType)recipientTypeId;
            else
                return EmailRecipientType.Undefined;
        }

        [Required]
        [MaxLength(256)]
        public string EmailView { get; set; }

        [Required]
        [MaxLength(192)]
        public string Subject { get; set; }

        [MaxLength(192)]
        public string ReplyToAddress { get; set; }

        [Required]
        [MaxLength(512)]
        public string Description { get; set; }

        [Required]
        [MaxLength(256)]
        public string Salutation { get; set; }

        [Required]
        public DateTime CreatedUTC { get; protected set; }

        [Required]
        [MaxLength(128)]
        public string CreatedBy { get; set; }

        public Nullable<DateTime> UpdatedUTC { get; set; }

        [MaxLength(128)]
        public string UpdatedBy { get; set; }

        private ICollection<EmailItem> _emailItems;
        public virtual ICollection<EmailItem> EmailItems
        {
            get { return _emailItems ?? (_emailItems = new List<EmailItem>()); }
            protected set { _emailItems = value; }
        }
    }
}
