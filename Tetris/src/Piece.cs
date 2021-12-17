using System;
using System.Collections.Generic;
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
        private int id;
        private int[,] form;

        public Piece()
        {
            form = new int[4, 4];
            initialicedMatrix();
            
        }

        public int Id { get => id; set => id = value; }
        public int[,] Form { get => form; set => form = value; }

        public int DEFECT_VALUE => DEFECT_VALUE_OF_MATRIX;

        public void initialicedMatrix() 
        {
            for(int i = 0; i < form.GetLength(0); i++)
            {
                for (int j = 0;j < form.GetLength(1); j++)
                {
                    form[i, j] = DEFECT_VALUE_OF_MATRIX;
                }
            }
        }

        public int[,] generate() 
        {
            int type = new Random().Next(0,7);

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
            piece[0,0] = PIECE_TYPE_0;
            piece[1, 0] = PIECE_TYPE_0;
            piece[2, 0] = PIECE_TYPE_0;
            piece[3, 0] = PIECE_TYPE_0;

            return piece;
        }

        private int[,] generateType1()
        {
            int[,] piece = form;
            piece[0, 0] = PIECE_TYPE_1;
            piece[1, 0] = PIECE_TYPE_1;
            piece[2, 0] = PIECE_TYPE_1;
            piece[2, 1] = PIECE_TYPE_1;

            return piece;
        }

        private int[,] generateType2()
        {
            int[,] piece = form;
            piece[0, 0] = PIECE_TYPE_2;
            piece[0, 1] = PIECE_TYPE_2;
            piece[2, 0] = PIECE_TYPE_2;
            piece[3, 0] = PIECE_TYPE_2;

            return piece;
        }

        private int[,] generateType3()
        {
            int[,] piece = form;
            piece[0, 0] = PIECE_TYPE_3;
            piece[1, 0] = PIECE_TYPE_3;
            piece[0, 1] = PIECE_TYPE_3;
            piece[1, 1] = PIECE_TYPE_3;

            return piece;
        }

        private int[,] generateType4()
        {
            int[,] piece = form;
            piece[1, 0] = PIECE_TYPE_4;
            piece[2, 0] = PIECE_TYPE_4;
            piece[0, 1] = PIECE_TYPE_4;
            piece[1, 1] = PIECE_TYPE_4;

            return piece;
        }

        private int[,] generateType5()
        {
            int[,] piece = form;
            piece[0, 0] = PIECE_TYPE_4;
            piece[1, 0] = PIECE_TYPE_4;
            piece[2, 0] = PIECE_TYPE_4;
            piece[1, 1] = PIECE_TYPE_4;

            return piece;
        }

        private int[,] generateType6()
        {
            int[,] piece = form;
            piece[0, 0] = PIECE_TYPE_6;
            piece[1, 0] = PIECE_TYPE_6;
            piece[1, 1] = PIECE_TYPE_6;
            piece[2, 1] = PIECE_TYPE_6;

            return piece;
        }

    }
}
