namespace SudokuApi.SudokuSolver
{
    public class FindNumber
    {

        //Number 1
        // If on row is only one small number -> set number as big number
        public static int[,,] RowsOrCollumnsSearch(int[,,] array, bool forCollumns = false)
        {
            //  for 1 - 9
            for (int number = 1; number < 10; number++)
            {
                //int number = 8;


                for (int Y = 0; Y < 9; Y++)
                {

                    int count = 0;
                    int posY = 0;
                    int posX = 0;

                    for (int X = 0; X < 9; X++)
                    {
                        if (forCollumns)
                        {
                            if (array[X, Y, number] == number) { ++count; posY = X; posX = Y; }
                        }
                        else
                        {
                            if (array[Y, X, number] == number) { ++count; posY = Y; posX = X; }
                        }
                        if (count > 2) break;
                    }
                    if (count == 1 && array[posY, posX, 0] == 0) array[posY, posX, 0] = number;
                }
            }
            return array;
        }



        // Number 2
        // if only one small number in segment set number as big.
        public static int[,,] OneSmallNumberToBigNumber(int[,,] array)
        {
            for (int Y = 0; Y < 9; Y++)
            {
                for (int X = 0; X < 9; X++)
                {

                    int count = 0;
                    int setNumber = 0;
                    // for 1 - 9 number in sudoku
                    for (int number = 1; number < 10; number++)
                    {
                        if (array[Y, X, number] == number)
                        {
                            count++;
                            if (count > 2) break;
                            setNumber = number;
                        }
                    }
                    if (count == 1 && array[Y, X, 0] == 0) array[Y, X, 0] = setNumber;
                }
            }
            return array;
        }



        // Number 3
        // if only one small number in section set it to big number.
        public static int[,,] OnlyOneSmallNumberInSection(int[,,] array)
        {

            // for number 1 - 9 in sudoku
            for (int number = 1; number < 10; number++)
            {

                // for section Y X
                for (int sectionY = 0; sectionY < 3; sectionY++)
                {
                    for (int sectionX = 0; sectionX < 3; sectionX++)
                    {

                        int count = 0;
                        int posY = 0;
                        int posX = 0;

                        for (int Y = 0 + (sectionY * 3); Y < 3 + (sectionY * 3); Y++)
                        {
                            for (int X = 0 + (sectionX * 3); X < 3 + (sectionX * 3); X++)
                            {
                                if (array[Y, X, number] == number) { count++; posY = Y; posX = X; }
                            }
                            if (count > 2) break;
                        }
                        if (count == 1 && array[posY, posX, 0] == 0) array[posY, posX, 0] = number;
                    }
                }
            }
            return array;
        }
















    }
}
