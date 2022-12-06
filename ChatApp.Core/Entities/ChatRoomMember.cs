using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Entities
{
    public class ChatRoomMember:BaseEntity
    {
        [ForeignKey("Member")]
        public Guid MemberId { get; set; }
        
        [ForeignKey("ChatRoom")]
        public Guid RoomId { get; set; }



        public Member Member { get; set; }
        public ChatRoom ChatRoom { get; set; }
    }
}
