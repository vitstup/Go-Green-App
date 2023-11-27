using Microsoft.AspNetCore.Components;
using SoberApp.Code.Models;
using SoberApp.Shared;

namespace SoberApp.Code.BaseComponents
{
	public abstract class BaseSoberTimerPageComponent : ComponentBase, IDisposable
	{
		protected SobrietyTimer timer;

		private bool isActive;

		protected abstract Account GetAccount { get; }

		protected abstract TimerBlock GetTimerBlock { get; }

		protected override void OnInitialized()
		{
			isActive = true;
			timer = new SobrietyTimer(GetAccount);
			StateUpdater();
		}

		private async Task StateUpdater()
		{
			while (isActive)
			{
				timer.UpdateInfo();
				ChangeTimerValues();
				await Task.Delay(1000);
			}
		}

		private void ChangeTimerValues()
		{
			GetTimerBlock?.ChangeState();
		}

		public void Dispose()
		{
			isActive = false;
		}

	}
}