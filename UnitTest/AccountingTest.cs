﻿using System;
using Accounting.BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class AccountingTest
    {
        private BaseEmployee _employee01;
        private BaseEmployee _employee02;
        private BaseEmployee _employee03;
        private BaseEmployee _employee04;

        private BaseEmployee _employee21;
        private BaseEmployee _employee22;
        private BaseEmployee _employee23;
        private BaseEmployee _employee24;

        private BaseEmployee _employee31;
        private BaseEmployee _employee32;
        private BaseEmployee _employee33;
        private BaseEmployee _employee34;

        private Manager _workingManagerWithEmployees;
        private Manager _workingManagerWithoutEmployees;
        private Manager _notWorkingManagerWithEmployees;
        private Manager _notWorkingManagerWithoutEmployees;

        private Manager _manager31;
        private Manager _manager32;

        private BaseEmployee _employee41;

        [TestInitialize]
        public void Init()
        {
            _employee01 = new Employee(4);
            _employee02 = new Employee(4);
            _employee03 = new Employee(4);
            _employee04 = new Employee(4);

            _employee21 = new Employee(4);
            _employee22 = new Employee(4);
            _employee23 = new Employee(4);
            _employee24 = new Employee(4);

            for (int i = 1; i <= 31; i++)
            {
                _employee01.AddTimeLog(new TimeLog(new DateTime(2019, 3, i), 8));
                _employee21.AddTimeLog(new TimeLog(new DateTime(2019, 3, i), 8));
            }

            for (int i = 1; i <= 31; i++)
            {
                var date = new DateTime(2019, 3, i);
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                _employee02.AddTimeLog(new TimeLog(date, 8));
                _employee22.AddTimeLog(new TimeLog(date, 8));
            }

            for (int i = 1; i <= 30; i++)
            {
                _employee03.AddTimeLog(new TimeLog(new DateTime(2019, 4, i), 8));
                _employee23.AddTimeLog(new TimeLog(new DateTime(2019, 4, i), 8));
            }

            _employee04.AddTimeLog(new TimeLog(new DateTime(2019, 3, 1), 4));
            _employee04.AddTimeLog(new TimeLog(new DateTime(2019, 3, 31), 4));

            _employee24.AddTimeLog(new TimeLog(new DateTime(2019, 3, 1), 4));
            _employee24.AddTimeLog(new TimeLog(new DateTime(2019, 3, 31), 4));

            _workingManagerWithEmployees = new Manager(4);
            _workingManagerWithoutEmployees = new Manager(4);
            _notWorkingManagerWithEmployees = new Manager(4);
            _notWorkingManagerWithoutEmployees = new Manager(4);

            for (int i = 1; i <= 31; i++)
            {
                var date = new DateTime(2019, 3, i);
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    continue;
                _workingManagerWithEmployees.AddTimeLog(new TimeLog(date, 8));
                _workingManagerWithoutEmployees.AddTimeLog(new TimeLog(date, 8));
            }

            _workingManagerWithEmployees.AddEmployee(_employee01);
            _workingManagerWithEmployees.AddEmployee(_employee02);
            _workingManagerWithEmployees.AddEmployee(_employee03);
            _workingManagerWithEmployees.AddEmployee(_employee04);

            _notWorkingManagerWithEmployees.AddEmployee(_employee21);
            _notWorkingManagerWithEmployees.AddEmployee(_employee22);
            _notWorkingManagerWithEmployees.AddEmployee(_employee23);
            _notWorkingManagerWithEmployees.AddEmployee(_employee24);

            #region AddEmployeesToManagerTest

            _employee31 = new Employee(4);
            _employee32 = new Employee(4);
            _employee33 = new Employee(4);
            _employee34 = new Employee(4);

            _manager31 = new Manager(4);
            _manager32 = new Manager(4);

            _employee31.AddTimeLog(new TimeLog(new DateTime(2019, 03, 1), 8));
            _employee32.AddTimeLog(new TimeLog(new DateTime(2019, 03, 1), 8));
            _employee33.AddTimeLog(new TimeLog(new DateTime(2019, 03, 1), 8));
            _employee34.AddTimeLog(new TimeLog(new DateTime(2019, 03, 1), 8));

            _manager31.AddTimeLog(new TimeLog(new DateTime(2019, 03, 1), 8));
            _manager32.AddTimeLog(new TimeLog(new DateTime(2019, 03, 1), 8));

            #endregion AddEmployeesToManagerTest

            _employee41 = new Employee(4);

        }

        [TestMethod]
        public void CalculateEmployeeSalaryTest()
        {
            Assert.AreEqual(992, _employee01.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            Assert.AreEqual(672, _employee02.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            Assert.AreEqual(0, _employee03.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            Assert.AreEqual(32, _employee04.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));

            Assert.AreEqual(32, _employee01.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 1)));
            Assert.AreEqual(0, _employee01.CalculateSalary(new DateTime(2019, 3, 2), new DateTime(2019, 3, 1)));
        }

        [TestMethod]
        public void CalculateManagerSalaryTest()
        {
            Assert.AreEqual(722.88m, _workingManagerWithEmployees.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            Assert.AreEqual(672, _workingManagerWithoutEmployees.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            Assert.AreEqual(50.88m, _notWorkingManagerWithEmployees.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            Assert.AreEqual(0, _notWorkingManagerWithoutEmployees.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));

            Assert.AreEqual(32, _workingManagerWithoutEmployees.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 1)));
            Assert.AreEqual(0, _workingManagerWithoutEmployees.CalculateSalary(new DateTime(2019, 3, 2), new DateTime(2019, 3, 1)));
        }

        [TestMethod]
        public void AddEmployeesToManagerTest()
        {
            _manager31.AddEmployee(_manager31);
            Assert.AreEqual(32, _manager31.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));

            _manager31.AddEmployee(_employee31);
            Assert.AreEqual(32.96m, _manager31.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));

            _manager31.AddEmployee(_employee32);
            Assert.AreEqual(33.92m, _manager31.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));
            
            _manager31.AddEmployee(_employee33);
            Assert.AreEqual(34.88m, _manager31.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));

            _manager31.AddEmployee(_employee34);
            Assert.AreEqual(35.84m, _manager31.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));

            _manager31.AddEmployee(_manager32);
            Assert.AreEqual(36.8m, _manager31.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 31)));

            
        }

        [TestMethod]
        public void AddTimeLogTest()
        {
            _employee41.AddTimeLog(new TimeLog(new DateTime(2019, 3, 1), 8));
            Assert.AreEqual(32, _employee41.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 1)));
            _employee41.AddTimeLog(new TimeLog(new DateTime(2019, 3, 1), 8));
            Assert.AreEqual(32, _employee41.CalculateSalary(new DateTime(2019, 3, 1), new DateTime(2019, 3, 1)));
        }

        [TestMethod]
        public void SetTimeLogHourTest()
        {
            TimeLog timeLog1 = new TimeLog(new DateTime(2019, 03, 1), 25);
            TimeLog timeLog2 = new TimeLog(new DateTime(2019, 03, 1), -1);
            TimeLog timeLog3 = new TimeLog(new DateTime(2019, 03, 1), 0);
            TimeLog timeLog4 = new TimeLog(new DateTime(2019, 03, 1), 1);
            TimeLog timeLog5 = new TimeLog(new DateTime(2019, 03, 1), 8);
            TimeLog timeLog6 = new TimeLog(new DateTime(2019, 03, 1), 24);

            Assert.AreEqual(0, timeLog1.Hours);
            Assert.AreEqual(0, timeLog2.Hours);
            Assert.AreEqual(0, timeLog3.Hours);
            Assert.AreEqual(1, timeLog4.Hours);
            Assert.AreEqual(8, timeLog5.Hours);
            Assert.AreEqual(24, timeLog6.Hours);
        }
    }
}
