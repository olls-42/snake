using System;
using UnityEngine;

namespace Game
{
    public class Square : MonoBehaviour
    {
        public Grid Grid;
        private GameObject _snake;
        private Snake _snakeClass;

        private void Awake()
        {
            this.GetGrid();
            _snake = GameObject.Find("Game/Snake");
            _snakeClass = _snake.GetComponent<Snake>();
            
        }
        // Start is called before the first frame update
        private void Start()
        {
        }

        void OnGUI()
        {
            
            /*
            GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
            fontSize.fontSize = 15;
            
            var _gridArray = new int[Grid.Width, Grid.Height];

            for (var x = 0; x < _gridArray.GetLength(0); x++)
            {
                for (var y = 0; y < _gridArray.GetLength(1); y++)
                {
                    //Debug.Log($"{x}:{y}:{Grid.GetWorldPosition(x, y)}");
                    var pos = Grid.GetWorldPosition(x, y);
                    GUI.Label(new Rect(pos.x, pos.y, 10, 10), $"{x}:{y}:{Grid.GetWorldPosition(x, y)}", fontSize);
                }
            }
            */
        }

        public void GetGrid()
        {
            this.Grid = Grid.NewGrid();
        }
        

        // Update is called once per frame
        void FixedUpdate()
        {
            //if (_snakeClass.GridX)
        }
    }
}
