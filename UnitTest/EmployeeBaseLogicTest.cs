using Accounting.Interfaces;
using Accounting.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTest
{
	[TestClass]
    public class EmployeeBaseLogicTest
    {
        #region Variables

        DateTime startDateTime = new DateTime(2019, 3, 1);
        DateTime endDateTime = new DateTime(2019, 3, 31);

        int salaryPerHour = 4;
        int hours = 8;

        private Mock<IEmployee> _employee;

        #endregion Variables

        [TestInitialize]
        public void Init()
        {
			List<ITimeLog> logTimeList = new List<ITimeLog>();
			for (int i = startDateTime.Day; i <= endDateTime.Day; i++)
			{
				Mock<ITimeLog> timeLog = new Mock<ITimeLog>();
				timeLog.SetupGet(tl => tl.DateTime).Returns(new DateTime(startDateTime.Year, startDateTime.Month, i));
				timeLog.SetupGet(tl => tl.Hours).Returns(hours);
				logTimeList.Add(timeLog.Object);
			}

			_employee = new Mock<IEmployee>();
			_employee.SetupGet(emp => emp.TimeLogList).Returns(logTimeList);
			_employee.SetupGet(emp => emp.SalaryPerHour).Returns(salaryPerHour);		
        }

        [TestMethod]
        public void CalculateEmployeeSalaryTest()
        {
			decimal expected = 992;
            EmployeeLogic employeeLogic = new EmployeeLogic(_employee.Object);
            decimal actual = employeeLogic.CalculateSalary(startDateTime, endDateTime);
            Assert.AreEqual(expected, actual, "Employee`s salary calculation is wrong!");
        }
	}
}