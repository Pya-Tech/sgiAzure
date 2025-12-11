using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHook.Application.Interfaces.Config
{
    public interface IQueueConfiguration
    {
        string RoutingKey { get; set; }

        string QueueName { get; set; }
    }
}
