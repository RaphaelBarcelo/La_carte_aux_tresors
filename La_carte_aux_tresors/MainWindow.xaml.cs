using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.CompilerServices;
using System.Diagnostics;


namespace La_carte_aux_tresors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            inputPathTextBox.Text = "Insert map file path here";
        }

        public void ButtonPath1Click(object sender, RoutedEventArgs e)
        {
            inputPathTextBox.Text = "nouveau chemin crée par bouton 1";
        }

        public void ButtonPath2Click(object sender, RoutedEventArgs e)
        {
            inputPathTextBox.Text = "nouveau chemin crée par bouton 2";
        }

        public void ButtonPath3Click(object sender, RoutedEventArgs e)
        {
            inputPathTextBox.Text = "nouveau chemin crée par bouton 3";
        }

        public void ButtonPath4Click(object sender, RoutedEventArgs e)
        {
            inputPathTextBox.Text = "nouveau chemin crée par bouton 4";
        }

        public void StartGame(object sender, RoutedEventArgs e)
        {
            GameManager gameSetup = new GameManager(InputReader.ReadFile());
            gameSetup._adventurer.move(gameSetup);
            OutputWriter.Write(gameSetup.mapToOutput());
        }

        

        
    }
}
