namespace SudokuApi.SudokuSolver;

public class SudokuMain
{
    static int _count;

    public static int[][][] SolveMain(int[][][] data, out string infoMessage)
    {
        infoMessage = "";
        _count = 0;
        bool isWrongInput;

        // from int [][][] to int [,,]
        int[,,] array = Components.ChangeArrayFromInput(data);

        // scan metods -> scan for two same numbers in one row, collumn or section and return bool
        // first time -> catch wrong input
        isWrongInput = ScanError.FirstScanWrongImput(array, out string errorMesage);
        if (isWrongInput) infoMessage = errorMesage;


        if (!isWrongInput)
        {
            BasicMetodsForSolve(array);

            if (!ScanMetods.IsSudokuSolved(array) && !ScanError.MainFunc(array))
                // trying numbers and catching error until solve sudoku
                array = Components.ArrayCopy(AdvencedMetods(array));


            // final controll for errors in sudoku
            if (ScanError.MainFunc(array)) { infoMessage = $"Vyskytla se chyba! Počet Cyklů: {_count}."; }
            else if (ScanMetods.IsSudokuSolved(array)) { infoMessage = $"Sudoku vyřešeno za {_count} cyklů."; }
        }

        if (infoMessage == null) infoMessage = $"Count: {_count}";
            return Components.ChangeArrayToOutput(array);
    }



    private static int[,,] BasicMetodsForSolve(int[,,] array)
    {
        int[,,] arrayCopy = new int[9, 9, 10];

        do
        {
            arrayCopy = Components.ArrayCopy(array);

            //Scan array[,,] with diferent metods to find posible numbers.
            ScanMetods.MainFunc(array, false);
            //if number is not minus set number to plus(small numbers from array Z)
            //only one is enought!
            if (_count == 1) ScanMetods.PossibleNumbersScan(array);



            //// If on rows is only one small number -> set number as big number
            FindNumber.RowsOrCollumnsSearch(array, false);
            //// If on Columns is only one small number -> set number as big number
            FindNumber.RowsOrCollumnsSearch(array, true);


            //Scan array[,,] with diferent metods to find posible numbers.
            ScanMetods.MainFunc(array, false);


            // if only one small number in segment set number as big.
            FindNumber.OneSmallNumberToBigNumber(array);


            //Scan array[,,] with diferent metods to find posible numbers.
            ScanMetods.MainFunc(array, true);


            // if only one small number in section set it to big number.
            FindNumber.OnlyOneSmallNumberInSection(array);


            ScanMetods.MainFunc(array, true);

            _count++;
        } while (!Components.Array3DCompare(array, arrayCopy));

        return array;
    }


    private static int[,,] AdvencedMetods(int[,,] array)
    {
        int[,,] arrayCopy = new int[9, 9, 10];


        for (int Y = 0; Y < 9; Y++)
            for (int X = 0; X < 9; X++)
                if (array[Y, X, 0] == 0)
                {

                    // for number 1 - 9 in sudoku finding small plus numbers
                    for (int number = 1; number < 10; number++)
                    {

                        if (array[Y, X, number] > 0)
                        {
                            arrayCopy = Components.ArrayCopy(array);
                            array[Y, X, 0] = number;
                            BasicMetodsForSolve(array);
                            if (ScanError.MainFunc(array))
                            {
                                // create copy of array and if find problem. Use backup.
                                array = Components.ArrayCopy(arrayCopy);
                                array[Y, X, number] = -1 * number;
                                continue;
                            }
                            if (ScanMetods.IsSudokuSolved(array)) return array;

                            // use backup
                            array = Components.ArrayCopy(arrayCopy);
                        }
                    }
                }
        return array;
    }











}













