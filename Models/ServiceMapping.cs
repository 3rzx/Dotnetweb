using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetWeb.Models
{
    public class ServiceMapping
    {
        [Required]
        public string ServiceId { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
