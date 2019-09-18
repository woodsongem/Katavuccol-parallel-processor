using System.Threading.Tasks;
using System;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using KatavuccolCommon.Extensions;
using ParallelProcessors.DataContracts;

namespace ParallelProcessors.Processor
{
    public class ParallelProcessor : IParallelProcessor
    {
        public List<ActionErrorMessage> Execute<T>(List<ParallelAction<T>> actions = null)
        {
            if (actions.AnyWithNullCheck())
                throw new ArgumentNullException();
            var nonParallels = actions.Where(x => !x.IsParallel);
            foreach (var action in nonParallels)
            {
                var actionErrorMessage = action.Action.Invoke(action.Request);
                if (actionErrorMessage.AnyWithNullCheck())
                    return actionErrorMessage;
            }

            var parallelActions = actions.Where(x => x.IsParallel);
            var parallelActionErrorMessages = new List<ActionErrorMessage>();
            Parallel.ForEach(parallelActions, (parallelAction) =>
            {
                var errorMessages = parallelAction.Action.Invoke(parallelAction.Request);
                if (errorMessages.AnyWithNullCheck())
                    parallelActionErrorMessages.AddRange(errorMessages);
            });
            return parallelActionErrorMessages;
        }
    }
}