using Google.Apis.AnalyticsReporting.v4;
using Google.Apis.AnalyticsReporting.v4.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using WebStore.Common;

namespace WebStore.WebApplication.GoogleAnalytics
{
	public class ReportManager
	{
		public int TotalVisitors=0;
		public int NewVisitors=0;
		public int ReturningVisitors=0;
		public List<Tuple<string, int>> TotalVisitorsByDate = new List<Tuple<string, int>>();
		public List<Tuple<string, int>> NewVisitorsByDate = new List<Tuple<string, int>>();
		public List<Tuple<string, int>> ReturningVisitorsByDate = new List<Tuple<string, int>>();

		public ReportManager(int days)
		{
			try
			{
				var dateRange = new DateRange
				{
					StartDate = DateTime.UtcNow.AddDays(-days).ToString("yyyy-MM-dd"),
					EndDate = DateTime.UtcNow.ToString("yyyy-MM-dd")
				};

				var metrics = new List<Metric> { new Metric { Expression = "ga:sessions", Alias = "Sessions" } };
				var dimensions = new List<Dimension> { new Dimension { Name = "ga:userType" }, new Dimension { Name = "ga:date" } };

				var ViewId = ConstVal.GoogleAnalyticsViewId;

				var reportRequest = new ReportRequest
				{
					DateRanges = new List<DateRange> { dateRange },
					Metrics = metrics,
					Dimensions = dimensions,
					ViewId = ViewId
				};
				var getReportsRequest = new GetReportsRequest();
				getReportsRequest.ReportRequests = new List<ReportRequest> { reportRequest };

				var response = GetReport(getReportsRequest);

				ConvertReport(response);

				SetProperties(days);
			}
			catch 
			{ }
		}

		private void SetProperties(int days)
		{
			for (int i = days-1; i >=0; i--)
			{
				var date=DateTime.UtcNow.AddDays(-(i+1)).ToString("dd-MM-yyyy");
				int newVisitors = 0;
				int returningVisitors = 0;

				foreach (var visitor in NewVisitorsByDate)
				{
					if (visitor.Item1 == date)
					{
						newVisitors += visitor.Item2;

						break;
					}
				}
				NewVisitors += newVisitors;

				foreach (var visitor in ReturningVisitorsByDate)
				{
					if (visitor.Item1 == date)
					{
						returningVisitors += visitor.Item2;

						break;
					}
				}
				ReturningVisitors += returningVisitors;

				TotalVisitorsByDate.Add(new Tuple<string, int>(date, newVisitors+returningVisitors));
			}

			TotalVisitors = NewVisitors + ReturningVisitors;
		}

		private void ConvertReport(GetReportsResponse response)
		{
			foreach (var report in response.Reports)
			{
				var rows = report.Data.Rows;
				ColumnHeader header = report.ColumnHeader;
				var dimensionHeaders = header.Dimensions;
				var metricHeaders = header.MetricHeader.MetricHeaderEntries;
				if (!rows.Any())
				{
					Console.WriteLine("No data found!");
					return;
				}
				else
				{
					foreach (var row in rows)
					{
						var dimensions = row.Dimensions;
						var metrics = row.Metrics;

						string date;
						int number;

						date = DateTime.ParseExact(dimensions[1], "yyyyMMdd",
											  CultureInfo.InvariantCulture).ToString("dd-MM-yyyy");
						number = int.Parse(metrics[0].Values[0]);

						if (dimensions[0] == "New Visitor")
							NewVisitorsByDate.Add(new Tuple<string, int>(date, number));
						else ReturningVisitorsByDate.Add(new Tuple<string, int>(date, number));
					}
				}
			}
		}


		private AnalyticsReportingService GetAnalyticsReportingServiceInstance(string keyFileName)
		{
			string[] scopes = { AnalyticsReportingService.Scope.AnalyticsReadonly };
			GoogleCredential credential;
			using (var stream = new FileStream(keyFileName, FileMode.Open, FileAccess.Read))
			{
				credential = GoogleCredential.FromStream(stream).CreateScoped(scopes);
			}

			return new AnalyticsReportingService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = "Simple Store User Data",
			});
		}

		private GetReportsResponse GetReport(GetReportsRequest getReportsRequest)
		{
			var analyticsService = GetAnalyticsReportingServiceInstance(ConstVal.GoogleAnalyticsKeyFileName);
			return analyticsService.Reports.BatchGet(getReportsRequest).Execute();
		}
	}
}






/*
 for (int i = 0; i < dimensionHeaders.Count && i < dimensions.Count; i++)
							{

								if (dimensionHeaders[i] == "ga:date")
								{

									date = DateTime.ParseExact(dimensions[i], "yyyyMMdd",
											  CultureInfo.InvariantCulture).ToString("dd-MM-yyyy");
									Console.WriteLine(dimensionHeaders[i] + ": " + date);
								}

							}
							for (int j = 0; j < metrics.Count; j++)
							{
								DateRangeValues values = metrics[j];
								for (int k = 0; k < values.Values.Count && k < metricHeaders.Count; k++)
								{
									number = int.Parse(values.Values[k]);
									Console.WriteLine(metricHeaders[k].Name + ": " + values.Values[k]);
								}
							}
	 */
