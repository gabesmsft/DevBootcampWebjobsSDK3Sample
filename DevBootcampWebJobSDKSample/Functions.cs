using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace DevBootcampWebJobSDKSample
{
    public class Functions
    {
        public static void ProcessQueueMessage([QueueTrigger("myfakequeue")] string message, ILogger logger)
        {
            logger.LogInformation(message);
        }
    }
}
