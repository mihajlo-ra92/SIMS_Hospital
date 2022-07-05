using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sims_Hospital.Utils
{
    public class UserUtils
    {
        public static string PrintGenderSRB(Gender Gender)
        {
            if (Gender == Gender.Female)
            {
                return "zenski";
            }
            return "muski";
        }
    }
}
