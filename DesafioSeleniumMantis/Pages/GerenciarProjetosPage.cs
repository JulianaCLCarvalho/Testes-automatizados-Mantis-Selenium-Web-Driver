using DesafioSeleniumMantis.Bases;
using DocumentFormat.OpenXml.Drawing;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class GerenciarProjetosPage : PageBase
    {
        #region Mapeamento Menu Gerenciar Projetos
        By tituloGerenciar = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div");
        By gerenciarProjeto = By.LinkText("Gerenciar Projetos");
        By tituloProjetos = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div");
        #endregion

        #region Mapeamento Campos Projeto
        By criarProjeto = By.XPath("//button[@type='submit']");
        By tituloAdicionarProjeto = By.XPath("//form[@id='manage-project-create-form']/div/div/h4");
        By nomeProjetoCampo = By.XPath("//form[@id='manage-project-create-form']/div/div[2]/div/div/table/tbody/tr/td");
        By estadoCampo = By.XPath("//form[@id='manage-project-create-form']/div/div[2]/div/div/table/tbody/tr[2]/td");
        By herdarCategoriasCampo = By.XPath("//form[@id='manage-project-create-form']/div/div[2]/div/div/table/tbody/tr[3]/td");
        By visibilidade = By.XPath("//form[@id='manage-project-create-form']/div/div[2]/div/div/table/tbody/tr[4]/td");
        By descricaoCampo = By.XPath("//form[@id='manage-project-create-form']/div/div[2]/div/div/table/tbody/tr[5]/td");
        #endregion

        #region Mapeamento Adicionar Projeto
        By nomeProjeto = By.Id("project-name");
        By estado = By.Id("project-status");
        //By herdarCategoriasGlobais = By.XPath("//form[@id='manage-project-create-form']/div/div[2]/div/div/table/tbody/tr[3]/td[2]/label/span");
        By visibilidadeProjeto = By.Id("project-view-state");
        By descricao = By.Id("project-description");
        By adicionarProjeto = By.XPath("//input[@value='Adicionar projeto']");
        By mensagem = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]");
        #endregion

        #region Mapeamento Atualizar Projeto
        By nome = By.XPath("(//a[contains(text(),'Base2')])[2]");
        By atualizarProjeto = By.XPath("//input[@value='Atualizar Projeto']");
        By projetoAtualizado = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td");
        By campoAtualizado = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td[4]");
        #endregion

        #region Mapeamento ApagarProjeto
        By apagarProjeto = By.XPath("//input[@value='Apagar Projeto']");
        #endregion

        #region Actions

        public void ClicarEmGerenciarProjetos()
        {
            Click(gerenciarProjeto);

        }

        public void ClicarEmCriarUmNovoProjeto()
        {
            Click(criarProjeto);
        }

        public void ClicarEmProjetoExistente()
        {
            Click(nome);
        }
        public void ClicarEmAtualizarProjeto()
        {
            Click(atualizarProjeto);
        }

        public string ProjetoAtualizado()
        {
            return GetText(projetoAtualizado);
        }

        public string CampoAtualizado()
        {
            return GetText(campoAtualizado);
        }

        public string InformacaoSite()
        {
            return GetText(tituloGerenciar);
        }

        public string Projetos()
        {
            return GetText(tituloProjetos);
        }

        public string NovoProjeto()
        {
            return GetText(tituloAdicionarProjeto);
        }

        public string NomeProjeto()
        {
            return GetText(nomeProjetoCampo);
        }

        public string Status()
        {
            return GetText(estadoCampo);
        }

        public string Visualizacao()
        {
            return GetText(visibilidade);
        }

        public string Descricao()
        {
            return GetText(descricaoCampo);
        }

        public string HerdarCategorias()
        {
            return GetText(herdarCategoriasCampo);
        }

        public bool AdicionarProjeto()
        {
            ReturnIfElementIsDisplayed(adicionarProjeto);
            return true;
        }

        public void PreencherNomeProjeto(string nomeProjeto)
        {
            SendKeys(this.nomeProjeto, nomeProjeto);
        }

        public void SelecionarStatus(string estado)
        {
            ComboBoxSelectByVisibleText(this.estado, estado);
        }

        //public void DesmarcarHerdarCategoriasGlobais()
        //{
        //    Click(herdarCategoriasGlobais);
        //}

        public void SelecionarVisibilidade(string visibilidade)
        {
            ComboBoxSelectByVisibleText(visibilidadeProjeto, visibilidade);
        }

        public void PreencherDescricao(string descricaoProjeto)
        {
            SendKeys(descricao, descricaoProjeto);
        }

        public void ClicarEmAdicionarProjeto()
        {
            Click(adicionarProjeto);
        }

        public bool VerificaProjeto(string nomeProjeto)
        {
            By xpath = By.XPath("(//a[contains(text(),'" + nomeProjeto + "')])[2]");
            bool result = ReturnIfElementIsDisplayed(xpath);
            return result;
        }

        public void ClicarEmApagarProjeto()
        {
            Click(apagarProjeto);
        }

        public bool ApagarProjeto()
        {
            ReturnIfElementIsDisplayed(apagarProjeto);
            return true;
        }

        public string RetornaMensagemDeConfirmacao()
        {
            return GetText(mensagem);
        }

        public string RetornaMensagem()
        {
            return GetText(mensagem);
        }


        #endregion
    }
}