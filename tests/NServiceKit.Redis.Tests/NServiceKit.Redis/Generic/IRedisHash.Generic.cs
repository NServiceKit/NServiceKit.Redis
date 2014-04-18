//
// https://github.com/mythz/ServiceStack.Redis
// ServiceStack.Redis: ECMA CLI Binding to the Redis key-value storage system
//
// Authors:
//   Demis Bellot (demis.bellot@gmail.com)
//
// Copyright 2010 Liquidbit Ltd.
//
// Licensed under the same terms of Redis and ServiceStack: new BSD license.
//

using System.Collections.Generic;
using NServiceKit.DesignPatterns.Model;

namespace NServiceKit.Redis.Generic
{
	public interface IRedisHash<TKey, TValue> : IDictionary<TKey, TValue>, IHasStringId
	{
		Dictionary<TKey, TValue> GetAll();
	}

}
