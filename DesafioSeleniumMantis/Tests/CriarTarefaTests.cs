using DesafioSeleniumMantis.Bases;
using DesafioSeleniumMantis.Flows;
using DesafioSeleniumMantis.Helpers;
using DesafioSeleniumMantis.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Tests
{
    [TestFixture]
    public class CriarTarefaTests : TestBase
    {
        #region Page Objects
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] MainPage mainPage;
        [AutoInstance] CriarTarefaPage criarTarefaPage;
        #endregion

        [Test]
        public void ValidarCamposCriarTarefa()
        {
            loginFlows = new LoginFlows();
            mainPage = new MainPage();
            criarTarefaPage = new CriarTarefaPage();


            #region Parameters
            string usuario = "Administrator";
            string senha = "root";

            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            mainPage.ClicarEmCriarTarefa();


            Assert.AreEqual("Digite os Detalhes do Relatório", criarTarefaPage.DigiteDetalhesRelatorio());
            Assert.AreEqual("* Categoria", criarTarefaPage.Categoria());
            Assert.AreEqual("Gravidade", criarTarefaPage.Gravidade());
            Assert.AreEqual("Prioridade", criarTarefaPage.Prioridade());
            Assert.AreEqual("Selecionar Perfil", criarTarefaPage.SelecionarPerfil());
            Assert.AreEqual("Atribuir a", criarTarefaPage.Atribuir());
            Assert.AreEqual("*Resumo", criarTarefaPage.Resumo());
            Assert.AreEqual("*Descrição", criarTarefaPage.Descricao());
            Assert.AreEqual("Passos para Reproduzir", criarTarefaPage.PassosParaReproduzir());
            Assert.AreEqual("Informações Adicionais", criarTarefaPage.InformacoesAdcionais());
            Assert.AreEqual("Aplicar Marcadores", criarTarefaPage.AplicarMarcadores());
            Assert.AreEqual("Enviar arquivos\r\nTamanho máximo: 5,000 kB", criarTarefaPage.EnviarArquivos());
            Assert.AreEqual("Visibilidade", criarTarefaPage.Visibilidade());
            Assert.AreEqual("Continuar Relatando", criarTarefaPage.ContinuarRelatando());
            Assert.IsTrue(criarTarefaPage.CriarTarefa());
        }
        [Test]
        public void CriarNovaTarefaComSucessoInformandoSomenteCamposObrigatorios()
        {
            loginFlows = new LoginFlows();
            mainPage = new MainPage();
            criarTarefaPage = new CriarTarefaPage();

            #region Parameters
            string usuario = "Administrator";
            string senha = "root";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Resumo teste automático " + GeneralHelpers.ReturnStringWithRandomCharacters(5);
            string descricao = "Descrição teste automático";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            mainPage.ClicarEmCriarTarefa();
            criarTarefaPage.SelecionarCategoria(categoria);
            criarTarefaPage.PreencherResumo(resumo);
            criarTarefaPage.PreencherDescricao(descricao);
            criarTarefaPage.ClicarEmCriarTarefa();

            Assert.AreEqual("Operação realizada com sucesso.\r\n\r\nVisualizar Tarefa Enviada 1\r\nVer Tarefas", criarTarefaPage.RetornaMensagem());
        }
        /*
        [Test]
        public void VerificaCampoResumoObrigatorio()
        {
            loginFlows = new LoginFlows();
            mainPage = new MainPage();
            criarTarefaPage = new CriarTarefaPage();

            #region Parameters
            string usuario = "Administrator";
            string senha = "root";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            mainPage.ClicarEmCriarTarefa();
            criarTarefaPage.ClicarEmCriarTarefa();

            Assert.AreEqual("Preencha este campo.", criarTarefaPage.RetornaMensagemCampoObrigatorio());

        }*/

    }


}
