﻿using FluentValidation.Results;

namespace Dls.Erp.Transversal.Common
{
    public  class ResponseGeneric<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
