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
        const int INITIAL_POSITION = 4;
        private Piece currentPiece;

        public MainWindow()
        {
            
            InitializeComponent();
            
        }

        public void GenerateAndPaintPiece() 
        {
            
            currentPiece = new Piece();
            currentPiece.generate();
            int[,] form = currentPiece.Form;

            for (int i = 0; i < form.GetLength(0); i++)
            {
                for (int j = 0; j < form.GetLength(1); j++)
                {
                    if(form[i,j] != currentPiece.DEFECT_VALUE)
                    {
                        Rectangle rect = new Rectangle
                        {
                            Width = 45,
                            Height = 45
                        };
                        SolidColorBrush c = new SolidColorBrush
                        {
                            Color = Color.FromArgb(255, 255, 255, 0)
                        };
                        rect.Fill = c;
                        Grid.SetColumn(rect, INITIAL_POSITION + i);
                        Grid.SetRow(rect, j);
                        currentPiece.CordenadesX.Add(INITIAL_POSITION + i);
                        currentPiece.CordenadesY.Add(j);
                        grid.Children.Add(rect);
                    }
                }
                
            }
        }

        public void PieceDown()
        {
            grid.Children.Clear();
            int[,] current = currentPiece.Form;
            for (int i = 0; i < currentPiece.CordenadesX.Capacity; i++)
            {
                int x = currentPiece.CordenadesX[i];
                int y = currentPiece.CordenadesY[i];
                Rectangle rect = new Rectangle();
                rect.Width = 45;
                rect.Height = 45;
                SolidColorBrush c = new SolidColorBrush();
                c.Color = Color.FromArgb(255, 255, 255, 0);
                rect.Fill = c;
                Grid.SetColumn(rect, x);
                Grid.SetRow(rect, y + 1);
                currentPiece.CordenadesY[i] = y + 1;
                grid.Children.Add(rect);
            }
        }

        private void MovePieceDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                PieceDown();
            }
            if (e.Key == Key.Space)
            {
                GenerateAndPaintPiece();
            }
        }
    }
}
