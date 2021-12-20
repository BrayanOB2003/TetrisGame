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
        private Rectangle currentBlock;
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
                        PaintPiece(INITIAL_POSITION + i, j);
                        currentPiece.CordenadesX.Add(INITIAL_POSITION + i);
                        currentPiece.CordenadesY.Add(j);
                    }
                }
                
            }
        }

        private void PaintPiece(int x, int y)
        {
            currentBlock = new Rectangle()
            {
                Width = 45,
                Height = 45
            };
            SolidColorBrush c = new SolidColorBrush();
            switch (currentPiece.Id)
            {
                case 0:
                    c.Color = Color.FromRgb(0,255,255);
                    break;

                case 1:
                    c.Color = Color.FromRgb(138, 43, 226);
                    break;

                case 2:
                    c.Color = Color.FromRgb(255, 165, 0);
                    break;

                case 3:
                    c.Color = Color.FromRgb(0, 0, 255);
                    break;

                case 4:
                    c.Color = Color.FromRgb(124, 252, 0);
                    break;

                case 5:
                    c.Color = Color.FromRgb(128, 0, 128);
                    break;

                case 6:
                    c.Color = Color.FromRgb(255, 0, 0);
                    break;
            }
            currentBlock.Fill = c;
            Grid.SetColumn(currentBlock, x);
            Grid.SetRow(currentBlock, y);
            grid.Children.Add(currentBlock);
        }

        private void DeletePiece(int x, int y)
        {
            currentBlock = new Rectangle()
            {
                Width = 47,
                Height = 47
            };
            SolidColorBrush c = new SolidColorBrush()
            {
                Color = Color.FromRgb(0,0,0)
            };
            currentBlock.Fill = c;
            Grid.SetColumn(currentBlock, x);
            Grid.SetRow(currentBlock, y);
            grid.Children.Add(currentBlock);
        }

        public void PieceDown()
        {
            int yInit = currentPiece.CordenadesY[0];
            for (int i = 0; i < currentPiece.CordenadesX.Capacity; i++)
            {
                int x = currentPiece.CordenadesX[i];
                int y = currentPiece.CordenadesY[i];
                PaintPiece(x, y + 1);
                DeletePiece(x, y);
                currentPiece.CordenadesY[i] = y + 1;
            }
        }

        public void PieceLeft()
        {
            grid.Children.Clear();
            for (int i = 0; i < currentPiece.CordenadesX.Capacity; i++)
            {
                int x = currentPiece.CordenadesX[i];
                int y = currentPiece.CordenadesY[i];
                PaintPiece(x - 1, y);
                currentPiece.CordenadesX[i] = x - 1;
            }
        }

        public void PieceRigth()
        {
            grid.Children.Clear();
            for (int i = 0; i < currentPiece.CordenadesX.Capacity; i++)
            {
                int x = currentPiece.CordenadesX[i];
                int y = currentPiece.CordenadesY[i];
                PaintPiece(x + 1, y);
                currentPiece.CordenadesX[i] = x + 1;
            }
        }

        private void MovePiece(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                PieceDown();
            } else if (e.Key == Key.Right)
            {
                PieceRigth();
            
            }else if (e.Key == Key.Left)
            {
                PieceLeft();
            }
            else if (e.Key == Key.Space)
            {
                GenerateAndPaintPiece();
            }
        }
    }
}
