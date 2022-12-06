using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Entities
{
    public class ChatRoom:BaseEntity
    {
        public string RoomName { get; set; }
        public DateTime CreatedDate { get; set; }



        public ICollection<ChatRoomMember> RoomMembers { get; set; }
        public ICollection<Message> RoomMessages { get; set; }
    }
}
