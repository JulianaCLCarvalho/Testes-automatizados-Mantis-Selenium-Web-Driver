using DesafioSeleniumMantis.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSeleniumMantis.Pages
{
    public class MainPage : PageBase
    {
        #region Mapping
        By minhaVista = By.Id("breadcrumbs");
        By gerenciar = By.XPath("//div[@id='sidebar']/ul/li[6]/a/i");
        By menuGerenciar = By.XPath("//div[@id='sidebar']/ul/li[7]/a/i");
        By criarTarefaLink = By.XPath("//div[@id='sidebar']/ul/li[3]/a/span");


        #endregion

        #region Actions
        public string MinhaVistaLogin()
        {
            return GetText(minhaVista);
        }

        public void ClicarEmGerenciar()
        {
            Click(gerenciar);
        }

        public void ClicarEmMenuGerenciar()
        {
            //quando já existe um projeto criado.
            Click(menuGerenciar);
        }

        public void ClicarEmCriarTarefa()
        {
            Click(criarTarefaLink);
        }
        #endregion
    }
}
