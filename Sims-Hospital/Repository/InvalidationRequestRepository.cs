using Dto;
using FileHandler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class InvalidationRequestRepository
    {
        public InvalidationRequestFileHandler InvalidationRequestFileHandler = new InvalidationRequestFileHandler();
        public List<InvalidationRequest> invalidationRequests;

        public InvalidationRequestRepository()
        {
            invalidationRequests = InvalidationRequestFileHandler.Read();
        }
        public List<InvalidationRequest> ReadAll()
        {
            return invalidationRequests;
        }
        public InvalidationRequest ReadById(int invalidationRequestId)
        {
            return invalidationRequests.Where(x => x.Id == invalidationRequestId).FirstOrDefault();
        }
        public void Create(CreateInvalidationRequestDTO NewInvalidationRequest)
        {
            InvalidationRequest InvalidationRequest = new InvalidationRequest()
            {
                Id = invalidationRequests.Count + 1,
                Medicine = NewInvalidationRequest.Medicine,
                Note = NewInvalidationRequest.Note,
                RequestState = NewInvalidationRequest.RequestState,
            };
            invalidationRequests.Add(InvalidationRequest);
            InvalidationRequestFileHandler.Write(invalidationRequests);
        }
    }
}
