using System;
using Accounting.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class AccountingTest
    {
        private Employee employee01;
        private Employee employee02;
        private Employee employee03;
        private Employee employee04;

        private Manager workingManagerWithEmployees;
        private Manager workingManagerWithoutEmployees;
        private Manager notWorkingManagerWithEmployees;
        private Manager notWorkingManagerWithoutEmployees;

        [TestInitialize]
        public void Init()
        {
            employee01 = new Employee(4);
            employee02 = new Employee(4);
            employee03 = new Employee(4);
            employee04 = new Employee(4);

            for (int i = 1; i <= 31; i++)
            {
                employee01.AddTimeLog(new TimeLog(new DateTime(2019, 3, i), 8));
            }

            for (int i = 1; i <= 31; i++)
            {
                var date = new DateTime(2019, 3, i);
                if(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                employee02.AddTimeLog(new TimeLog(date, 8));
            }

            for (int i = 1; i <= 30; i++)
            {
                employee03.AddTimeLog(new TimeLog(new DateTime(2019, 4, i), 8));
            }

            employee04.AddTimeLog(new TimeLog(new DateTime(2019, 3, 1), 4));
            employee04.AddTimeLog(new TimeLog(new DateTime(2019, 3, 31), 4));

            workingManagerWithEmployees = new Manager(4);
            workingManagerWithoutEmployees = new Manager(4);
            notWorkingManagerWithEmployees = new Manager(4);
            notWorkingManagerWithoutEmployees = new Manager(4);

            for (int i = 1; i <= 31; i++)
            {
                var date = new DateTime(2019, 3, i);
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                workingManagerWithEmployees.AddTimeLog(new TimeLog(date, 8));
                workingManagerWithoutEmployees.AddTimeLog(new TimeLog(date, 8));
            }

            workingManagerWithEmployees.AddEmployee(employee01);
            workingManagerWithEmployees.AddEmployee(employee02);
            workingManagerWithEmployees.AddEmployee(employee03);
            workingManagerWithEmployees.AddEmployee(employee04);

            notWorkingManagerWithEmployees.AddEmployee(employee01);
            notWorkingManagerWithEmployees.AddEmployee(employee02);
            notWorkingManagerWithEmployees.AddEmployee(employee03);
            notWorkingManagerWithEmployees.AddEmployee(employee04);
        }

        [TestMethod]
        public void CalculateEmployeeSalaryTest()
        {
            Assert.AreEqual(992, employee01.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            Assert.AreEqual(672, employee02.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            Assert.AreEqual(0, employee03.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            Assert.AreEqual(32, employee04.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
        }

        [TestMethod]
        public void CalculateManagerSalaryTest()
        {
            Assert.AreEqual(722.88m, workingManagerWithEmployees.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            Assert.AreEqual(672, workingManagerWithoutEmployees.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            Assert.AreEqual(50.88m, notWorkingManagerWithEmployees.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            Assert.AreEqual(0, notWorkingManagerWithoutEmployees.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
        }

        [TestMethod]
        public void CalculateManagerSalaryWithoutEmployeesTest()
        {
            
        }
    }
}
