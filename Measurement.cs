using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AzureFunctionsAPISQL
{
    public class Measurement
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public float Temperature { get; set; }
    }
}
