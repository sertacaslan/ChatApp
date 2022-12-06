using ChatApp.Application.Abstractions.Services;
using ChatApp.Application.ViewModels.Message;
using ChatApp.Infrastructure.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Infrastructure.Persistance.Services
{
    public class MessageService : IMessageService
    {
        private readonly IHubContext<AppHub> _hubContext;
        private readonly DbContext _dbContext;

        public MessageService(IHubContext<AppHub> hubContext, DbContext dbContext)
        {
            _hubContext = hubContext;
            _dbContext = dbContext;
        }



    }
}
