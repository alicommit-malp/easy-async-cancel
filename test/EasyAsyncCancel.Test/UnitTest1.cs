using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EasyAsyncCancel.Test
{
    public class UnitTest1
    {
        private Task Task_NetworkBound()
        {
            return new HttpClient().GetStringAsync("https://dotnetfoundation.org");
        }

        private Task<string> Task_NetworkBound_T()
        {
            return new HttpClient().GetStringAsync("https://dotnetfoundation.org");
        }

        [Fact]
        public void Cancel_With_Milliseconds()
        {
            Assert.ThrowsAsync<OperationCanceledException>(
                async () => { await Task_NetworkBound().CancelAfter(1000); });

            Assert.ThrowsAsync<OperationCanceledException>(
                async () => { await Task_NetworkBound_T().CancelAfter(1000); });
        }

        [Fact]
        public async Task Cancel_With_Token_During_Execution_Before_Finishing()
        {
            var concurrentBag = new ConcurrentBag<int>();
            var task = new List<Task>();
            for (var i = 0; i < 100; i++)
            {
                var i1 = i;
                task.Add(Task.Run(async () =>
                {
                    await Task.Delay(new Random().Next(5) * 1000);
                    concurrentBag.Add(i1);
                }));
            }

            var cts = new CancellationTokenSource();
            cts.CancelAfter(1000);
            await Task.WhenAll(task).CancelWith(cts.Token,true);
            Assert.True(concurrentBag.Count<100);
        }

        [Fact]
        public async Task Cancel_With_Token_After_Finishing()
        {
            var concurrentBag = new ConcurrentBag<int>();
            var task = new List<Task>();
            for (var i = 0; i < 100; i++)
            {
                var i1 = i;
                task.Add(Task.Run(async () =>
                {
                    await Task.Delay(new Random().Next(5) * 1000);
                    concurrentBag.Add(i1);
                }));
            }

            await Task.WhenAll(task).CancelAfter(5000,true);
            Assert.True(concurrentBag.Count==100);
        }
        
        [Fact]
        public async Task Cancel_With_Token_After_Finishing_TimeSpan()
        {
            var concurrentBag = new ConcurrentBag<int>();
            var task = new List<Task>();
            for (var i = 0; i < 100; i++)
            {
                var i1 = i;
                task.Add(Task.Run(async () =>
                {
                    await Task.Delay(new Random().Next(5) * 1000);
                    concurrentBag.Add(i1);
                }));
            }

            await Task.WhenAll(task).CancelAfter(TimeSpan.FromSeconds(5),true);
            Assert.True(concurrentBag.Count==100);
        }
        
        
        [Fact]
        public void Cancel_With_Token_network_bound_TimeSpan()
        {
            Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                await Task_NetworkBound().CancelAfter(TimeSpan.FromSeconds(1));
            });
        }

        [Fact]
        public void Cancel_With_Token_network_bound()
        {
            Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                var cts = new CancellationTokenSource();
                cts.CancelAfter(1000);
                await Task_NetworkBound().CancelWith(cts.Token);
            });
        }
        
        [Fact]
        public void Cancel_With_Token_network_bound_T()
        {

            Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                var cts = new CancellationTokenSource();
                cts.CancelAfter(1000);
                await Task_NetworkBound_T().CancelWith(cts.Token);
            });
        }
    }
}