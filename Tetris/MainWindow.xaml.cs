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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            show();
        }

        public void show()
        {
            

            for (int i = 0; i < 12; i++) 
            {
                Rectangle rect = new Rectangle();
                rect.Width = 45;
                rect.Height = 50;
                SolidColorBrush c = new SolidColorBrush();
                c.Color = Color.FromArgb(255, 255, 255, 0);
                rect.Fill = c;
                Grid.SetColumn(rect, i);
                Grid.SetRow(rect, 0);
                grid.Children.Add(rect);
            }
           

        }
    }
}
