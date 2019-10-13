using LuKaSo.MvcrDocumentValidator.Infrastructure;
using LuKaSo.MvcrDocumentValidator.Validators;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using Unity;
using Unity.Injection;

namespace LuKaSo.MvcrDocumentValidator.ClientApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UnityContainer container = new UnityContainer();

            container.RegisterType<IMvcrDocumentValidatorClient, MvcrDocumentValidatorClient>()
                .RegisterType<IDocumentValidator, GreenPassportValidator>("GreenPassportValidator")
                .RegisterType<IDocumentValidator, PurplePassportValidator>("PurplePassportValidator")
                .RegisterType<IDocumentValidator, NewIdentityCardValidator>("NewIdentityCardValidator")
                .RegisterType<IDocumentValidator, OldIdentityCardValidator>("OldIdentityCardValidator")
                .RegisterType<IDocumentValidator, GunLicenseValidator>("GunLicenseValidator")
                .RegisterType<IEnumerable<IDocumentValidator>, IDocumentValidator[]>()
                .RegisterType<HttpClient>(new InjectionFactory(x => new HttpClient()))
                .RegisterType<ValidatorForm, ValidatorForm>();

            Application.Run(container.Resolve<ValidatorForm>());
        }
    }
}
