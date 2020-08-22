﻿using CakeRecipes.Services;
using CakeRecipes.ViewModel;
using System;
using System.Linq;
using System.Windows.Controls;

namespace CakeRecipes.Views
{
    /// <summary>
    /// Interaction logic for AllRecipes.xaml
    /// </summary>
    public partial class AllRecipesWindow : UserControl
    {
        public AllRecipesWindow()
        {
            InitializeComponent();
            this.DataContext = new AllRecipesViewModel(this);
        }
    }
}
