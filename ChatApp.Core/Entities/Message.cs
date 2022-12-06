using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Entities
{
    public class Message:BaseEntity
    {
        [ForeignKey("Member")]
        public Guid SendedById { get; set; }
        [ForeignKey("ChatRoom")]
        public Guid ChatRoomId { get; set; }


        public DateTime SentDate { get; set; }
        public bool Seen { get; set; }
        public DateTime SeenTime { get; set; }
        public string MessageText { get; set; }



        public Member Member { get; set; }
        public ChatRoom ChatRoom { get; set; }
    }
}
