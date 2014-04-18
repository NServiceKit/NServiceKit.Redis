using System;
using System.Collections.Generic;

namespace NServiceKit.Redis
{
    public interface IRedisFailover
    {
        List<Action<IRedisClientsManager>> OnFailover { get; } 

        void FailoverTo(params string[] readWriteHosts);
    }
}