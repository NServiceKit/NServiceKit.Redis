using System;

namespace NServiceKit.Redis.Support.Locking
{
    /// <summary>
    /// Locking strategy interface
    /// </summary>
	public interface ILockingStrategy
	{
		IDisposable ReadLock();

		IDisposable WriteLock();
	}
}