using KBStarCoreApp.Application.Dapper.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KBStarCoreApp.Application.Dapper.Interfaces
{
	public interface IReportService
	{
		Task<IEnumerable<RevenueReportViewModel>> GetReportAsync(string fromDate, string toDate);
	}
}
