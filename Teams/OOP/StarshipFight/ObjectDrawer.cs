using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public class ObjectDrawer : IRenderer
    {
        private int gameFieldRows;
        private int gameFieldCols;
        private char[,] objectsMatrix;
        public ObjectDrawer(int rows, int cols)
        {
            this.objectsMatrix = new char[rows, cols];
            this.gameFieldRows = this.objectsMatrix.GetLength(0);
            this.gameFieldCols = this.objectsMatrix.GetLength(1);

            this.ClearObjectsMatrix();
        }

        public void EnqueObject(GameObjects obj)
        {
            char[,] objImage = obj.GetImage();
            int objRows = objImage.GetLength(0);
            int objCols = objImage.GetLength(1);

            Position objPosition = obj.GetPosition;

            for (int i = obj.GetPosition.Row; i < (objPosition.Row + objRows); i++)
            {
                for (int j = obj.GetPosition.Col; j < (objPosition.Col + objCols); j++)
                {
                    if (i >= 0 && i < gameFieldRows && j >=0 && j < gameFieldCols)
                    {
                        objectsMatrix[i, j] = objImage[i - objPosition.Row, j - objPosition.Col];   
                    }
                }
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(0, 0);

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < objectsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < objectsMatrix.GetLength(1); j++)
                {
                    result.Append(objectsMatrix[i, j]);
                }
                result.Append(Environment.NewLine);
            }
            Console.OutputEncoding = new System.Text.UnicodeEncoding();
            Console.Write(result.ToString());

            Score();
        }

        private static void Score()
        {
            Console.SetCursorPosition(70, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("SCORE:{0:D3}        ", Collisions.CollisionCounter); //if here are not that many space lives symbol is put after the score. Kind of a bug
            Console.ResetColor();
        }

        public void ClearObjectsMatrix()
        {
            for (int i = 0; i < objectsMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < objectsMatrix.GetLength(1); j++)
                {
                    objectsMatrix[i, j] = ' ';
                }
            }
        }
    }
}
