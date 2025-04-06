namespace SudokuApi.SudokuSolver
{
    public class ScanMetods
    {

        public static int[,,] MainFunc(int[,,] array, bool isAdvencedSolve = false)
        {
            //scan for rows
            RowsOrCollumnsScan(array, false);
            // scan for collumns
            RowsOrCollumnsScan(array, true);
            // Clear all small numbers in section if same big number is in section
            ClearSmallNumbersInSection(array);

            if (isAdvencedSolve)
            {
                RowInOneSectionOnlyPossible(array);
                CollumnInOneSectionOnlyPossible(array);

            }


            return array;
        }



        // Number 1
        // scan numbers, if find number -> all numbers in line canot be this number 
        private static int[,,] RowsOrCollumnsScan(int[,,] array, bool forCollumns = false)
        {
            // for number 1 - 9
            for (int number = 1; number < 10; number++)
            {
                // for dimensions Y X
                for (int Y = 0; Y < 9; Y++)
                {
                    bool IsNumberFind = false;
                    for (int X = 0; X < 9; X++)
                    {
                        // if find big number -> set small numbers to minus
                        if (array[Y, X, 0] > 0) array[Y, X, number] = -1 * number;

                        if (forCollumns)
                        {
                            // for collumns
                            if (IsNumberFind) array[X, Y, number] = -1 * number;
                            if (!IsNumberFind && number == array[X, Y, 0]) { IsNumberFind = true; X = -1; }
                        }
                        else
                        {
                            // for rows
                            if (IsNumberFind) array[Y, X, number] = -1 * number;
                            if (!IsNumberFind && number == array[Y, X, 0]) { IsNumberFind = true; X = -1; }
                        }
                    }

                }

            }
            return array;
        }



        // Number 2
        // if number array Z (small-number) is not minus then set number to plus +number; 

        public static int[,,] PossibleNumbersScan(int[,,] array)
        {

            for (int number = 1; number < 10; number++)
            {

                for (int Y = 0; Y < 9; Y++)
                    for (int X = 0; X < 9; X++)
                        if (array[Y, X, 0] == 0 && array[Y, X, number] != -1 * number) array[Y, X, number] = number;


            }
            return array;
        }



        // Number 3
        // Setl small numbers in section to minus if same big number is in section
        private static int[,,] ClearSmallNumbersInSection(int[,,] array)
        {

            //// for number 1 - 9 in sudoku
            for (int number = 1; number < 10; number++)
            {

                // for section Y X
                for (int sectionY = 0; sectionY < 3; sectionY++)
                    for (int sectionX = 0; sectionX < 3; sectionX++)
                    {

                        bool isNumberFind = false;

                        for (int Y = 0 + (sectionY * 3); Y < 3 + (sectionY * 3); Y++)
                            for (int X = 0 + (sectionX * 3); X < 3 + (sectionX * 3); X++)
                            {
                                if (!isNumberFind && array[Y, X, 0] == number)
                                {
                                    isNumberFind = true;
                                    Y = -1 + (sectionY * 3);
                                    break;
                                }
                                else if (isNumberFind)
                                {
                                    array[Y, X, number] = -1 * number;
                                }
                            }

                    }

            }
            return array;
        }



        //Number4
        // if numbers is only in one row in section, set in same rows in other section minus small number;
        private static int[,,] RowInOneSectionOnlyPossible(int[,,] array)
        {
            // for number 1 - 9 in sudoku
            for (int number = 1; number < 10; number++)
            {

                for (int sectionY = 0; sectionY < 3; sectionY++)
                    for (int sectionX = 0; sectionX < 3; sectionX++)
                    {
                        int posY = 0;
                        int count = 0;

                        for (int Y = 0 + (sectionY * 3); Y < 3 + (sectionY * 3); Y++)
                            for (int X = 0 + (sectionX * 3); X < 3 + (sectionX * 3); X++)
                            {
                                if (array[Y, X, number] == number) { count++; posY = Y; break; }
                                if (count > 2) break;
                            }

                        if (count == 1)
                            for (int rowX = 0; rowX < 9; rowX++)
                            {
                                if ((sectionX * 3) + 0 == rowX || (sectionX * 3) + 1 == rowX || (sectionX * 3) + 2 == rowX) { continue; }
                                array[posY, rowX, number] = -1 * number;
                            }
                    }
            }
            return array;
        }

        //Number5
        // if numbers is only in one collumn in section, set in same collumn in other section minus small number;
        private static int[,,] CollumnInOneSectionOnlyPossible(int[,,] array)
        {
            // for number 1 - 9 in sudoku
            for (int number = 1; number < 10; number++)
            {

                for (int sectionY = 0; sectionY < 3; sectionY++)
                    for (int sectionX = 0; sectionX < 3; sectionX++)
                    {
                        int posX = 0;
                        int count = 0;

                        for (int X = 0 + (sectionX * 3); X < 3 + (sectionX * 3); X++)
                            for (int Y = 0 + (sectionY * 3); Y < 3 + (sectionY * 3); Y++)
                            {
                                if (array[Y, X, number] == number) { count++; posX = X; break; }
                                if (count > 2) break;
                            }

                        if (count == 1)
                            for (int rowY = 0; rowY < 9; rowY++)
                            {
                                if ((sectionY * 3) + 0 == rowY || (sectionY * 3) + 1 == rowY || (sectionY * 3) + 2 == rowY) { continue; }
                                array[rowY, posX, number] = -1 * number;
                            }
                    }
            }
            return array;
        }


        // Number 6
        
        public static bool IsSudokuSolved(int[,,] array)
        {
            for (int Y = 0; Y < 9; Y++)
                for (int X = 0; X < 9; X++)
                    if (array[Y, X, 0] == 0) return false;

            return true;
        }






    }
}

