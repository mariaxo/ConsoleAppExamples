using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

//task created, will be completed when a thread is free, so we dk when exactly 
Task<string[]> TaskReadingFileAsync = File.ReadAllLinesAsync("TextFile1.txt");

ThreadPool.QueueUserWorkItem();


Task a = Example.Main();


//status of the task
Console.WriteLine(TaskReadingFileAsync.Status);

//we can get the result of the task but it's not a good idea because it blocks the main thread
Console.WriteLine("TaskReadingFileAsync.Result blocks the thread.");

//this doesn't block, inside we can use the.Result
TaskReadingFileAsync.ContinueWith(x =>
                                {
                                    //no exception happens
                                    if (x.IsFaulted)
                                    {
                                        global::System.Console.Error.WriteLine(x.Exception);
                                    }
                                    //Task will be completed here so we can use its result
                                    foreach (var line in x.Result)
                                    {
                                        Console.WriteLine(line);
                                    }
                                });

Console.WriteLine("I am here now");


#region Now Using async/ await
    //
    
#endregion