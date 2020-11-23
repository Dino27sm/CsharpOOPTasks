using System;
using _08.CollectionHierarchy.Models;

namespace _08.CollectionHierarchy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            AddCollection<string> addOnly = new AddCollection<string>();
            AddRemoveCollection<string> adddRemove = new AddRemoveCollection<string>();
            MyList<string> myList = new MyList<string>();

            string[] inpText = Console.ReadLine().Split(" ");
            int numRemovedItems = int.Parse(Console.ReadLine());

            int[,] matrixOfIndexes = new int[3, inpText.Length];
            for (int col = 0; col < inpText.Length; col++)
            {
                matrixOfIndexes[0, col] = addOnly.Add(inpText[col]);
                matrixOfIndexes[1, col] = adddRemove.Add(inpText[col]);
                matrixOfIndexes[2, col] = myList.Add(inpText[col]);
            }

            string[,] matrixRemovedItems = new string[2, numRemovedItems];
            for (int col = 0; col < numRemovedItems; col++)
            {
                matrixRemovedItems[0, col] = adddRemove.Remove();
                matrixRemovedItems[1, col] = myList.Remove();
            }
            PrintMatrix(matrixOfIndexes);
            PrintMatrix(matrixRemovedItems);
            //----------------------------------------------------------------------------------------------
        }

        public static void PrintMatrix<T>(T[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int row = 0; row < rows; row++)
            {
                T[] aRow = new T[cols];
                for (int col = 0; col < cols; col++)
                {
                    aRow[col] = matrix[row, col];
                }
                Console.WriteLine(string.Join(" ", aRow));
            }
        }
    }
}
