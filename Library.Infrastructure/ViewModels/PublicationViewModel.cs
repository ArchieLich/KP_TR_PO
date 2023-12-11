using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.ViewModels
{
    public class PublicationViewModel
    {
        public long id {  get; set; }
        public string name { get; set; }
        public long? cost { get; set; }
    }
}
