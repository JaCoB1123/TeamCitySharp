using System;
using System.Collections.Generic;

namespace TeamCitySharp.Locators
{
	public class ChangeLocator
	{
		public static ChangeLocator WithDimensions(string buildType = null,
			string username = "",
			string sinceChange = null,
			int? maxResults = null)
		{
			return new ChangeLocator
			{
				BuildType = buildType,
				UserName = username,
				SinceChange = sinceChange,
				MaxResults = maxResults
			};
		}

		public int? MaxResults { get; set; }

		public string SinceChange { get; set; }

		public string UserName { get; set; }

		public string BuildType { get; set; }

		public override string ToString()
		{
			var locatorFields = new List<string>();

			if (BuildType != null)
			{
				locatorFields.Add("buildType:(" + BuildType + ")");
			}

			if (UserName != null)
			{
				locatorFields.Add("username:" + UserName);
			}
			
			if (SinceChange != null)
			{
				locatorFields.Add("sinceChange:" + SinceChange);
			}
			
			if (MaxResults.HasValue)
			{
				locatorFields.Add("count:" + MaxResults.Value);
			}

			return string.Join(",", locatorFields.ToArray());
		}
	}
}