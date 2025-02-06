using System.ComponentModel.DataAnnotations;

namespace Lucid.Web.Models.VanModels
{
    public class VanCreateVm
    {        
        public string Name { get; set; }
        public string Driver { get; set; }
        public string Mobile { get; set; }
    }
}
