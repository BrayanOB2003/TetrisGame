using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Piece
    {
        private const int PIECE_TYPE_0 = 0; 
        private const int PIECE_TYPE_1 = 1;
        private const int PIECE_TYPE_2 = 2;
        private const int PIECE_TYPE_3 = 3;
        private const int PIECE_TYPE_4 = 4;
        private const int PIECE_TYPE_5 = 5;
        private const int PIECE_TYPE_6 = 6;
        private const int DEFECT_VALUE_OF_MATRIX = -1;
        private const int ABSOLUTE_BLOCK = 2, ABSOLUTE_BLOCK2 = 1; //X coordinates of the obsolute blocks of the pieces
        private int formType;
        private int id;
        private int[,] form;
        private List<int> cordenadesX, cordenadesY;
        private List<int> relativeCordenadesX, relativeCordenadesY;
        private List<int> indexes; //Indexes of childrens' grid
        private List<Object> figure;

        public Piece()
        {
            form = new int[4, 4];
            id = -1;
            InitialicedMatrix();
            cordenadesX = new List<int> ();
            cordenadesY = new List<int> ();
            relativeCordenadesX = new List<int>();
            relativeCordenadesY = new List<int>();
            indexes = new List<int> ();
            Figure = new List<Object> ();
        }

        public int Id { get => id; set => id = value; }
        public int[,] Form { get => form; set => form = value; }
        public int DEFECT_VALUE => DEFECT_VALUE_OF_MATRIX;
        public List<int> CordenadesX { get => cordenadesX; set => cordenadesX = value; }
        public List<int> CordenadesY { get => cordenadesY; set => cordenadesY = value; }
        public List<int> Indexes { get => indexes; set => indexes = value; }
        public List<object> Figure { get => figure; set => figure = value; }
        public List<int> RelativeCordenadesX { get => relativeCordenadesX; set => relativeCordenadesX = value; }
        public List<int> RelativeCordenadesY { get => relativeCordenadesY; set => relativeCordenadesY = value; }
        public int FormType { get => formType; set => formType = value; }

        public void InitialicedMatrix() 
        {
            for(int i = 0; i < form.GetLength(0); i++)
            {
                for (int j = 0;j < form.GetLength(1); j++)
                {
                    form[i, j] = DEFECT_VALUE_OF_MATRIX;
                }
            }
        }

        public int[,] Rotate()
        {

            int[,] newForm = new int[4,4];
            int size = form.GetLength(0);
            List<int> relativeX = new List<int>();
            List<int> relativeY = new List<int>();
            int absoluteX = 0;
            int absoluteY = 0;

            for (int i = 0, j = size - 1; i < size && j >= 0; i += 1, j -= 1)
            {
                for (int k = 0; k < size; k++)
                {
                    newForm[k, j] = form[i, k];
                }
            }
            
            formType++;

            if (formType == 0)
            {
                absoluteX = 2;
                absoluteY = 1;
            } else if(formType == 1)
            {
                absoluteX = 2;
                absoluteY = 2;
            } else if(formType == 2)
            {
                absoluteX = 1;
                absoluteY = 2;
            }
            else if(formType == 3)
            {
                absoluteX = 1;
                absoluteY = 1;
                formType = -1;
            }

            for(int i = 0; i < newForm.GetLength(0); i++)
            {
                for(int j = 0; j < newForm.GetLength(1); j++)
                {
                    if(newForm[i,j] != DEFECT_VALUE_OF_MATRIX)
                    {
                        if(!(j - absoluteX == 0 && i - absoluteY == 0))
                        {
                            relativeX.Add(j - absoluteX);
                            relativeY.Add(i - absoluteY);
                        }
                    }
                }
            }

            for(int i = 1; i < relativeCordenadesX.Count; i++)
            {
                relativeCordenadesX[i] = relativeCordenadesX[0] + relativeX[i - 1];
                relativeCordenadesY[i] = relativeCordenadesY[0] + relativeY[i - 1];
            }
            /*
            String c = "";
            for(int i = 0; i < relativeCordenadesX.Count; i++)
            {
                c += relativeCordenadesX[i] + " - " + relativeCordenadesY[i] + "  ";
            }

            String p = "";
            for(int j = 0; j < cordenadesX.Count; j++)
            {
                p += cordenadesX[j] + " - " + cordenadesY[j] + "  ";
            }

            System.Windows.MessageBox.Show(c + "\n" + p);
            */
            return newForm;
        }

        public int[,] generate()
        {
            int type = new Random().Next(0,7);
            //int type = 6;
            switch (type)
            {
                case 0:
                    form = generateType0();
                    id = PIECE_TYPE_0;
                    break;

                case 1:
                    form = generateType1();
                    id = PIECE_TYPE_1;
                    break;

                case 2:
                    form = generateType2();
                    id = PIECE_TYPE_2;
                    break;

                case 3:
                    form = generateType3();
                    id = PIECE_TYPE_3;
                    break;

                case 4:
                    form = generateType4();
                    id = PIECE_TYPE_4;
                    break;

                case 5:
                    form = generateType5();
                    id = PIECE_TYPE_5;
                    break;

                case 6:
                    form = generateType6();
                    id = PIECE_TYPE_6;
                    break;
            }


            return form;
        }

        private int[,] generateType0()
        {
            int[,] piece = form;
            piece[1,0] = PIECE_TYPE_0;
            piece[1, 1] = PIECE_TYPE_0;
            piece[1, 2] = PIECE_TYPE_0;
            piece[1, 3] = PIECE_TYPE_0;

            /*
            -1 -1 -1 -1
             0  0  0  0
            -1 -1 -1 -1
            -1 -1 -1 -1
            */
            return piece;
        }

        private int[,] generateType1()
        {
            int[,] piece = form;
            piece[2, 3] = PIECE_TYPE_1;
            piece[1, 1] = PIECE_TYPE_1;
            piece[1, 2] = PIECE_TYPE_1;
            piece[1, 3] = PIECE_TYPE_1;

            /*
            -1 -1 -1 -1
            -1  0  0  0
            -1 -1 -1  0
            -1 -1 -1 -1
            */
            return piece;
        }

        private int[,] generateType2()
        {
            int[,] piece = form;
            piece[1, 1] = PIECE_TYPE_2;
            piece[2, 1] = PIECE_TYPE_2;
            piece[1, 2] = PIECE_TYPE_2;
            piece[1, 3] = PIECE_TYPE_2;

            /*
            -1 -1 -1 -1
            -1  0  0  0
            -1  0 -1 -1
            -1 -1 -1 -1
            */
            return piece;
        }

        private int[,] generateType3()
        {
            int[,] piece = form;
            piece[1, 1] = PIECE_TYPE_3;
            piece[1, 2] = PIECE_TYPE_3;
            piece[2, 2] = PIECE_TYPE_3;
            piece[2, 1] = PIECE_TYPE_3;

            /*
            -1 -1 -1 -1
            -1  0  0 -1
            -1  0  0 -1
            -1 -1 -1 -1
            */
            return piece;
        }

        private int[,] generateType4()
        {
            int[,] piece = form;
            piece[1, 2] = PIECE_TYPE_4;
            piece[1, 3] = PIECE_TYPE_4;
            piece[2, 2] = PIECE_TYPE_4;
            piece[2, 1] = PIECE_TYPE_4;

            /*
            -1 -1 -1 -1
            -1 -1  0  0
            -1  0  0 -1
            -1 -1 -1 -1
            */
            return piece;
        }

        private int[,] generateType5()
        {
            int[,] piece = form;
            piece[1, 1] = PIECE_TYPE_4;
            piece[1, 2] = PIECE_TYPE_4;
            piece[1, 3] = PIECE_TYPE_4;
            piece[2, 2] = PIECE_TYPE_4;

            /*
            -1 -1 -1 -1
            -1  0  0  0
            -1 -1  0 -1
            -1 -1 -1 -1
            */
            return piece;
        }

        private int[,] generateType6()
        {
            int[,] piece = form;
            piece[1, 1] = PIECE_TYPE_6;
            piece[1, 2] = PIECE_TYPE_6;
            piece[2, 2] = PIECE_TYPE_6;
            piece[2, 3] = PIECE_TYPE_6;

            /*
            -1 -1 -1 -1
            -1  0  0 -1
            -1 -1  0  0
            -1 -1 -1 -1
            */
            return piece;
        }

        public void MoveLeft()
        {
            for(int i = 0; i < relativeCordenadesX.Count; i++)
            {
                relativeCordenadesX[i] -= 1;
            }
        }

        public void MoveRigth()
        {
            for (int i = 0; i < relativeCordenadesX.Count; i++)
            {
                relativeCordenadesX[i] += 1;
            }
        }
        public void MoveDown()
        {
            for (int i = 0; i < relativeCordenadesY.Count; i++)
            {
                relativeCordenadesY[i] += 1;
            }
        }
    }
}
