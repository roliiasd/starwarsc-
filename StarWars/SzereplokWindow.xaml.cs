using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NetworkHelper;
using StarWars.Modules;

namespace StarWars
{
    
    public partial class SzereplokWindow : Window
    {
        List<Szereplo> szereplok= new List<Szereplo>();
        public SzereplokWindow()
        {
            
            InitializeComponent();
            szereplok = Backend.GET("https://akabab.github.io/starwars-api/api/all.json")
                .Send().As<List<Szereplo>>();
            lista.ItemsSource = szereplok;
            lista.DisplayMemberPath = "Name";
            neme.ItemsSource = szereplok.Select(x=> x.Gender).Distinct().Prepend("Összes").ToList();
            neme.SelectedIndex = 0;
            faj.ItemsSource = szereplok.Select(x=> x.Species).Distinct().Prepend("Összes").ToList();
            faj.SelectedIndex = 0;
            this.Closing += SzereplokWindow_Closing;
            gomb.Click += Gomb_Click;

        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            List<Szereplo> szurtLista = new List<Szereplo>(szereplok);
            string nemeErtek= neme.SelectedItem as string;
            if (nemeErtek != "Összes")
            {
                szurtLista = szurtLista.Where(x=>x.Gender==nemeErtek).ToList();
            }


            lista.ItemsSource = szurtLista;
        }

        private void SzereplokWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
