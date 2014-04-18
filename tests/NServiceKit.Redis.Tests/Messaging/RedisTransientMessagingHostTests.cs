using NUnit.Framework;
using NServiceKit.Messaging;
using NServiceKit.Messaging.Tests;
using NServiceKit.Redis.Messaging;

namespace NServiceKit.Redis.Tests.Messaging
{
    [Category("Integration")]
	public class RedisTransientMessagingHostTests
		: TransientServiceMessagingTests
	{
		private IRedisClientsManager clientManager;
		private RedisTransientMessageFactory factory;

		public override void OnBeforeEachTest()
		{
			ResetConnections();

			using (var client = clientManager.GetClient())
			{
				client.FlushAll();
			}

			base.OnBeforeEachTest();
		}

		protected override IMessageFactory CreateMessageFactory()
		{
			return factory;
		}

		protected override TransientMessageServiceBase CreateMessagingService()
		{
			return factory.MessageService;
		}

		private void ResetConnections()
		{
			if (clientManager != null)
			{
				clientManager.Dispose();
				clientManager = null;
			}

			if (factory != null)
			{
				factory.Dispose();
				factory = null;
			}

			clientManager = new BasicRedisClientManager(TestConfig.MasterHosts);
			factory = new RedisTransientMessageFactory(clientManager);
		}
	}
}