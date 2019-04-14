using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using easyAsyncCancel;
using NUnit.Framework;

namespace test.easyAsyncCancel
{
    [TestFixture]
    public class EasyAsyncCancellationTest
    {
        private async Task Task_NetworkBound()
        {
            await new HttpClient().GetStringAsync("https://dotnetfoundation.org");
        }

        private async Task<string> Task_NetworkBound_T()
        {
            return await new HttpClient().GetStringAsync("https://dotnetfoundation.org");
        }

        [Test]
        public void Test_CancelWithMilliseconds()
        {
            Assert.ThrowsAsync<OperationCanceledException>(
                async () => { await Task_NetworkBound().CancelAfter(1000); });

            Assert.ThrowsAsync<OperationCanceledException>(
                async () => { await Task_NetworkBound_T().CancelAfter(1000); });
        }


        [Test]
        public void Test_CancelWithToken()
        {
            Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                var cts = new CancellationTokenSource();
                cts.CancelAfter(1000);
                await Task_NetworkBound().CancelAfter(cts.Token);
            });


            Assert.ThrowsAsync<OperationCanceledException>(async () =>
            {
                var cts = new CancellationTokenSource();
                cts.CancelAfter(1000);
                await Task_NetworkBound_T().CancelAfter(cts.Token);
            });
        }
    }
}