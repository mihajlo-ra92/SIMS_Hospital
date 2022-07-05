using Dto;
using Model;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class InvalidationRequestController
    {
        public InvalidationRequestService InvalidationRequestService;

        public InvalidationRequestController(InvalidationRequestService invalidationRequestService)
        {
            this.InvalidationRequestService = invalidationRequestService;
        }
        public void Create(CreateInvalidationRequestDTO NewRequest)
        {
            InvalidationRequestService.Create(NewRequest);
        }
        public List<InvalidationRequest> ReadAll()
        {
            return InvalidationRequestService.ReadAll();
        }
        public InvalidationRequest ReadById(int id)
        {
            return InvalidationRequestService.ReadById(id);
        }
    }
}
