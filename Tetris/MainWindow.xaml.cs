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
        const int INITIAL_POSITION = 3;

        public MainWindow()
        {
            
            InitializeComponent();
            generateAndPaintPiece();
        }

        public void generateAndPaintPiece() 
        {
            Piece p = new Piece();
            p.generate();
            int[,] form = p.Form;

            for (int i = 0; i < form.GetLength(1); i++)
            {
                for (int j = 0; j < form.GetLength(0); j++)
                {
                    if(form[i,j] != p.DEFECT_VALUE)
                    {
                        Rectangle rect = new Rectangle();
                        rect.Width = 45;
                        rect.Height = 45;
                        SolidColorBrush c = new SolidColorBrush();
                        c.Color = Color.FromArgb(255, 255, 255, 0);
                        rect.Fill = c;
                        Grid.SetColumn(rect,INITIAL_POSITION + i);
                        Grid.SetRow(rect, j);
                        grid.Children.Add(rect);
                    }
                }
                
            }
        }
    }
}
