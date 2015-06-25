using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeCamp.Model
{
    //[Table("cc_Rooms")]
    public class Room
    {
        //[Key]
        //[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey("Building")]
        public int BuildingId { get; set; }

        [Required]
        public virtual Building Building { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// Optional - to be shown if set
        /// </summary>
        public Nullable<int> Floor { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public bool ShowToPublic { get; set; }

        private ICollection<ScheduledSession> _scheduledSessions;
        public virtual ICollection<ScheduledSession> ScheduledSessions
        {
            get { return _scheduledSessions ?? (_scheduledSessions = new List<ScheduledSession>()); }
            protected set { _scheduledSessions = value; }
        }
    }
}
