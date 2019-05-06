using System;
using System.Collections.Generic;
using Accounting.Interfaces;
using Accounting.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTest
{
	[TestClass]
    public class ManagerLogicTest
    {
        #region Variables

        DateTime startDateTime = new DateTime(2019, 3, 1);
        DateTime endDateTime = new DateTime(2019, 3, 31);

        int salaryPerHour = 4;
        int hours = 8;
        
        private Mock<IEmployee> _juniorEmployee;
        private Mock<IEmployee> _middleEmployee;

        private Mock<IManager> _manager;

        #endregion Variables

        [TestInitialize]
        public void Init()
        {
			_juniorEmployee = new Mock<IEmployee>();
			_middleEmployee = new Mock<IEmployee>();
			
			List<ITimeLog> logTimeList211 = new List<ITimeLog>();
			List<ITimeLog> logTimeList212 = new List<ITimeLog>();
			List<ITimeLog> managerLogTimeList = new List<ITimeLog>();

			for (int i = startDateTime.Day; i <= endDateTime.Day; i++)
			{
				Mock<ITimeLog> timeLog = new Mock<ITimeLog>();
				timeLog.SetupGet(tl => tl.DateTime).Returns(new DateTime(startDateTime.Year, startDateTime.Month, i));
				timeLog.SetupGet(tl => tl.Hours).Returns(hours);
				logTimeList211.Add(timeLog.Object);

				timeLog = new Mock<ITimeLog>();
				timeLog.SetupGet(tl => tl.DateTime).Returns(new DateTime(startDateTime.Year, startDateTime.Month, i));
				timeLog.SetupGet(tl => tl.Hours).Returns(hours);
				logTimeList212.Add(timeLog.Object);

				var date = new DateTime(startDateTime.Year, startDateTime.Month, i);
				if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
					continue;

				timeLog = new Mock<ITimeLog>();
				timeLog.SetupGet(tl => tl.DateTime).Returns(new DateTime(startDateTime.Year, startDateTime.Month, i));
				timeLog.SetupGet(tl => tl.Hours).Returns(hours);
				managerLogTimeList.Add(timeLog.Object);			
			}

			_juniorEmployee.SetupGet(emp => emp.TimeLogList).Returns(logTimeList211);
			_juniorEmployee.SetupGet(emp => emp.SalaryPerHour).Returns(salaryPerHour);

			_middleEmployee.SetupGet(emp => emp.TimeLogList).Returns(logTimeList212);
			_middleEmployee.SetupGet(emp => emp.SalaryPerHour).Returns(salaryPerHour);

			_manager = new Mock<IManager>();
			_manager.SetupGet(emp => emp.TimeLogList).Returns(managerLogTimeList);
			_manager.SetupGet(emp => emp.SalaryPerHour).Returns(salaryPerHour);
			_manager.SetupGet(emp => emp.EmployeeList).Returns(new List<IEmployee>() { _juniorEmployee.Object, _middleEmployee.Object });
        }
        
        [TestMethod]
        public void CalculateManagerSalaryTest()
        {
            decimal expected = 731.52m;
            ManagerLogic managerLogic = new ManagerLogic(_manager.Object);
            decimal actual = managerLogic.CalculateSalary(startDateTime, endDateTime);
            Assert.AreEqual(expected, actual, "Manager`s salary calculation is wrong!");
        }
    }
}

