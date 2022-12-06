using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Entities
{
    public class Member:BaseEntity
    {
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string UserMail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Activated { get; set; }



        public ICollection<ChatRoomMember> ChatRooms { get; set; }
        public ICollection<Message> MemberMessages { get; set; }

    }
}
