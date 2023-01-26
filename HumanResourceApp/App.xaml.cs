﻿using HumanResourceApp.Repositories;
using HumanResourceApp.View;
using HumanResourceApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HumanResourceApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\HumanResource.mdf;Integrated Security=True;Connect Timeout=30").Options;
            using (RepositoryBase dbContext = new RepositoryBase(options))
            {
                dbContext.Database.Migrate();
            }


            MainWindow = new LoginView()
            {
                DataContext = new LoginViewModel()
            };

            MainWindow.Show();

            MainWindow.IsVisibleChanged += (s, ev) =>
            {
                if (MainWindow.IsVisible == false && MainWindow.IsLoaded)
                {
                    var mainView = new MainView();
                    mainView.Show();
                    MainWindow.Close();
                }
            };

        }



        //protected void ApplicationStart (object sender, StartupEventArgs e)
        //{
        //    var loginView = new LoginView();
        //    loginView.Show();
//        loginView.IsVisibleChanged += (s, ev) =>
//            {
//                if (loginView.IsVisible == false && loginView.IsLoaded)
//                {
//                    var mainView = new MainView();
//        mainView.Show();
//                    loginView.Close();
//                }
//};
    }
    }

