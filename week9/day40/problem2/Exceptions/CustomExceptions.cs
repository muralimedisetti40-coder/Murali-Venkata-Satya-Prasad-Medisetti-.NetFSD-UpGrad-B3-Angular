using System;

namespace WebApplication9.API.Exceptions
{
    // 404 - Not Found
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    // 400 - Bad Request
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) { }
    }
}