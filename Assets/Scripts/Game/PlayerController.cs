using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
namespace Game
{
    public class PlayerController : MonoBehaviour, SnakeInputActions.IPlayerActions
    {
        private Snake _snake;
        private SnakeInputActions _snakeInputActions;
        private InputAction _inputAction;
    
        private void Awake()
        {
            _snakeInputActions = new SnakeInputActions();
            _snake = GameObject.Find("Game/Snake").GetComponent<Snake>();
        }

        private void OnEnable()
        {
            _inputAction = _snakeInputActions.Player.Move;
            _inputAction.Enable();
        
            _snakeInputActions.Player.Move.performed += this.MoveOnPerformed;
        }
        private void MoveOnPerformed(InputAction.CallbackContext context)
        {
            Debug.Log($"FireMoveOnPerformed! {context.action.activeControl.name}");

            switch (context.action.activeControl.name)
            {
                case "leftArrow":
                    _snake.MoveDirection = MoveDirection.Left;
                    break;
                case "rightArrow":
                    _snake.MoveDirection = MoveDirection.Right;
                    break;
                case "upArrow":
                    _snake.MoveDirection = MoveDirection.Up;
                    break;
                case "downArrow":
                    _snake.MoveDirection = MoveDirection.Down;
                    break;
                default:
                    _snake.MoveDirection = MoveDirection.None;
                    break;
            }
        }

        private void OnDisable()
        {
            _inputAction.Disable();
        }

        public void Update()
        {
            /*
            var keyboard = Keyboard.current;
            if (keyboard == null)
                return; // No gamepad connected.

            if (keyboard.rightArrowKey.wasPressedThisFrame)
            {
                Debug.Log("right arrow");
                // 'Use' code here
            }
            */
       
            //var offset = _inputAction.name;
            //ReadValue<Vector2>();
            //Debug.Log("Movement values" + offset);
            //this.transform.position += new Vector3(offset.x / 100, offset.y / 100, 0);
        }

        public void Hello()
        {
            //
            Debug.Log("Fire!");
        }
    
        public void OnMove(InputAction.CallbackContext context)
        {
            Debug.Log(context.action.name);
        }
    
        public void OnLook(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
    
        public void OnFire(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}