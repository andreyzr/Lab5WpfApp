using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файл isf (*.isf)|*.isf";
            if (openFileDialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(openFileDialog.FileName,
                                               FileMode.Open);
                Canvas.Strokes = new StrokeCollection(fs);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файл isf (*.isf)|*.isf";
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog.FileName,
                                 FileMode.Create);
                Canvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string thickness = ((sender as ComboBox).SelectedItem as TextBlock).Text;

            switch (thickness)
            {
                case "Нормальная":
                    Canvas.DefaultDrawingAttributes.Width = 5;
                    break;
                case "Жирная":
                    Canvas.DefaultDrawingAttributes.Width = 10;
                    break;
                case "Тонкая":
                    Canvas.DefaultDrawingAttributes.Width = 1;
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Canvas.DefaultDrawingAttributes.Color != Colors.Red)
            {
                Canvas.DefaultDrawingAttributes.Color = Colors.Red;
            }
            else
            {
                Canvas.DefaultDrawingAttributes.Color = Colors.Black;
            }

        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (Canvas.DefaultDrawingAttributes.Color != Colors.Green)
            {
                Canvas.DefaultDrawingAttributes.Color = Colors.Green;
            }
            else
            {
                Canvas.DefaultDrawingAttributes.Color = Colors.Black;
            }
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            if (Canvas.DefaultDrawingAttributes.Color != Colors.Blue)
            {
                Canvas.DefaultDrawingAttributes.Color = Colors.Blue;
            }
            else
            {
                Canvas.DefaultDrawingAttributes.Color = Colors.Black;
            }
        }
    }
}
