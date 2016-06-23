﻿using com.ds201625.fonda.BackEndLogic;
using com.ds201625.fonda.DataAccess.FactoryDAO;
using com.ds201625.fonda.DataAccess.InterfaceDAO;
using com.ds201625.fonda.Domain;
using com.ds201625.fonda.Factory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FondaBackEndLogicTest
{
    /// <summary>
    /// Clase que contiene las pruebas unitarias 
    /// del Commando ProfileCommand
    /// </summary>
    [TestFixture]
    public class ProfileCommandManagementTest : HelpTestCommand
    {
        /// <summary>
        /// Atributos de la clase prueba
        /// </summary>
        private ICommand _createProfile;
        private ICommand _getProfile;
        private ICommand _updateProfile;
        private ICommand _deleteProfile;
        private ICommand _getAccountEmail;
        private Commensal _commensal;
        private Profile _profile;
        private ICommensalDAO _commensalDAO;
        private int _idProfile;

        /// <summary>
        /// Inicializacion de variables antes de cada prueba
        /// </summary>
        [SetUp]
        protected void Init()
        {
            _commensal = EntityFactory.GetCommensal();
            _profile = EntityFactory.GetProfile();
            _commensalDAO = FactoryDAO.Intance.GetCommensalDAO();
            _commensal = (Commensal)_commensalDAO.FindById(1);
            _profile = generateProfile();
            _idProfile = 0;
        }

        /// <summary>
        /// Prueba del comando CreateProfile
        /// </summary>
        [Test]
        public void CreateProfileCommandTest()
        {
            Assert.False(_commensal.Profiles.Contains(_profile));
            _createProfile = BackendFactoryCommand.Instance.GetCreateProfileCommand();
            _createProfile.SetParameter(0, _commensal);
            _createProfile.SetParameter(1, _profile);
            _createProfile.Run();

            Profile _result = (Profile)_createProfile.Result;
            _idProfile = _result.Id;
            _commensal = (Commensal)_commensalDAO.FindById(1);
            Assert.AreNotEqual(0, _result.Id);
            Assert.True(_commensal.Profiles.Contains(_profile));
        }

       /// <summary>
        /// Prueba del comando GetProfile
        /// </summary>
        [Test]
        public void GetProfileCommandTest()
        {
            _commensal.Profiles.Add(_profile);
            //Se Guarda el commensal con el nuevo perfil
            _commensalDAO.Save(_commensal);

            _getProfile = BackendFactoryCommand.Instance.GetProfileIdCommand();
            _getProfile.SetParameter(0, _profile);
            _getProfile.Run();

            Profile _result = (Profile)_getProfile.Result;
            _idProfile = _result.Id;
            Assert.AreNotEqual(0, _result.Id);
            Assert.AreEqual(_profile.Id, _result.Id);
            Assert.AreEqual(_profile.ProfileName, _result.ProfileName);
        }

        /// <summary>
        /// Prueba del comando DeleteProfile
        /// </summary>
        [Test]
        public void DeleteProfileCommandTest()
        {
            Assert.False(_commensal.Profiles.Contains(_profile));
            _commensal.Profiles.Add(_profile);
            //Se Guarda el commensal con el nuevo perfil
            _commensalDAO.Save(_commensal);
            Assert.True(_commensal.Profiles.Contains(_profile));
            Profile _pro = _profile;
            _deleteProfile = BackendFactoryCommand.Instance.DeleteProfileCommand();
            _deleteProfile.SetParameter(0, _commensal);
            _deleteProfile.SetParameter(1, _profile);
            _deleteProfile.Run();
            
            Assert.False(_commensal.Profiles.Contains(_pro));
        }

        /// <summary>
        /// Prueba del comando UpdateProfile
        /// </summary>
        [Test]
        public void UpdateProfileCommandTest()
        {
            Assert.False(_commensal.Profiles.Contains(_profile));
            _commensal.Profiles.Add(_profile);
            //Se Guarda el commensal con el nuevo perfil
            _commensalDAO.Save(_commensal);
            Assert.True(_commensal.Profiles.Contains(_profile));
            Assert.AreEqual(_profile.ProfileName, "Nombre de Perfil");
            Profile _pro = _profile;
            _pro.ProfileName = "Modificado";
            _updateProfile = BackendFactoryCommand.Instance.UpdateProfileCommand();
            _updateProfile.SetParameter(0, _commensal);
            _updateProfile.SetParameter(1, _profile);
            _updateProfile.SetParameter(2, _pro);
            _updateProfile.Run();

            Profile _result = (Profile)_updateProfile.Result;
            _idProfile = _result.Id;
            Assert.AreNotEqual(0, _result.Id);
            Assert.AreEqual(_profile.Id, _result.Id);
            Assert.AreEqual(_result.ProfileName, "Modificado");
        }

        /// <summary>
        /// Prueba del comando GetAccountEmail
        /// </summary>
        [Test]
        public void GetAccountEmailCommandTest()
        {
            string _email = _commensal.Email;
            string _password = _commensal.Password;

            _getAccountEmail = BackendFactoryCommand.Instance.GetAccountEmailCommands();
            _getAccountEmail.SetParameter(0, _email);
            _getAccountEmail.SetParameter(1, _password);
            _getAccountEmail.Run();

            UserAccount _result = (UserAccount)_getAccountEmail.Result;

            Assert.AreNotEqual(0, _result.Id);
            Assert.AreEqual(_commensal.Id, _result.Id);
            Assert.AreEqual(_email, _result.Email);
            Assert.AreEqual(_password, _result.Password);
        }
        /// <summary>
        /// Limpiar las variables al final de cada prueba
        /// </summary>
        [TearDown]
        protected void Clean()
        {
            if (_idProfile != 0)
            {
                _commensal.Profiles.Remove(_profile);
                _commensalDAO.Save(_commensal);
            }
            _createProfile = null;
            _getProfile = null;
            _updateProfile = null;
            _deleteProfile = null;
            _commensal = null;
            _profile = null;
            _commensalDAO = null;
            _getAccountEmail = null;
            _idProfile = 0;
        }

    }
}