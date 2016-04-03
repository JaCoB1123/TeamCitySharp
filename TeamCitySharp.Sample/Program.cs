using System;
using System.Collections.Generic;
using TeamCitySharp.DomainEntities;
using TeamCitySharp.Locators;

namespace TeamCitySharp.Sample
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = new TeamCityClient("teamcity");
			client.Connect(args[0], args[1]);

			var allBuilds = client.Builds.AllSinceDate(new DateTime(2016, 04, 01));

			var buildLocator = BuildLocator.WithDimensions(status:BuildStatus.FAILURE, maxResults:1000, sinceDate: new DateTime(2016, 03, 01), untilDate: new DateTime(2016, 03, 01, 12, 59, 59));
			List<Build> builds = client.Builds.ByBuildLocator(buildLocator);

			//var allUsers = client.Users.All();

			//foreach (var user in allUsers)
			//{
			//	var nonSuccessfulBuilds = client.Builds.NonSuccessfulBuildsForUser(user.Username);

			//	foreach (var nonSuccessfulBuild in nonSuccessfulBuilds)
			//	{
			//		var buildLocator = BuildLocator.WithId(long.Parse(nonSuccessfulBuild.Id));
			//		List<Build> builds = client.Builds.ByBuildLocator(buildLocator);
			//	}
			//}
		}
	}
}
