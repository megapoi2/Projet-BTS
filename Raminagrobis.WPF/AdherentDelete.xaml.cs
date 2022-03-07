﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Raminagrobis.API.Client;
using Raminagrobis.DTO.DTO;

namespace Raminagrobis.WPF
{
    /// <summary>
    /// Logique d'interaction pour Adherents.xaml
    /// </summary>
    public partial class AdherentDelete : Page
    {
        #region InitializeComponent
        public AdherentDelete()
        {
            InitializeComponent();
        }
        #endregion

        #region LoadPage
        private async void LoadPage(object sender, RoutedEventArgs e)
        {
            var apiclient = new AdherentsClient("https://localhost:44345", new HttpClient());
            var adherent = await apiclient.AllAsync();

            lvAdherents.ItemsSource = adherent;
        }
        #endregion

        #region BtnAdherentDelete
        public void BtnAdherentDelete(object sender, RoutedEventArgs e)
        {
            var apiclient = new AdherentsClient("https://localhost:44345", new HttpClient());
            int ID = Int32.Parse(DeleteID.Text);
            apiclient.DELETEAsync(ID);
        }
        #endregion
    }
}