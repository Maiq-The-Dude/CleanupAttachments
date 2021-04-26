using FistVR;

namespace CleanupAttachments
{
	public class Hooks
	{

		public Hooks()
		{
			Hook();
		}

		public void Dispose()
		{
			Unhook();
		}

		private void Hook()
		{
			On.FistVR.FVRWristMenu.CleanUpScene_Guns += FVRWristMenu_CleanUpScene_Guns;
		}

		private void Unhook()
		{
			On.FistVR.FVRWristMenu.CleanUpScene_Guns -= FVRWristMenu_CleanUpScene_Guns;
		}

		private void FVRWristMenu_CleanUpScene_Guns(On.FistVR.FVRWristMenu.orig_CleanUpScene_Guns orig, FistVR.FVRWristMenu self)
		{
			var confirm = self.askConfirm_CleanupGuns;

			orig(self);

			if (!confirm)
			{
				return;
			}

			FVRFireArmAttachment[] array = UnityEngine.Object.FindObjectsOfType<FVRFireArmAttachment>();
			for (int i = array.Length - 1; i >= 0; i--)
			{
				if (!array[i].IsHeld && array[i].curMount == null && array[i].QuickbeltSlot == null)
				{
					UnityEngine.Object.Destroy(array[i].gameObject);
				}
			}
		}
	}
}
