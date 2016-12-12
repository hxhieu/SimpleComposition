using System;

namespace SimpleComposition.Exceptions
{
    public class ContainerInitialiseException : Exception
    {
        public ContainerInitialiseException() : base("SimpleComposition is not initialized correctly. Make sure the chain SimpleComposition.Register().Build() is called before using SimpleComposition.") { }
    }
}
