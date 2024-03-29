using System;
using System.Collections.Generic;
using ParallelProcessors.Processor;

namespace ParallelProcessors.DataContracts
{
    public class ParallelAction<T>
    {
        public bool IsParallel { get; set; }
        public T Request { get; set; }
        public Func<T, List<ActionErrorMessage>> Action { get;  set; }
        //public Func<T, List<ActionErrorMessage>> Action { get; set; }
    }
}