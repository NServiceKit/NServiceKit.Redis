using System;
using NServiceKit.Common.Extensions;
using NServiceKit.Text;

namespace NServiceKit.Redis
{
	public class RedisLock 
		: IDisposable
	{
		private readonly RedisClient redisClient;
		private readonly string key;

		public RedisLock(RedisClient redisClient, string key, TimeSpan? timeOut)
		{
			this.redisClient = redisClient;
			this.key = key;

			ExecExtensions.RetryUntilTrue(
				() => redisClient.SetEntryIfNotExists(key, "lock " + DateTime.UtcNow.ToUnixTime()),
				timeOut
			);
		}

		public void Dispose()
		{
			redisClient.Remove(key);
		}
	}
}