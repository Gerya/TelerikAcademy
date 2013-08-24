using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarshipFight
{
    public abstract class GameObjects : IRenderable, ICollidable
    {
        protected Position position;
        protected char[,] objectBody;
        protected bool isDestroyed = false;

        public GameObjects(Position startPosition, char[,] body)
        {
            this.position = startPosition;
            this.objectBody = this.CopyBodyMatrix(body);
        }

        public Position GetPosition
        {
            get
            {
                return new Position(position.Row, position.Col);
            }
            protected set
            {
                this.position = new Position(value.Row, value.Col);
            }
        }

        public bool IsDestroyed
        {
            get { return this.isDestroyed; }
            set
            {
                this.isDestroyed = value;
            }
        }
        
        private char[,] CopyBodyMatrix(char[,] matrixToCopy)
        {
            int rows = matrixToCopy.GetLength(0);
            int cols = matrixToCopy.GetLength(1);
            char[,] resultMatrix = new char[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    resultMatrix[i, j] = matrixToCopy[i, j];
                }
            }
            return resultMatrix;
        }

        public char[,] GetImage()
        {
            return this.CopyBodyMatrix(objectBody);
        }

        public abstract void Move();
        public virtual void Collide(GameObjects obj)
        {
            this.IsDestroyed = true;
        }
    }
}