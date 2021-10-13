using Microsoft.Edge.SeleniumTools;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace TestAceptacionEjemplo.Steps
{
    [Binding]
    public sealed class SampleToDoAppStepDefinition
    {
        private readonly ScenarioContext _scenarioContext;

        IWebDriver _driver;

        string urlDestino = "https://lambdatest.github.io/sample-todo-app/";

        string nuevoElemento = "TEXTO";

        public SampleToDoAppStepDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"que estoy situado en la Sample ToDo App")]
        public void GivenQueEstoySituadoEnLaSampleToDoApp()
        {
            //INICIALIZAR EL DRIVER DEL NAVEGADOR
            //Utilizando Edge Chromium
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.UseChromium = true;
            _driver = new EdgeDriver(edgeOptions);
            
            _driver.Manage().Window.Maximize();
            
            _driver.Url = urlDestino;

            System.Threading.Thread.Sleep(2000);

        }

        [Then(@"seleccionar el Primer Item")]
        public void ThenSeleccionarElPrimerItem()
        {
            //Hacer Click en el Checkbox del primer Item
            IWebElement primerElemento = _driver.FindElement(By.Name("li1"));
            primerElemento.Click();

        }

        [Then(@"seleccionar el Segundo Item")]
        public void ThenSeleccionarElSegundoItem()
        {
            //Hacer Click en el Checkbox del segundo Item
            IWebElement segundoElemento = _driver.FindElement(By.Name("li2"));
            segundoElemento.Click();
        }

        [Then(@"encontrar el cuadro de texto para ingresar un nuevo item \(escribir\)")]
        public void ThenEncontrarElCuadroDeTextoParaIngresarUnNuevoItemEscribir()
        {
            IWebElement cuadroTexto = _driver.FindElement(By.Id("sampletodotext"));
            cuadroTexto.SendKeys(nuevoElemento);
        }

        [Then(@"hacer click en el Submit")]
        public void ThenHacerClickEnElSubmit()
        {
            IWebElement submit = _driver.FindElement(By.Id("addbutton"));
            submit.Click();
        }

        [Then(@"verificar si el item fue o no creado en la lista")]
        public void ThenVerificarSiElItemFueONoCreadoEnLaLista()
        {
            IWebElement nuevoItem = _driver.FindElement(By.XPath("/html/body/div/div/div/ul/li[6]/span"));
            string nuevoItemString = nuevoItem.Text;

            System.Threading.Thread.Sleep(2000);

            Assert.AreEqual(nuevoElemento, nuevoItemString);

            System.Threading.Thread.Sleep(2000);

        }

        [Then(@"cerrar el navegador")]
        public void ThenCerrarElNavegador()
        {
            _driver.Quit();
        }
    }
}
