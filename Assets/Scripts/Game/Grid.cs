using UnityEngine;
namespace Game
{
    public class Grid
    {
        public const int Width = 62;
        public const int Height = 22;
        public const float CellSize = 1f;
        private static Grid _instance;
        private int[,] _gridArray;

        private Grid()
        {
            this._gridArray = new int[Width, Height];
            
            for (var x = 0; x < _gridArray.GetLength(0); x++)
            {
                for (var y = 0; y < _gridArray.GetLength(1); y++)
                {
                    // Debug.Log($"{x}:{y}:{GetWorldPosition(x, y)}");
                }
            }
        }

        public static Grid NewGrid()
        {
            if (_instance != null)
            {
                return _instance;
            }

            return _instance = new Grid();
        }

        public static Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x, y, 0) * CellSize;
        }
    }
}
