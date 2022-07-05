using Dto;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CreateAllergiesDTO
    {
        public List<string> Allergens { get; set; }
        public List<Medicine> Medicines{ get; set; }
        public Patient Patient{ get; set; }
    }
}
