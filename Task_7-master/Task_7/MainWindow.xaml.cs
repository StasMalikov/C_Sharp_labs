
using System.Windows;
using System.Windows.Forms;
using FileManager;
using JSON;
using DrawGraph;

namespace Task_7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           //MainGrid. WindowState = "Maximized";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Reader read = new Reader();
                read.ReadFile(openFileDialog.FileName);
                Deserialization d = new Deserialization();
                Drawer dr = new Drawer(d.Deserialize(read.ReadFile(openFileDialog.FileName)),
                    Graph_image.DesiredSize.Width, Graph_image.DesiredSize.Height);

                Graph_image.Source = Converter.ToBitmapImage(dr.Draw());
            }
        }
    }
}
