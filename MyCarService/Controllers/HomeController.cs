using System;
using System.Web.Mvc;
using Models;
using Services;

namespace MyCarService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClientService clientService;

        public HomeController()
        {
            clientService = new ClientService();
        }

        public ActionResult Index()
        {
            var clients = clientService.GetAll();
            var clientsViewModel = new ClientViewModel();

            clients.ForEach(client =>
            {
                var clientModel = new ClientItemViewModel();
                clientModel.FirstName = client.FirstName;
                clientModel.LastName = client.LastName;
                clientModel.Id = client.Id;
                clientModel.Photo = String.IsNullOrWhiteSpace(client.Photo) ? null : "/Photo/" + client.Photo;

                clientsViewModel.Clients.Add(clientModel);
            });

            return View(clientsViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}