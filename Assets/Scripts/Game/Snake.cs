using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.Serialization;

namespace Game
{
    public class Snake : MonoBehaviour
    {
        public MoveDirection MoveDirection {get; set;}
        private GameObject _square;
        private Vector3 _nextGridPosition;
        private Square _squareClass;
        public int GridX {get; set;}
        public int GridY {get; set;}
        private List<GameObject> _snake;
        public int SnakeLenght {get; set;}
        private List<Vector3> _snakeTurnsHistory;

        public void Awake()
        {
            this.SnakeLenght = 1;
            _square = GameObject.Find("Game/Square");
            _squareClass = this._square.GetComponent<Square>();
            this.MoveDirection = MoveDirection.Right;
            this.transform.position = Grid.GetWorldPosition(this.GridX, this.GridY);
        }
        public void Start()
        {
            _snake = new List<GameObject>();
            _snakeTurnsHistory = new List<Vector3>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {

            InputSystem.onEvent
                .ForDevice<Keyboard>()
                .Where(e => e.HasButtonPress())
                .CallOnce(ctrl =>
                {
                    Debug.Log($"Button {ctrl} pressed");
                });


        }
        private void RedrawSnake()
        {

            foreach (var snake in _snake)
            {
                Destroy(snake);
            }

            _snake.Clear();

            for (var i = 0; i < SnakeLenght; i++)
            {
                if (i < _snakeTurnsHistory.Count)
                {
                    GameObject snakeDot = Instantiate(GameObject.Find(this.name),
                        this.transform.position,
                        Quaternion.identity);

                    _snakeTurnsHistory.Reverse();

                    snakeDot.transform.position = _snakeTurnsHistory[i];

                    _snakeTurnsHistory.Reverse();
                    _snake.Add(snakeDot);
                }
            }
        }

        public void CustomMoveUpdate()
        {
            this.FollowMoveDirection();
            this.MirrorCanvasSides();
            this.RedrawSnake();
        }


        
        private void FollowMoveDirection()
        {
            var directionVector = this.GetDirectionVector();
            this.GridX = (int)(this.GridX + directionVector.x);
            this.GridY = (int)(this.GridY + directionVector.y);
            this.transform.position = Grid.GetWorldPosition(this.GridX, this.GridY);
            _snakeTurnsHistory.Add(this.transform.position);
            //Debug.Log($"this grid {this.GridX}:{this.GridY}");
            //Debug.Log($"this pos {this.transform.position.x}:{this.transform.position.y}");
        }
        
        private Vector2 GetDirectionVector()
        {

            var moveVector = new Vector2(0,0);

            switch (this.MoveDirection)
            {
                case MoveDirection.None:
                    moveVector = new Vector2(1, 0);
                    break;

                case MoveDirection.Up:
                    moveVector = new Vector2(0, 1);
                    break;

                case MoveDirection.Left:
                    moveVector = new Vector2(-1, 0);
                    break;

                case MoveDirection.Right:
                    moveVector = new Vector2(1, 0);
                    break;

                case MoveDirection.Down:
                    moveVector = new Vector2(0, -1);
                    break;
            }
            //Debug.Log($"move vector {moveVector.ToString()}");
            return moveVector;
        }

        private void MirrorCanvasSides()
        {

            /*
            var rect = _square.GetComponent<RectTransform>();
            var minX = rect.position.x + rect.rect.xMin;
            var maxX = rect.position.x + rect.rect.xMax;
            var minY = rect.position.y + rect.rect.yMin;
            var maxY = rect.position.y + rect.rect.yMax;
            */

            if (this.GridX > Grid.Width/2 || this.GridX < -Grid.Width/2)
            {
                this.GridX = -this.GridX;
            }

            if (this.GridY > Grid.Height/2 || this.GridY < -Grid.Height/2)
            {
                this.GridY = -this.GridY;
            }

            this.transform.position = Grid.GetWorldPosition(this.GridX, this.GridY);
        }
        
    }
}