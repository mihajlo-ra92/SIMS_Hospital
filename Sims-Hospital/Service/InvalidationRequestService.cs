using Dto;
using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class InvalidationRequestService
    {
        public InvalidationRequestRepository InvalidationRequestRepository;
        public MedicineRepository MedicineRepository;

        public InvalidationRequestService(InvalidationRequestRepository invalidationRequestRepository,
            MedicineRepository medicineRepository)
        {
            InitializeRepositories(invalidationRequestRepository, medicineRepository);
        }
        private void InitializeRepositories(InvalidationRequestRepository invalidationRequestRepository,
            MedicineRepository medicineRepository)
        {
            this.InvalidationRequestRepository = invalidationRequestRepository;
            this.MedicineRepository = medicineRepository;
        }
        public List<InvalidationRequest> ReadAll()
        {
            List<InvalidationRequest> allInvalidationRequests = InvalidationRequestRepository.ReadAll();
            List<Medicine> allMedicines = MedicineRepository.ReadAll();
            BindMedicinesWithFreeDays(allMedicines, allInvalidationRequests);
            return InvalidationRequestRepository.ReadAll();
        }
        public void BindMedicinesWithFreeDays(IEnumerable<Medicine> allMedicines,
            IEnumerable<InvalidationRequest> allInvalidationRequests)
        {
            allInvalidationRequests.ToList().ForEach(InvalidationRequest =>
            {
                InvalidationRequest.Medicine = FindMedicineById(allMedicines, InvalidationRequest.Medicine.Id);
            });
        }
        public Medicine FindMedicineById(IEnumerable<Medicine> allMedicines, int id)
        {
            return allMedicines.SingleOrDefault(medicine => medicine.Id == id);
        }
        public void Create(CreateInvalidationRequestDTO NewInvalidationRequest)
        {
            InvalidationRequestRepository.Create(NewInvalidationRequest);
        }
        public InvalidationRequest ReadById(int id)
        {
            return InvalidationRequestRepository.ReadById(id);
        }
    }
}
