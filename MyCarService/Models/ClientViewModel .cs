
using System.Collections.Generic;

namespace Models
{
    public class ClientViewModel
    {
        public List<ClientItemViewModel> Clients { get; set; }
        public string Search { get; set; }

        public ClientViewModel()
        {
            Clients = new List<ClientItemViewModel>();
        }

    }
}