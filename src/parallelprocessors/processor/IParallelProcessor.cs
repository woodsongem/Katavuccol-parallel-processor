using System.Collections.Generic;
using ParallelProcessors.DataContracts;

namespace ParallelProcessors.Processor
{
    public interface IParallelProcessor
    {
        List<ActionErrorMessage> Execute<T>(List<ParallelAction<T>> parallelActions = null);
    }
}