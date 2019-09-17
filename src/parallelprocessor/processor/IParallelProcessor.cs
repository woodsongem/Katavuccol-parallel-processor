using System.Collections.Generic;
using ParallelProcessor.DataContracts;

namespace ParallelProcessor.Processor
{
    public interface IParallelProcessor
    {
        List<ActionErrorMessage> Execute<T>(List<ParallelAction<T>> parallelActions = null);
    }
}