using Deli.Setup;

namespace CleanupAttachments
{
	public class Plugin : DeliBehaviour
	{
		private readonly Hooks _hooks;

		public Plugin()
		{
			_hooks = new Hooks();
		}

		private void OnDestroy()
		{
			_hooks?.Dispose();
		}
	}
}