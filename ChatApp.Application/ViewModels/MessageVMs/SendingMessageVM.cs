using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.ViewModels.Message
{
    public class SendingMessageVM
    {
        [ForeignKey("Member")]
        public int SendedById { get; set; }
        [ForeignKey("ChatRoom")]
        public int ChatRoomId { get; set; }


        public DateTime SentDate { get; set; }
        public string MessageText { get; set; }
        

        public Domain.Entities.Member Member { get; set; }
        public ChatRoom ChatRoom { get; set; }
    }
}
