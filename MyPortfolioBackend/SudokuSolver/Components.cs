namespace SudokuApi.SudokuSolver
{
    public class Components
    {

        // Change input array int[9][9][10] to int[9,9,10]
        public static int[,,] ChangeArrayFromInput(int[][][] data)
        {
            int[,,] inputArray = new int[9, 9, 10];

            for (int y = 0; y < data.Length; y++)
                for (int x = 0; x < data[0].Length; x++)
                    for (int z = 0; z < data[0][0].Length; z++)
                        inputArray[y, x, z] = data[y][x][z];

            return inputArray;
        }


        // Change output array from int[9,9,10] to int [9][9][10]
        public static int[][][] ChangeArrayToOutput(int[,,] data)
        {
            int[][][] outputArray = new int[9][][];

            for (int y = 0; y < 9; y++)
            {
                outputArray[y] = new int[9][];

                for (int x = 0; x < 9; x++)
                {
                    outputArray[y][x] = new int[10];
                    for (int z = 0; z < 10; z++)
                    {
                        outputArray[y][x][z] = data[y, x, z];
                    }
                }
            }
            return outputArray;
        }


        // Create copy of 3d array
        public static int[,,] ArrayCopy(int[,,] array)
        {
            int[,,] arrayCopy = new int[9, 9, 10];

            for (int Y = 0; Y < 9; Y++)
                for (int X = 0; X < 9; X++)
                    for (int Z = 0; Z < 10; Z++)
                        arrayCopy[Y, X, Z] = array[Y, X, Z];
            return arrayCopy;
        }


        // Compare two array int[,,] if they are same or not and return bool
        public static bool Array3DCompare(int[,,] firstArray, int[,,] secondArray)
        {

            for (int Y = 0; Y < 9; Y++)
                for (int X = 0; X < 9; X++)
                    for (int Z = 0; Z < 10; Z++)
                        if (firstArray[Y, X, Z] != secondArray[Y, X, Z]) return false;
            return true;
        }

    }
}
