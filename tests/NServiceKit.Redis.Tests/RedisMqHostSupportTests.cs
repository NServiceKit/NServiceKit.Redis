using NUnit.Framework;
using NServiceKit.Messaging;
using NServiceKit.Messaging.Tests.Services;
using NServiceKit.Redis.Messaging;

namespace NServiceKit.Redis.Tests
{
    [TestFixture, Category("Integration")]
    public class RedisMqHostSupportTests
    {
        [Test]
        public void Does_serialize_to_correct_MQ_name()
        {
            var message = new Message<Greet>(new Greet {Name = "Test"}) {};

            var mqClient = new RedisMessageQueueClient(TestConfig.BasicClientManger);

            mqClient.Publish(message);
        }
    }
}