using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class CriarTarefaPage : PageBase
    {
        #region Mapeamento Validar Campos Criar Tarefa
        By titulo = By.XPath("//form[@id='report_bug_form']/div/div");
        By categoria = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr/th");
        By gravidade = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[3]/th");
        By prioridade = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[4]/th");
        By selecionarPerfil = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[5]/th");
        By atribuir = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[6]/th");
        By resumo = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[7]/th");
        By descricao = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[8]/th");
        By passosParaReproduzir = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[9]/th");
        By informacoesAdicionais = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[10]/th");
        By aplicarMarcadores = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[11]/th");
        By enviarArquivos = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[12]/th");
        By visibilidade = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[13]/th");
        By continuarRelatando = By.XPath("//form[@id='report_bug_form']/div/div[2]/div/div/table/tbody/tr[14]/th");
        By criarTarefa = By.XPath("//input[@value='Criar Nova Tarefa']");
        #endregion

        #region Mepamento Criar Tarefa
        By IdCategoria = By.Id("category_id");
        By IdResumo = By.Id("summary");
        By IdDescricao = By.Id("description");
        By mensagem = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]");
        By mensagemCampoObrigatorio = By.Id("summary");

        #endregion

        #region Actions
        public string DigiteDetalhesRelatorio()
        {
            return GetText(titulo);
        }

        public string Categoria()
        {
            return GetText(categoria);
        }

        public string Gravidade()
        {
            return GetText(gravidade);
        }

        public string Prioridade()
        {
            return GetText(prioridade);
        }

        public string SelecionarPerfil()
        {
            return GetText(selecionarPerfil);
        }

        public string Atribuir()
        {
            return GetText(atribuir);
        }

        public string Resumo()
        {
            return GetText(resumo);
        }

        public string Descricao()
        {
            return GetText(descricao);
        }

        public string PassosParaReproduzir()
        {
            return GetText(passosParaReproduzir);
        }

        public string InformacoesAdcionais()
        {
            return GetText(informacoesAdicionais);
        }

        public string AplicarMarcadores()
        {
            return GetText(aplicarMarcadores);
        }

        public string EnviarArquivos()
        {
            return GetText(enviarArquivos);
        }

        public string Visibilidade()
        {
            return GetText(visibilidade);
        }

        public string ContinuarRelatando()
        {
            return GetText(continuarRelatando);
        }

        public bool CriarTarefa()
        {
            bool result = ReturnIfElementIsDisplayed(criarTarefa);
            return result;
        }

        public void SelecionarCategoria(string categoria)
        {
            ComboBoxSelectByVisibleText(IdCategoria, categoria);
        }

        public void PreencherResumo(string resumo)
        {
            SendKeys(IdResumo, resumo);
        }

        public void PreencherDescricao(string descricao)
        {
            SendKeys(IdDescricao, descricao);
        }

        public void ClicarEmCriarTarefa()
        {
            Click(criarTarefa);
        }

        public string RetornaMensagem()
        {
            return GetText(mensagem);
        }

        public string RetornaMensagemCampoObrigatorio()
        {
           return GetValue(mensagemCampoObrigatorio);
        }
        #endregion
    }
}