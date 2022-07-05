using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public class MaliciouslyPatientService
    {
        public MaliciouslyPatientRepository MaliciouslyPatientRepository;

        public MaliciouslyPatientService(MaliciouslyPatientRepository maliciouslyPatientRepository)
        {
            MaliciouslyPatientRepository = maliciouslyPatientRepository;
        }
        public List<MaliciouslyPatient> ReadAll()
        {
            return MaliciouslyPatientRepository.ReadAll();
        }

        public List<MaliciouslyPatient> ReadByPatientId(int patientId)
        {
            return MaliciouslyPatientRepository.ReadByPatientId(patientId);
        }

        public void Create(MaliciouslyPatient MaliciouslyPatient)
        {
            MaliciouslyPatientRepository.Create(MaliciouslyPatient);
        }

        public bool IsPatientMaliciously(int patientId)
        {
            bool isTrue = false;
            List<MaliciouslyPatient> patients = ReadByPatientId(patientId);
            foreach (MaliciouslyPatient patient in patients)
            {
                int counterEdit = 0;
                foreach (MaliciouslyPatient nextPatient in patients)
                {
                    if(DateTime.Compare(patient.EditTime,nextPatient.EditTime) <= 0 && DateTime.Compare(patient.EditTime.AddDays(30), nextPatient.EditTime) >= 0)
                    {
                        counterEdit++;
                    }
                }
                if(counterEdit >= 5)
                {
                     isTrue = true;
                }
            }
            return isTrue;
        }


    }
}
