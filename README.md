# Async/Await easy cancellation in c#

Using async/await is so fun but in the same time there are plenty of situations which the awaiting part can stuck forever, specially when there is any involvement of programming over the network. Other than that there are situations which the app must not wait more than a timeout for a response. 

Therefore, the ability to set a timeout for a asynchronous operation is a must, by using CancellationToken one can achieve this and this post will demonstrate an easier method of using these CancellationTokens by applying an extension method for the Task object type.
 
## Usage
Let's say there is a Task which it can take unknown amount of time to finish  

```c#
private async Task Task_NetworkBound()
{
    await new HttpClient().GetStringAsync("https://dotnetfoundation.org");
}
private async Task<string> Task_NetworkBound_T()
{
    return await new HttpClient().GetStringAsync("https://dotnetfoundation.org");
}
```
In order for the task to get canceled after 1 seconds 

Install it from [Nuget](https://www.nuget.org/packages/easyAsyncCancel/)

```bash
dotnet add package easyAsyncCancel
```


```c#

var cts = new CancellationTokenSource();
cts.CancelAfter(1000);

await Task_NetworkBound().CancelWith(cts.Token);
await Task_NetworkBound_T().CancelWith(cts.Token,"Custom Message");

await Task_NetworkBound_T().CancelAfter(1000);
await Task_NetworkBound().CancelAfter(1000,"Custom Message");
``` 

Happy coding :)
