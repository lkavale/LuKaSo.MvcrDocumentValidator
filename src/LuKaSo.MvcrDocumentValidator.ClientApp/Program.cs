﻿using LuKaSo.MvcrDocumentValidator.Infrastructure;
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
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UnityContainer container = new UnityContainer();

            // IOC configuration
            container.RegisterType<IMvcrDocumentValidatorClient, MvcrDocumentValidatorClient>()

                // Validators list setup
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
