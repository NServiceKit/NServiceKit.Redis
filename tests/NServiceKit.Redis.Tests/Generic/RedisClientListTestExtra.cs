using NUnit.Framework;
using NServiceKit.Common.Extensions;
using NServiceKit.Common.Tests.Models;
using NServiceKit.Redis.Generic;
using NServiceKit.Redis.Tests.Support;
using NServiceKit.Text;

namespace NServiceKit.Redis.Tests.Generic
{
    [TestFixture]
    public class RedisClientListTestExtra
    {
        const string ListId = "testlist";
        const string ListId2 = "testlist2";
        private IRedisList<CustomType> List;
        private IRedisList<CustomType> List2;


        private readonly IModelFactory<CustomType> factory = new CustomTypeFactory();

        protected IModelFactory<CustomType> Factory { get { return factory; } }

        private RedisClient client;
        private IRedisTypedClient<CustomType> redis;

        [SetUp]
        public void SetUp()
        {
            if (client != null)
            {
                client.Dispose();
                client = null;
            }
            client = new RedisClient(TestConfig.SingleHost);
            client.FlushAll();

            redis = client.GetTypedClient<CustomType>();

            List = redis.Lists[ListId];
            List2 = redis.Lists[ListId2];
        }

        [Test]
        public void Can_Remove_value_from_IList()
        {
            var storeMembers = Factory.CreateList();
            storeMembers.ForEach(List.Add);

            var equalItem = new CustomType() { CustomId = 4 };
            storeMembers.Remove(equalItem);
            List.Remove(equalItem);

            var members = List.ToList<CustomType>();

            Factory.AssertListsAreEqual(members, storeMembers);
        }

    }
}
