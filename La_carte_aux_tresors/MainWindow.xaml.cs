using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;
namespace La_carte_aux_tresors
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool inputChosen;
        bool outputChosen;
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            inputPathTextBox.Text = "Open input file";
            outputPathTextBox.Text = "Open output file";
            inputChosen = false;
            outputChosen = false;
        }

        public void OpenFileDialog_input(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == true)
            {
                inputPathTextBox.Text = openFileDialog.FileName;      
            }
            inputChosen = true;
            if (outputChosen)
            {
                ButtonRun.IsEnabled = true;
            }
            ButtonOpenFile.IsEnabled = false;
        }

        public void OpenFileDialog_output(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == true)
            {
                outputPathTextBox.Text = openFileDialog.FileName;
            }
            outputChosen = true;
            if (inputChosen)
            {
                ButtonRun.IsEnabled = true;
            }
            ButtonOpenFile.IsEnabled = false;
        }

        public void Run(object sender, RoutedEventArgs e)
        {
            string absolutePath_input = inputPathTextBox.Text;
            string absolutePath_output = outputPathTextBox.Text;
            GameManager gameManager = new GameManager();
            gameManager.initializeData(InputReader.ReadFile(absolutePath_input));
            gameManager._adventurer.move(gameManager);
            OutputWriter.Write(gameManager.mapToOutput(), absolutePath_output);
            ButtonOpenFile.IsEnabled = true;
        }

        public void OpenFile(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", outputPathTextBox.Text);
        }


    }
}
