using Model;
using System;

namespace Dto
{
    public class CreateInvalidationRequestDTO
    {
        public Medicine Medicine { get; set; }
        public string Note { get; set; }
        public RequestStateType RequestState { get; set; }
    }
}
