using System;
using Models;
using Services;
using System.Web.Mvc;
using System.IO;
using System.Web;

namespace MyCarService.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientService clientService;

        public ClientController()
        {
            clientService = new ClientService();
        }
        // GET: Client
        public ActionResult CreateClient(int id = 0)
        {
            var model = new ClientModel();

            if (id != 0)
            {
                var client = clientService.GetById(id);
                model.Id = client.Id;
                model.FirstName = client.FirstName;
                model.LastName = client.LastName;
                model.DataOfBirth = client.DataOfBirth;
                model.Address = client.Address;
                model.Email = client.Email;
            }
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult UpdateClient(ClientModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            };

            Client client = new Client();

            if (model.Id != null)
            {
                client = clientService.GetById(model.Id.Value);
            }

            client.FirstName = model.FirstName;
            client.LastName = model.LastName;
            client.DataOfBirth = model.DataOfBirth;
            client.Address = model.Address;
            client.Email = model.Email;

            if (model.Photo != null)
            {
                client.Photo = model.Photo.FileName;
                SaveImageToDirectory(model.Photo, HttpContext.Server.MapPath("/Photo/"));
            }

            if (model.Id != null)
            {
                clientService.EditClient(client);
            }
            else
            {
                clientService.CreateClient(client);
            }

            var clients = clientService.GetAll();
            var clientsViewModel = new ClientViewModel();

            clients.ForEach(cl =>
            {
                var clientModel = new ClientItemViewModel();
                clientModel.FirstName = cl.FirstName;
                clientModel.LastName = cl.LastName;
                clientModel.Id = cl.Id;
                clientModel.Photo = String.IsNullOrWhiteSpace(cl.Photo) ? null : "/Photo/" + cl.Photo;

                clientsViewModel.Clients.Add(clientModel);
            });
            return View("../Home/Index", clientsViewModel);
        }

        private static void SaveImageToDirectory(HttpPostedFileBase httpPostedFileBase, string directory)
        {
            string filePath = Path.Combine(directory, httpPostedFileBase.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                httpPostedFileBase.InputStream.CopyTo(fileStream);
            }
        }

        public ActionResult DeleteClient(int id)
        {
            clientService.RemoveClient(id);

            var clients = clientService.GetAll();
            var clientsViewModel = new ClientViewModel();

            clients.ForEach(cl =>
            {
                var clientModel = new ClientItemViewModel();
                clientModel.FirstName = cl.FirstName;
                clientModel.LastName = cl.LastName;
                clientModel.Id = cl.Id;
                clientModel.Photo = String.IsNullOrWhiteSpace(cl.Photo) ? null : "/Photo/" + cl.Photo;

                clientsViewModel.Clients.Add(clientModel);
            });

            return View("../Home/Index", clientsViewModel);
        }
        public ActionResult Details(int id)
        {

            var clients = clientService.GetAll();
            var ClientDetailsViewModel = new ClientDetailsViewModel();

            clients.ForEach(cl =>
            {
                var clientModel = new ClientItemViewModel();
                clientModel.FirstName = cl.FirstName;
                clientModel.LastName = cl.LastName;
                clientModel.Id = cl.Id;
                clientModel.Photo = String.IsNullOrWhiteSpace(cl.Photo) ? null : "/Photo/" + cl.Photo;

                clientsViewModel.Clients.Add(clientModel);
            });
            return View(model);
        }
    }
}