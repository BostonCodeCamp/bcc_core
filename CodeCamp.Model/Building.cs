using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeCamp.Model
{
    //[Table("cc_Buildings")]
    public class Building
    {
        //[Key]
        //[DatabaseGenerated(System.ComponentModel.DataAnnotations.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[ForeignKey("Event")]
        public int EventId { get; set; }

        [Required]
        public virtual Event Event { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        private ICollection<Room> _rooms;
        public virtual ICollection<Room> Rooms
        {
            get { return _rooms ?? (_rooms = new List<Room>()); }
            protected set { _rooms = value; }
        }
    }
}
