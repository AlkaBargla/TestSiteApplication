using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Test_Site.Models;

namespace Test_Site.Controllers
{
	public class HomeController : Controller
	{
		private static List<User> Users = new List<User>();

		private int nextId = 1;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
		public int SaveUserInformation(User userInformation)
		{
			userInformation.UserId = nextId++;

			Users.Add(userInformation);

			return userInformation.UserId.Value;
		}

		public ActionResult UserInformation(int userId)
		{
			User user = Users.First(u => u.UserId == userId);
			return View(user);
		}
	}
}