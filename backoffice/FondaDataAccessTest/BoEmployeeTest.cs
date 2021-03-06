﻿using NUnit.Framework;
using System;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;

namespace FondaDataAccessTest
{
    public class BoEmployeeTest
    {


        private FactoryDAO _facDAO;
        private IEmployeeDAO _employeeDAO;
        private Employee _employee;
        private Role _role;
        private DateTime _employeeBirthDate = Convert.ToDateTime("08/08/1991");
        private int _employeeId;
        private IRoleDAO _roleDAO;
        private IUserAccountDAO _userAcountDAO;
        private UserAccount _userAcount;


        /// <summary>
        /// Prueba del constructor de la clase Employee
        /// </summary>
        [Test]
        public void TestBuilderEmployee()
        {

            Employee employee = new Employee();
            Assert.AreEqual(employee.Id, 0);
            Assert.AreEqual(employee.Name, null);
            Assert.AreEqual(employee.Address, null);
            Assert.AreNotEqual(employee.Gender, null);
            Assert.AreEqual(employee.LastName, null);
        }


        /// <summary>
        /// Prueba de Acceso a Datos se almacena el employee y se verifica.
        /// </summary>
        [Test]
        public void EmployeeSave()
        {
            Employee employeet = new Employee();
            getEmployee();
            generateEmployee();
            _employeeDAO.Save(_employee);
            Assert.AreNotEqual(_employee.Id, 0);
            _employeeId = _employee.Id;
            Assert.NotNull(_employeeDAO.GetAll());
            //Verificacion del employee guardado 
            employeet = _employeeDAO.FindById(_employee.Id);
            Assert.IsNotNull(employeet);
            Assert.AreEqual(employeet.Name, "José");
            Assert.AreEqual(employeet.LastName, "Garcia");
            Assert.AreEqual(employeet.Ssn, "19932801");
            Assert.AreEqual(employeet.PhoneNumber, "0414-11-63-457");
            Assert.AreEqual(employeet.Address, "Direccion de Prueba");
            Assert.AreEqual(employeet.Gender, 'M');
            Assert.AreEqual(employeet.BirthDate, _employeeBirthDate);
            _employeeDAO.Delete(_employee);
            _employeeDAO.ResetSession();
            _employee = null;
        }


        /// <summary>
        /// Prueba de Acceso a Datos se almacena el employee y se verifica.
        /// </summary>
        [Test]
        public void EmployeeChange()
        {
            Employee employeet = new Employee();
            getEmployee();
            generateEmployee();
            _employeeDAO.Save(_employee);
            Assert.AreNotEqual(_employee.Id, 0);
            _employeeId = _employee.Id;
            Assert.NotNull(_employeeDAO.GetAll());
            //Verificacion del employee guardado 
            employeet = _employeeDAO.FindById(_employee.Id);
            Assert.IsNotNull(employeet);
            Assert.AreEqual(employeet.Name, "José");
            Assert.AreEqual(employeet.LastName, "Garcia");
            Assert.AreEqual(employeet.Ssn, "19932801");
            Assert.AreEqual(employeet.PhoneNumber, "0414-11-63-457");
            Assert.AreEqual(employeet.Address, "Direccion de Prueba");
            Assert.AreEqual(employeet.Gender, 'M');
            Assert.AreEqual(employeet.BirthDate, _employeeBirthDate);
            //Modificacion del employee
            employeet.Name = "pedro";
            employeet.LastName= "martinez";
            employeet.Ssn="v-1857452";
            employeet.PhoneNumber="0412-12-64-557";
            employeet.Address= "Nueva Direccion";
            employeet.Gender= 'F';
            _employeeDAO.Save(employeet);
            //verifica que los cambios fueron exitosos 
            employeet = _employeeDAO.FindById(employeet.Id);
            Assert.IsNotNull(employeet);
            Assert.AreEqual(employeet.Name, "pedro");
            Assert.AreEqual(employeet.LastName, "martinez");
            Assert.AreEqual(employeet.Ssn, "v-1857452");
            Assert.AreEqual(employeet.PhoneNumber, "0412-12-64-557");
            Assert.AreEqual(employeet.Address, "Nueva Direccion");
            Assert.AreEqual(employeet.Gender, 'F');

            _employeeDAO.Delete(employeet);
            _employeeDAO.ResetSession();
            _employee = null;
        }

        /// <summary>
        /// Prueba del Dominio
        /// Crea un Empleado y verifica que fue de manera Correcta
        /// </summary>
        [Test()]
        public void EmployeeDomainTest()
        {

            generateEmployee();
            EmpoyeeAssertions();

        }

        private void generateEmployee(bool edit = false)
        {
            if (_employee != null & !edit)
                return;

            if ((edit & _employee == null) | _employee == null)
                _employee = new Employee();

            getRoleDao();
            getUserAcountDao();
            generateUserAcount();
            _employee.Name = "José";
            _employee.LastName = "Garcia";
            _employee.Ssn = "19932801";
            _employee.PhoneNumber = "0414-11-63-457";
            _employee.Address = "Direccion de Prueba";
            _employee.Gender = 'M';
            _employee.BirthDate = _employeeBirthDate;
            _employee.Username = "Usuario";
            _employee.UserAccount = _userAcount;
            _employee.Role = _roleDAO.FindById(1);
            _employee.Status = ActiveSimpleStatus.Instance;
        }


        private void generateUserAcount(bool edit = false)
        {
            if (_userAcount != null)
                return;
            if ((edit & _userAcount == null) | _userAcount == null)
                _userAcount = new UserAccount();
            int id = 1;
            _userAcount = _userAcountDAO.FindById(id);
        }

        private void EmpoyeeAssertions(bool edit = false)
        {
            Assert.IsNotNull(_employee);
            Assert.AreEqual(_employee.Name, "José");
            Assert.AreEqual(_employee.LastName, "Garcia");
            Assert.AreEqual(_employee.Ssn, "19932801");
            Assert.AreEqual(_employee.PhoneNumber, "0414-11-63-457");
            Assert.AreEqual(_employee.Address, "Direccion de Prueba");
            Assert.AreEqual(_employee.Gender, 'M');
            Assert.AreEqual(_employee.BirthDate, _employeeBirthDate);
            Assert.AreEqual(_employee.Username, "Usuario");
            Assert.AreEqual(_employee.Status, ActiveSimpleStatus.Instance);
        }

        private void getRoleDao()
        {
            getDao();
            if (_roleDAO == null)
                _roleDAO = _facDAO.GetRoleDAO();

        }
        private void getUserAcountDao()
        {
            getDao();
            if (_userAcountDAO == null)
                _userAcountDAO = _facDAO.GetUserAccountDAO();

        }

        private void getEmployee()
        {
            getDao();
            if (_employeeDAO == null)
                _employeeDAO = _facDAO.GetEmployeeDAO();

        }
        private void getDao()
        {
            if (_facDAO == null)
                _facDAO = FactoryDAO.Intance;
        }


    }
}
