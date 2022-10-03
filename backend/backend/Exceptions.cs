namespace backend
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, Guid id) : base($"{entityName} not found: {id}") { }
        public NotFoundException(string entityName, string id) : base($"{entityName} not found: {id}") { }
        public NotFoundException(string entityName, string fieldName, string searchValue) : base($"{entityName} not found: {fieldName} with value {searchValue}") { }
    }

    public class DuplicateException : Exception
    {
        public DuplicateException(string message) : base(message) { }
        public DuplicateException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class ServiceUnavailableException : Exception
    {
        public ServiceUnavailableException(string message) : base(message) { }
        public ServiceUnavailableException(string message, Exception innerException) : base(message, innerException) { }
    }
}
