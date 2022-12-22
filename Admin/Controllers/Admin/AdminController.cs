using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Admin.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly IMapper mapper;
        private readonly IToastNotification _toastNotification;

        public AdminController(IMapper mapper, IToastNotification toastNotification)
        {
            this.mapper = mapper;
            _toastNotification = toastNotification;
        }

        #region Dashboard
        public IActionResult Index()
        {
            return View();
        }
        #endregion

    }
}
