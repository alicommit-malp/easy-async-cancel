using System;
using System.Threading;
using System.Threading.Tasks;

namespace EasyAsyncCancel
{
    public static class TaskCancellationExtension
    {
        /// <summary>
        /// Add cancellation functionality to <see cref="Task"/> of <typeparamref name="T"/>
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see cref="Task"/></returns>
        /// <exception cref="OperationCanceledException"></exception>
        [Obsolete("User CancelWith instead")]
        public static Task<T> CancelAfter<T>(
            this Task<T> task, CancellationToken cancellationToken, bool swallowCancellationException = false)
        {
            return TaskCancellationInternals.CancelWithInternal(task, cancellationToken, swallowCancellationException);
        }

        /// <summary>
        /// add cancellation functionality to Task T 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static Task<T> CancelWith<T>(
            this Task<T> task, CancellationToken cancellationToken, bool swallowCancellationException = false)
        {
            return TaskCancellationInternals.CancelWithInternal(task, cancellationToken, swallowCancellationException);
        }

        /// <summary>
        /// add cancellation functionality to Task T with exception message 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <param name="message"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        [Obsolete("User CancelWith instead")]
        public static Task<T> CancelAfter<T>(
            this Task<T> task, CancellationToken cancellationToken, string message,
            bool swallowCancellationException = false)
        {
            return TaskCancellationInternals.CancelWithInternal(task, cancellationToken, message,
                swallowCancellationException);
        }

        /// <summary>
        /// add cancellation functionality to Task T with exception message 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <param name="message"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static Task<T> CancelWith<T>(
            this Task<T> task, CancellationToken cancellationToken, string message,
            bool swallowCancellationException = false)
        {
            return TaskCancellationInternals.CancelWithInternal(task, cancellationToken, message,
                swallowCancellationException);
        }

        /// <summary>
        /// add cancellation functionality to Tasks 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        [Obsolete("User CancelWith instead")]
        public static Task CancelAfter(
            this Task task, CancellationToken cancellationToken, bool swallowCancellationException = false)
        {
            return TaskCancellationInternals.CancelWithInternal(task, cancellationToken, swallowCancellationException);
        }

        /// <summary>
        /// add cancellation functionality to Tasks 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static Task CancelWith(
            this Task task, CancellationToken cancellationToken, bool swallowCancellationException = false)
        {
            return TaskCancellationInternals.CancelWithInternal(task, cancellationToken, swallowCancellationException);
        }

        /// <summary>
        /// add cancellation functionality to Tasks with exception message 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        [Obsolete("User CancelWith instead")]
        public static Task CancelAfter(
            this Task task, CancellationToken cancellationToken, string message,
            bool swallowCancellationException = false)
        {
            return TaskCancellationInternals.CancelWithInternal(task, cancellationToken, message,
                swallowCancellationException);
        }

        /// <summary>
        /// add cancellation functionality to Tasks with exception message 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static Task CancelWith(
            this Task task, CancellationToken cancellationToken, string message,
            bool swallowCancellationException = false)
        {
            return TaskCancellationInternals.CancelWithInternal(task, cancellationToken, message,
                swallowCancellationException);
        }

        /// <summary>
        /// add cancellation functionality to Task T
        /// </summary>
        /// <param name="task"></param>
        /// <param name="milliseconds"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static Task<T> CancelAfter<T>(
            this Task<T> task, int milliseconds, bool swallowCancellationException = false)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(milliseconds);
            return TaskCancellationInternals.CancelWithInternal(task, cts.Token, swallowCancellationException);
        }


        /// <summary>
        /// add cancellation functionality to Task T with exception message
        /// </summary>
        /// <param name="task"></param>
        /// <param name="milliseconds"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <param name="message"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static Task<T> CancelAfter<T>(
            this Task<T> task, int milliseconds, string message, bool swallowCancellationException = false)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(milliseconds);
            return TaskCancellationInternals.CancelWithInternal(task, cts.Token, message, swallowCancellationException);
        }

        /// <summary>
        /// add cancellation functionality to Task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="milliseconds"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static Task CancelAfter(
            this Task task, int milliseconds, bool swallowCancellationException = false)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(milliseconds);
            return TaskCancellationInternals.CancelWithInternal(task, cts.Token, swallowCancellationException);
        }


        /// <summary>
        /// add cancellation functionality to Task with exception message
        /// </summary>
        /// <param name="task"></param>
        /// <param name="milliseconds"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static Task CancelAfter(
            this Task task, int milliseconds, string message, bool swallowCancellationException = false)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(milliseconds);
            return TaskCancellationInternals.CancelWithInternal(task, cts.Token, message, swallowCancellationException);
        }


        /// <summary>
        /// add cancellation functionality to Task T
        /// </summary>
        /// <param name="task"></param>
        /// <param name="timeSpan"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static Task<T> CancelAfter<T>(
            this Task<T> task, TimeSpan timeSpan, bool swallowCancellationException = false)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(timeSpan);
            return TaskCancellationInternals.CancelWithInternal(task, cts.Token, swallowCancellationException);
        }


        /// <summary>
        /// add cancellation functionality to Task T with exception message
        /// </summary>
        /// <param name="task"></param>
        /// <param name="timeSpan"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <param name="message"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static Task<T> CancelAfter<T>(
            this Task<T> task, TimeSpan timeSpan, string message, bool swallowCancellationException = false)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(timeSpan);
            return TaskCancellationInternals.CancelWithInternal(task, cts.Token, message, swallowCancellationException);
        }

        /// <summary>
        /// add cancellation functionality to Task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="timeSpan"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static Task CancelAfter(
            this Task task, TimeSpan timeSpan, bool swallowCancellationException = false)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(timeSpan);
            return TaskCancellationInternals.CancelWithInternal(task, cts.Token, swallowCancellationException);
        }


        /// <summary>
        /// add cancellation functionality to Task with exception message
        /// </summary>
        /// <param name="task"></param>
        /// <param name="timeSpan"></param>
        /// <param name="swallowCancellationException">If True the <see cref="OperationCanceledException"/> will be swallowed</param>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public static Task CancelAfter(
            this Task task, TimeSpan timeSpan, string message, bool swallowCancellationException = false)
        {
            var cts = new CancellationTokenSource();
            cts.CancelAfter(timeSpan);
            return TaskCancellationInternals.CancelWithInternal(task, cts.Token, message, swallowCancellationException);
        }
    }
}