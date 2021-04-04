using DesafioSeleniumMantis.Bases;
using DesafioSeleniumMantis.Pages;
using DesafioSeleniumMantis.Flows;
using DesafioSeleniumMantis.DataBaseSteps;
using NUnit.Framework;
using System.Collections;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace DesafioSeleniumMantis.Tests
{
    [TestFixture]
    public class GerenciarProjetosTests : TestBase
    {

        #region Pages and Flows Objects
        LoginFlows loginFlows;
        MainPage mainPage;
        NovoProjetoFlows novoProjetoFlows;
        GerenciarProjetosPage gerenciarProjetosPage;
        #endregion

        [Test]
        public void ValidarMenuGerenciar()
        {
            mainPage = new MainPage();
            loginFlows = new LoginFlows();
            gerenciarProjetosPage = new GerenciarProjetosPage();

            #region Parameters
            string usuario = "Administrator";
            string senha = "admin";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            mainPage.ClicarEmGerenciar();
            Assert.AreEqual("Informação do Site", gerenciarProjetosPage.InformacaoSite());
        }


        [Test]
        public void ValidarMenuGerenciarProjetos()
        {
            loginFlows = new LoginFlows();
            mainPage = new MainPage();
            gerenciarProjetosPage = new GerenciarProjetosPage();
            //CargaTestesDBSteps.deletaProjetosDB();

            #region Parameters
            string usuario = "Administrator";
            string senha = "admin";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            mainPage.ClicarEmGerenciar();
            gerenciarProjetosPage.ClicarEmGerenciarProjetos();
            Assert.AreEqual("Projetos", gerenciarProjetosPage.Projetos());
        }

        [Test]
        public void ValidarCadastroNovoProjeto()
        {
            loginFlows = new LoginFlows();
            mainPage = new MainPage();
            gerenciarProjetosPage = new GerenciarProjetosPage();
            //CargaTestesDBSteps.deletaProjetosDB();

            #region Parameters
            string usuario = "Administrator";
            string senha = "admin";


            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            mainPage.ClicarEmGerenciar();
            gerenciarProjetosPage.ClicarEmGerenciarProjetos();
            gerenciarProjetosPage.ClicarEmCriarUmNovoProjeto();

            Assert.AreEqual("Adicionar projeto", gerenciarProjetosPage.NovoProjeto());
            Assert.AreEqual("* Nome do Projeto", gerenciarProjetosPage.NomeProjeto());
            Assert.AreEqual("Estado", gerenciarProjetosPage.Status());
            Assert.AreEqual("Herdar Categorias Globais", gerenciarProjetosPage.HerdarCategorias());
            Assert.AreEqual("Visibilidade", gerenciarProjetosPage.Visualizacao());
            Assert.AreEqual("Descrição", gerenciarProjetosPage.Descricao());
            Assert.IsTrue(gerenciarProjetosPage.AdicionarProjeto(), "Adicionar Projeto");

        }

        [Test]
        public void ValidarIncluirUmNovoProjeto()
        {
            loginFlows = new LoginFlows();
            mainPage = new MainPage();
            gerenciarProjetosPage = new GerenciarProjetosPage();
            //CargaTestesDBSteps.deletaProjetosDB();

            #region Parameters
            string usuario = "Administrator";
            string senha = "admin";
            string nomeProjeto = "Base2";
            string estado = "release";
            string visibilidade = "privado";
            string descricao = "Desafio de automação de testes com Selenium Webdriver";
            
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            mainPage.ClicarEmGerenciar();
            gerenciarProjetosPage.ClicarEmGerenciarProjetos();
            gerenciarProjetosPage.ClicarEmCriarUmNovoProjeto();
            gerenciarProjetosPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.SelecionarStatus(estado);
            gerenciarProjetosPage.SelecionarVisibilidade(visibilidade);
            gerenciarProjetosPage.PreencherDescricao(descricao);
            gerenciarProjetosPage.ClicarEmAdicionarProjeto();

            //Assert.AreEqual("Operação realizada com sucesso.", gerenciarProjetosPage.RetornaMensagem());
            Assert.AreEqual(true, gerenciarProjetosPage.VerificaProjeto(nomeProjeto));

        }

        [Test]
        public void ValidarAtualizarProjeto()
        {
            loginFlows = new LoginFlows();
            gerenciarProjetosPage = new GerenciarProjetosPage();
            novoProjetoFlows = new NovoProjetoFlows();
            mainPage = new MainPage();
            //CargaTestesDBSteps.deletaProjetosDB();

            #region Parameters
            string usuario = "Administrator";
            string senha = "admin";
            string nomeProjeto = "Base2";
            string estado = "release";
            string visibilidade = "privado";
            string visibilidadeAtualizada = "público";
            string descricao = "Desafio de automação de testes com Selenium Webdriver";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            novoProjetoFlows.IncluirProjeto(nomeProjeto, estado, visibilidade, descricao);
            gerenciarProjetosPage.ClicarEmProjetoExistente();
            gerenciarProjetosPage.SelecionarVisibilidade(visibilidadeAtualizada);
            gerenciarProjetosPage.ClicarEmAtualizarProjeto();

            Assert.AreEqual("Base2", gerenciarProjetosPage.ProjetoAtualizado());
            Assert.AreEqual("público", gerenciarProjetosPage.CampoAtualizado());

        }

        [Test]
        public void ValidarApagarProjeto()
        {
            loginFlows = new LoginFlows();
            mainPage = new MainPage();
            gerenciarProjetosPage = new GerenciarProjetosPage();
            novoProjetoFlows = new NovoProjetoFlows();
            //CargaTestesDBSteps.deletaProjetosDB();

            #region Parameters
            string usuario = "Administrator";
            string senha = "admin";
            string nomeProjeto = "Base2";
            string estado = "release";
            string visibilidade = "privado";
            string descricao = "Desafio de automação de testes com Selenium Webdriver";
            string mensagemConfirmacao = "Você tem certeza que deseja apagar este projeto e todas as tarefas relacionadas?\r\nNome do Projeto: Base2";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            novoProjetoFlows.IncluirProjeto(nomeProjeto, estado, visibilidade, descricao);
            gerenciarProjetosPage.ClicarEmProjetoExistente();
            gerenciarProjetosPage.ClicarEmApagarProjeto();

            Assert.AreEqual(mensagemConfirmacao, gerenciarProjetosPage.RetornaMensagemDeConfirmacao());
            Assert.IsTrue(gerenciarProjetosPage.ApagarProjeto(), "Apagar Projeto");

            gerenciarProjetosPage.ClicarEmApagarProjeto();

            Assert.IsFalse(gerenciarProjetosPage.VerificaProjeto(nomeProjeto));          

        }
        [Test]
        public void ValidarIncluirProjetoExistente()
        {
            loginFlows = new LoginFlows();
            mainPage = new MainPage();
            gerenciarProjetosPage = new GerenciarProjetosPage();
            novoProjetoFlows = new NovoProjetoFlows();
            //CargaTestesDBSteps.deletaProjetosDB();

            #region Parameters
            string usuario = "Administrator";
            string senha = "admin";
            string nomeProjeto = "Base2";
            string estado = "release";
            string visibilidade = "privado";
            string descricao = "Desafio de automação de testes com Selenium Webdriver";
            string mensagemExcecao = "APPLICATION ERROR #701\r\nUm projeto com este nome já existe. Por favor, volte e entre um nome diferente.\r\nPor favor, utilize o botão \"Voltar\" de seu navegador web para voltar à pagina anterior. Lá você pode corrigir quaisquer problemas identificados neste erro ou escolher uma outra ação. Você também pode clicar em uma opção da barra de menus para ir diretamente para outra seção.";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            mainPage.ClicarEmGerenciar();
            novoProjetoFlows.IncluirProjeto(nomeProjeto, estado, visibilidade, descricao);
            mainPage.ClicarEmMenuGerenciar();
            gerenciarProjetosPage.ClicarEmGerenciarProjetos();
            gerenciarProjetosPage.ClicarEmCriarUmNovoProjeto();
            gerenciarProjetosPage.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjetosPage.SelecionarStatus(estado);
            gerenciarProjetosPage.SelecionarVisibilidade(visibilidade);
            gerenciarProjetosPage.PreencherDescricao(descricao);
            gerenciarProjetosPage.ClicarEmAdicionarProjeto();

            Assert.AreEqual(mensagemExcecao, gerenciarProjetosPage.RetornaMensagem());

        }

    }
}
