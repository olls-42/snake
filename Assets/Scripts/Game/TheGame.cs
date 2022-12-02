using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class TheGame : MonoBehaviour
    {
        private float _updateCount = 0;
        private float _fixedUpdateCount = 0;
        private float _updateUpdateCountPerSecond;
        private float _updateFixedUpdateCountPerSecond;
        
        private const float Speed = 0.1f;

        private GameObject _snakeHead;
        private Snake _snakeClass;
        private GameObject _food;
        private Food _foodClass;

        private void Awake()
        {
            // Uncommenting this will cause framerate to drop to 10 frames per second.
            // This will mean that FixedUpdate is called more often than Update.
            //Application.targetFrameRate = 10;
            StartCoroutine(this.Loop());
            _snakeHead = GameObject.Find("Game/Snake");
            _snakeClass = _snakeHead.GetComponent<Snake>();
            _food = GameObject.Find("Game/Food");
            _foodClass = _food.GetComponent<Food>();
        }

        // Increase the number of calls to Update.
        void Update()
        {
            _updateCount += 1;
        }

        // Increase the number of calls to FixedUpdate.
        void FixedUpdate()
        {
            _fixedUpdateCount += 1;
            
            this.FoodCollision();
        }

        // Show the number of calls to both messages.
        void OnGUI()
        {
            GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("label"));
            fontSize.fontSize = 24;
            GUI.Label(new Rect(5, 5, 200, 50), "Update: " + _updateUpdateCountPerSecond.ToString(), fontSize);
            GUI.Label(new Rect(5, 10, 200, 50), "FixedUpdate: " + _updateFixedUpdateCountPerSecond.ToString(), fontSize);
        }

        // Update both CountsPerSecond values every second.
        IEnumerator Loop()
        {
            while (true)
            {
                yield return new WaitForSeconds(Speed);
                _updateUpdateCountPerSecond = _updateCount;
                _updateFixedUpdateCountPerSecond = _fixedUpdateCount;

                _updateCount = 0;
                _fixedUpdateCount = 0;
                
                _snakeClass.CustomMoveUpdate();
            }
        }
        
        //Detect collisions between the GameObjects with Colliders attached
        private void FoodCollision()
        {
            if (_snakeClass.GridX == _foodClass.GridX && _snakeClass.GridY == _foodClass.GridY)
            {
                _snakeClass.SnakeLenght += 1;
                _foodClass.RandomPosition();
            }
        }
    }
}
