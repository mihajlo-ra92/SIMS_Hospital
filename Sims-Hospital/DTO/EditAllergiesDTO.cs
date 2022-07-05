using Dto;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EditAllergiesDTO : CreateAllergiesDTO
    {
        public int Id { get; set; }
    }
}
