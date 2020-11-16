﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace AirlineReservationApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            //Create a custom principal with an anonymous identity at startup
            CustomPrincipal customPrincipal = new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);

            base.OnStartup(e);

            ////Show the login view
            //AuthenticationViewModel viewModel = new AuthenticationViewModel(new AuthenticationService(), this.NavigationService);
            //IView loginWindow = new LoginWindow(viewModel);
            //loginWindow.Show();
            var mainWindows = new MainWindow();
            mainWindows.Show();
        }
    }
}
