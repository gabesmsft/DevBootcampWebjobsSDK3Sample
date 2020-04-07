using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace DevBootcampWebJobSDKSample
{
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("myfakequeue")] string message, ILogger logger)
        {
            var shutdownWatcher = new WebJobsShutdownWatcher();
            shutdownWatcher.Token.Register(() => ShutdownRequested(logger));
            Thread.Sleep(30000);
            logger.LogInformation(message);
        }
        private static void ShutdownRequested(ILogger logger)
        {
            logger.LogInformation("shutdown method entered");
            //do some work before the shutdown
            //Thread.Sleep(30000);
            logger.LogInformation("shutdown method done");
        }
    }
}
