using DITutorial.Interfaces;

namespace DITutorial
{
    public class OperationLogger
    {
        private readonly ITransientOperation _transientOperation;
        private readonly IScopedOperation _scopedOperation;
        private readonly ISingletonOperation _singletonOperation;
        public OperationLogger(ISingletonOperation singletonOperation, IScopedOperation scopedOperation, ITransientOperation transientOperation)
        {
            _singletonOperation = singletonOperation;
            _scopedOperation = scopedOperation;
            _transientOperation = transientOperation;
        }

        public void LogOperations(string scope)
        {
            LogOperation(_transientOperation, scope, "Always different");
            LogOperation(_scopedOperation, scope, "Changes only with scope");
            LogOperation(_singletonOperation, scope, "Always the same");
        }

        private void LogOperation<T>(T operation, string scope, string message) where T : IOperation
        {
            Console.WriteLine($"{scope} : {typeof(T).Name,-19} [ {operation.OperationId}...{message,-23}]");
        }
    }
}