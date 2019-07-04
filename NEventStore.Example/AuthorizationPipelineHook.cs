namespace NEventStore.Example
{
	using System;

	public class AuthorizationPipelineHook : IPipelineHook
	{
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public ICommit Select(ICommit committed)
		{
			// return null if the user isn't authorized to see this commit
			return committed;
		}

		public bool PreCommit(CommitAttempt attempt)
		{
			// Can easily do logging or other such activities here
			return true; // true == allow commit to continue, false = stop.
		}

		public void PostCommit(ICommit committed)
		{
			// anything to do after the commit has been persisted.
		}

		public void OnDeleteStream(string bucketId, string streamId)
		{
			// anything to do while a stream gets deleted
		}

		public void OnPurge(string bucketId)
		{
			// anything to do while a stream gets purged
		}

		protected virtual void Dispose(bool disposing)
		{
			// no op
		}
	}
}