using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeCamp.Model
{
    //[Table("cc_ScheduledSessions")]
    public class ScheduledSession
    {
        //[Key]
        //[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey("Room")]
        public int RoomId { get; set; }
        //[ForeignKey("Session")]
        public int SessionId { get; set; }
        //[ForeignKey("Timeslot")]
        public int TimeslotId { get; set; }

        [Required]
        public virtual Room Room { get; set; }

        [Required]
        public virtual Session Session { get; set; }

        [Required]
        public virtual Timeslot Timeslot { get; set; }
    }
}
