using ChatApp.Application.ViewModels.Message;
using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Persistance.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatApp.WEB.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        //private int messageShowCount = 5;//core a taşınacak enum olabilir
        private readonly ChatAppContext _dbContext;
        public RoomController(ChatAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()//pagination
        {

            return View();
        }
 
    }
}
