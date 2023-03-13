using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CarSales.Controllers.Resources
{
    public class MakeResource : KeyValuePairResource
    {
   
        public ICollection<KeyValuePairResource> Models { get; set; }

        public MakeResource()
        {
            Models = new Collection<KeyValuePairResource>();

        }
    }
}
