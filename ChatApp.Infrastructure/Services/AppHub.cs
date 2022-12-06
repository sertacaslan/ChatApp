using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Persistance.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Services
{
    [Authorize]
    public class AppHub : Hub
    {
        private readonly ChatAppContext _dbContext;
        private string ChoosedRoomId;


        public AppHub(ChatAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SendMessageAsync(string message)
        {

            Guid chatroomID = await _dbContext.ChatRooms.Select(x => x.id).FirstAsync();//buradan odayı çek
            Guid userID = await _dbContext.Members.Where(x => x.UserName == Context.User.Identity.Name).Select(x => x.id).FirstAsync();

            var mesaj = new Message()
            {
                ChatRoomId = chatroomID,
                MessageText = message,
                SendedById = userID,
                SentDate = DateTime.Now,
                Seen = false,
                id = new Guid()
            };
            await _dbContext.Messages.AddAsync(mesaj);
            await _dbContext.SaveChangesAsync();

            await Clients.Others.SendAsync("getMessage", message);

        }

        public async Task JoinRoom(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }

        public override async Task OnConnectedAsync()
        {
            string username = Context.User.Identity.Name;
            Member user = _dbContext.Members.SingleOrDefault(u => u.UserName == Context.User.Identity.Name);
            var chatRooms = _dbContext.ChatRooms.Where(x => x.RoomMembers.Any(z => z.MemberId == user.id)).ToList();

            foreach (var item in chatRooms)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, item.RoomName);
                await Clients.Caller.SendAsync("listRooms", item.RoomName);
            }

            await Clients.Caller.SendAsync("getUserName", username);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {

            return base.OnDisconnectedAsync(exception);
        }
    }
}
