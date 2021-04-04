using DesafioSeleniumMantis.Bases;
using DesafioSeleniumMantis.DataBaseSteps;
using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Pages;
using NUnit.Framework;
using System.Collections;

namespace DesafioSeleniumMantis.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {

        #region Pages and Flows Objects
        LoginPage loginPage;
        MainPage mainPage;
        #endregion

        [Test]
        public void RealizarLoginComSucesso()
        {
            loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = "Administrator";
            string senha = "admin";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();

            Assert.AreEqual("administrator administrador", mainPage.MinhaVistaLogin());
        }

        [Test]
        public void RealizarLoginUsuarioNaoInformado()
        {
            loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = string.Empty;
            string mensagemErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";

            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();

            Assert.AreEqual(mensagemErro, loginPage.RetornaMensagemDeErro());
        }

        [Test]
        public void RealizarLoginSenhaNaoInformada()
        {
            loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = "Administrator";
            string senha = string.Empty;
            string mensagemErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();

            Assert.AreEqual(mensagemErro, loginPage.RetornaMensagemDeErro());

        }

        [Test]
        public void RealizarLoginSenhaInvalida()
        {
            loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = "Administrator";
            string senha = "123456";
            string mensagemErro = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();

            Assert.AreEqual(mensagemErro, loginPage.RetornaMensagemDeErro());

        }


    }
}
