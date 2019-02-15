using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo1.SignalRChat;

namespace SignalRDemo1.Controllers
{
    /// <summary>
    /// 电子白板教师端
    /// </summary>
    public class TeacherController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IHubContext<TeacherHub> _hubContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hubContext"></param>
        public TeacherController(IHubContext<TeacherHub> hubContext)
        {
            _hubContext = hubContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}