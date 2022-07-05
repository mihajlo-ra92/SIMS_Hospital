using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Model;

namespace Controller
{
    public class MaliciouslyPatientController
    {
        public MaliciouslyPatientService MaliciouslyPatientService;

        public MaliciouslyPatientController(MaliciouslyPatientService maliciouslyPatientService)
        {
            MaliciouslyPatientService = maliciouslyPatientService;
        }


        public List<MaliciouslyPatient> ReadAll()
        {
            return MaliciouslyPatientService.ReadAll();
        }

        public List<MaliciouslyPatient> ReadByPatientId(int patientId)
        {
            return MaliciouslyPatientService.ReadByPatientId(patientId);
        }

        public void Create(MaliciouslyPatient MaliciouslyPatient)
        {
            MaliciouslyPatientService.Create(MaliciouslyPatient);
        }
        public bool IsPatientMaliciously(int patientId)
        {
            return MaliciouslyPatientService.IsPatientMaliciously(patientId);
        }
    }
}
