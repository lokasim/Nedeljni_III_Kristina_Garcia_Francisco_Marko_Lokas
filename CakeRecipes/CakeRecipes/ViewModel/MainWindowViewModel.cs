﻿using CakeRecipes.Models;
using CakeRecipes.Services;
using CakeRecipes.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeRecipes.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        readonly MainWindow mainWindow;

        

        Login login = new Login();

        public MainWindowViewModel(MainWindow mainWindow)
        {

            this.mainWindow = mainWindow;
            
        }

        
    }
}
