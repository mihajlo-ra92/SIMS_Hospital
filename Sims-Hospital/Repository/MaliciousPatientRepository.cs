using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using FileHandler;

namespace Repository
{
    public class MaliciouslyPatientRepository
    {
        public MaliciouslyPatientFileHandler MaliciouslyPatientFileHandler = new MaliciouslyPatientFileHandler();
        List<MaliciouslyPatient> maliciouslyPatients;

        public MaliciouslyPatientRepository()
        {
            maliciouslyPatients = MaliciouslyPatientFileHandler.Read();
        }

        public List<MaliciouslyPatient> ReadAll()
        {
            return maliciouslyPatients;
        }

        public List<MaliciouslyPatient> ReadByPatientId(int patientId)
        {
            return maliciouslyPatients.Where(x => x.Patient.Id == patientId).ToList();
        }

        public void Create(MaliciouslyPatient MaliciouslyPatient)
        {
            maliciouslyPatients.Add(MaliciouslyPatient);
            MaliciouslyPatientFileHandler.Write(maliciouslyPatients);
        }


    }
}
