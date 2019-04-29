using System;
using Accounting.BusinessObjects;
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
        
        private Mock<IEmployee> _employee211;
        private Mock<IEmployee> _employee212;
        private Mock<IEmployee> _employee213;
        private Mock<IEmployee> _employee214;

        private Mock<IEmployee> _employee221;
        private Mock<IEmployee> _employee222;
        private Mock<IEmployee> _employee223;
        private Mock<IEmployee> _employee224;

        private Mock<IManager> _workingManagerWithEmployees;

        #endregion Variables

        [TestInitialize]
        public void Init()
        {
           _employee211 = new Mock<IEmployee>();

            _employee212 = new Mock<IEmployee>(salaryPerHour);
            _employee213 = new Mock<IEmployee>(salaryPerHour);
            _employee214 = new Mock<IEmployee>(salaryPerHour);

            _employee221 = new Mock<IEmployee>(salaryPerHour);
            _employee222 = new Mock<IEmployee>(salaryPerHour);
            _employee223 = new Mock<IEmployee>(salaryPerHour);
            _employee224 = new Mock<IEmployee>(salaryPerHour);

            for (int i = startDateTime.Day; i <= endDateTime.Day; i++)
            {
                _employee211.Object.TimeLogList.Add(new TimeLog(new DateTime(startDateTime.Year, startDateTime.Month, i), hours));
                _employee221.Object.TimeLogList.Add(new TimeLog(new DateTime(startDateTime.Year, startDateTime.Month, i), hours));
            }

            for (int i = startDateTime.Day; i <= endDateTime.Day; i++)
            {
                var date = new DateTime(startDateTime.Year, startDateTime.Month, i);
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                _employee212.Object.TimeLogList.Add(new TimeLog(date, hours));
                _employee222.Object.TimeLogList.Add(new TimeLog(date, hours));
            }

            _employee214.Object.TimeLogList.Add(new TimeLog(startDateTime, hours));
            _employee214.Object.TimeLogList.Add(new TimeLog(endDateTime, hours));

            _employee224.Object.TimeLogList.Add(new TimeLog(startDateTime, hours));
            _employee224.Object.TimeLogList.Add(new TimeLog(endDateTime, endDateTime.Day));

            _workingManagerWithEmployees = new Mock<IManager>(salaryPerHour);
            _workingManagerWithEmployees.Object.EmployeeList.Add(_employee221.Object);
            _workingManagerWithEmployees.Object.EmployeeList.Add(_employee222.Object);
            _workingManagerWithEmployees.Object.EmployeeList.Add(_employee223.Object);
            _workingManagerWithEmployees.Object.EmployeeList.Add(_employee224.Object);

            for (int i = startDateTime.Day; i <= endDateTime.Day; i++)
            {
                var date = new DateTime(startDateTime.Year, startDateTime.Month, i);
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                _workingManagerWithEmployees.Object.TimeLogList.Add(new TimeLog(date, hours));
            }
        }
        
        [TestMethod]
        public void CalculateManagerSalaryTest()
        {
            decimal expected = 722.88m;
            ManagerLogic managerLogic = new ManagerLogic(_workingManagerWithEmployees.Object);
            decimal actual = managerLogic.CalculateSalary(startDateTime, endDateTime);
            Assert.AreEqual(expected, actual, "Manager`s salary calculation is wrong!");
        }
    }
}

