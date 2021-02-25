using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyAsyncCancel
{
    internal static class TaskCancellationInternals
    {
        public static async Task<T> CancelWithInternal<T>(Task<T> task, CancellationToken cancellationToken,
            bool swallowCancellationException = false)
        {
            var tcs = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(
                s => ((TaskCompletionSource<bool>) s).TrySetResult(true), tcs))
                if (task != await Task.WhenAny(task, tcs.Task))
                    if (!swallowCancellationException)
                        throw new OperationCanceledException(cancellationToken);
                    else return default;
            return await task;
        }

        public static async Task<T> CancelWithInternal<T>(Task<T> task, CancellationToken cancellationToken,
            string message, bool swallowCancellationException = false)
        {
            var tcs = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(
                s => ((TaskCompletionSource<bool>) s).TrySetResult(true), tcs))
                if (task != await Task.WhenAny(task, tcs.Task))
                    if (!swallowCancellationException)
                        throw new OperationCanceledException(message, cancellationToken);
                    else return default;
            return await task;
        }


        public static async Task CancelWithInternal(Task task, CancellationToken cancellationToken,
            bool swallowCancellationException = false)
        {
            var tcs = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(
                s => ((TaskCompletionSource<bool>) s).TrySetResult(true), tcs))
                if (task != await Task.WhenAny(task, tcs.Task))
                    if (!swallowCancellationException)
                        throw new OperationCanceledException(cancellationToken);
                    else return;
            await task;
        }


        public static async Task CancelWithInternal(
            Task task, CancellationToken cancellationToken, string message, bool swallowCancellationException = false)
        {
            var tcs = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(
                s => ((TaskCompletionSource<bool>) s).TrySetResult(true), tcs))
                if (task != await Task.WhenAny(task, tcs.Task))
                    if (!swallowCancellationException)
                        throw new OperationCanceledException(message, cancellationToken);
                    else return;
            await task;
        }
    }
}