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
            _employee = new Mock<IEmployee>();
            _employee.Object.SalaryPerHour = salaryPerHour;
            

            for (int i = startDateTime.Day; i <= endDateTime.Day; i++)
            {
                //TODO сделать через mock
                //Mock<EmployeeLogic> mock = new Mock<EmployeeLogic>();
                //mock.Setup(e => e.CalculateSalary(startDateTime, endDateTime));

                Mock<ITimeLog> timeLog = new Mock<ITimeLog>();
                timeLog.Object.DateTime = new DateTime(startDateTime.Year, startDateTime.Month, i);
                timeLog.Object.Hours = hours;
                _employee.Object.TimeLogList.Add(timeLog.Object);
            }
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