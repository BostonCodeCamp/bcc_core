using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeCamp.Model
{
    //[Table("cc_TimeSlots")]
    public class Timeslot
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

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        private ICollection<ScheduledSession> _scheduledSessions;
        public virtual ICollection<ScheduledSession> ScheduledSessions
        {
            get { return _scheduledSessions ?? (_scheduledSessions = new List<ScheduledSession>()); }
            protected set { _scheduledSessions = value; }
        }
    }
}
