using static System.Guid;
using DITutorial.Interfaces;

namespace DITutorial
{
    public class DefaultOperation : ITransientOperation, IScopedOperation, ISingletonOperation
    {
        public string OperationId { get; } = NewGuid().ToString()[^4..];
    }
}