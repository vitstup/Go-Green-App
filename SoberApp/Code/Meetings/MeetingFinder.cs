using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoberApp.Code.Meetings
{
	public class MeetingFinder
	{
		public async Task FindMeeting()
		{

			try
			{
				var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

				if (status != PermissionStatus.Granted)
				{
					status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
				}

				if (status == PermissionStatus.Granted)
				{
					try
					{
						var location = await Geolocation.GetLocationAsync(
					new GeolocationRequest()
					{
						DesiredAccuracy = GeolocationAccuracy.Medium,
						Timeout = TimeSpan.FromSeconds(5),
					}
					);

						if (location == null) location = await Geolocation.GetLastKnownLocationAsync();

						if (location == null)
						{
							await App.Current.MainPage.DisplayAlert("Whoups!", "Unable to check your geolocation", "Ok");
						}

						string url = $"https://www.aa.org/find-aa/north-america?dist=4&lat={location.Latitude}&lng={location.Longitude}";

						await Launcher.OpenAsync(url);
					}
					catch
					{
						await App.Current.MainPage.DisplayAlert("Whoups!", "Unable to check your geolocation", "Ok");
					}
				}
				else
				{
					await App.Current.MainPage.DisplayAlert("Whoups!", "Unable to check your geolocation, because there is no permissoon", "Ok");
				}
			}
			catch (Exception ex)
			{
				await App.Current.MainPage.DisplayAlert("Error", $"{ex}", "Ok");
			}
		}
	}
}