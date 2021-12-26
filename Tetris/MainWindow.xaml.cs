using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int INITIAL_POSITION = 4;
        private Piece currentPiece;
        private Rectangle currentBlock;
        public MainWindow()
        {
            currentPiece = new Piece();
            InitializeComponent();
            PaintBorder();
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
                        currentPiece.Indexes.Add(PaintBlock(INITIAL_POSITION + i, j + 1));
                        System.Windows.MessageBox.Show("Put");

                        currentPiece.CordenadesX.Add(INITIAL_POSITION + i);
                        currentPiece.CordenadesY.Add(j + 1);
                    }
                }
                
            }
            currentPiece.RelativeCordenadesX = currentPiece.CordenadesX.ToList();
            currentPiece.RelativeCordenadesY = currentPiece.CordenadesY.ToList();
        }

        private void PaintBorder()
        {
            int rows = 12;
            int colums = 14;

            for (int i = 0; i < colums;i++)
            {
                PaintBlock(11,i);
                PaintBlock(0,i);
            }

            for (int i = 0; i < rows; i++)
            {
                PaintBlock(i,13);
                PaintBlock(i,0);
            }
        }
        private int PaintBlock(int x, int y)
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

                default:
                    c.Color = Color.FromRgb(119, 136, 153);
                    break;
            }
            currentBlock.Fill = c;
            Grid.SetColumn(currentBlock, x);
            Grid.SetRow(currentBlock, y);
            grid.Children.Add(currentBlock);
            currentPiece.Figure.Add(currentBlock);
            return grid.Children.IndexOf(currentBlock); //Return the index elements of grid
        }

        private void DeletePiece()
        {
            if(currentPiece != null)
            {
                grid.Children.RemoveRange(currentPiece.Indexes[0], currentPiece.Indexes[3]);
            }
        }

        private bool Colision()
        {
            
            System.Collections.IEnumerator elements = grid.Children.GetEnumerator();

            List<int> PieceCoordenadesX = currentPiece.RelativeCordenadesX.ToList();
            List<int> PieceCoordenadesY = currentPiece.RelativeCordenadesY.ToList();
            List<int> coordenadesX = new List<int>();
            List<int> coordenadesY = new List<int>();

            bool colision = false;
            while(elements.MoveNext())
            {
                if(currentPiece.Figure.All(UIElement => UIElement != elements.Current))
                {
                    coordenadesX.Add(Grid.GetColumn((UIElement)elements.Current));
                    coordenadesY.Add(Grid.GetRow((UIElement)elements.Current));
                }
                
            }

            for (int i = 0; i < PieceCoordenadesX.Count; i++)
            {
                for (int j = 0; j < coordenadesX.Count; j++)
                {
                    if ((PieceCoordenadesX[i]) == coordenadesX[j])
                    {
                        if (PieceCoordenadesY[i] == coordenadesY[j])
                        {
                            colision = true;
                            break;
                        }
                    }
                }
            }

            if(!colision)
            {
                currentPiece.CordenadesX = PieceCoordenadesX;
                currentPiece.CordenadesY = PieceCoordenadesY;
                DeletePiece();
            } else
            {
                currentPiece.RelativeCordenadesX = currentPiece.CordenadesX.ToList();
                currentPiece.RelativeCordenadesY = currentPiece.CordenadesY.ToList();
            }

            return colision;
        }

        private void PaintPiece()
        {
            for (int i = 0; i < currentPiece.CordenadesX.Capacity; i++)
            {
                PaintBlock(currentPiece.CordenadesX[i], currentPiece.CordenadesY[i]);
            }
        }

        public void PieceDown()
        {

            currentPiece.MoveDown();

            if (!Colision())
            {
                PaintPiece();
            }

        }

        public void PieceLeft()
        {
            currentPiece.MoveLeft();

            if (!Colision())
            {
                PaintPiece();
            }
        }

        public void PieceRigth()
        {
            currentPiece.MoveRigth();

            if (!Colision())
            {
                PaintPiece();
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
