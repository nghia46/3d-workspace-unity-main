using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    [CreateAssetMenu(menuName = "Input/Input Reader")]
    public class InputReader : ScriptableObject, GameInput.IGameplayActions, GameInput.IUIActions
    {
        private GameInput _gameInput;
        private void OnEnable()
        {
            if (_gameInput == null)
            {
                _gameInput = new GameInput();
                _gameInput.Gameplay.SetCallbacks(this);
                _gameInput.UI.SetCallbacks(this);

                SetGameplay();
            }
        }
        private void OnDisable()
        {
            _gameInput?.Disable();
        }
        private void SetGameplay()
        {
            _gameInput.Gameplay.Enable();
            _gameInput.UI.Disable();
        }

        public void SetUI()
        {
            _gameInput.Gameplay.Disable();
            _gameInput.UI.Enable();
        }

        public event Action<Vector2> MoveEvent;
        public event Action<Vector2> MouseEvent;
        public event Action FireEvent;
        public event Action FireCancelEvent;
        public event Action JumpEvent;
        public event Action JumpCancelEvent;

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    JumpEvent?.Invoke();
                    break;
                case InputActionPhase.Canceled:
                    JumpCancelEvent?.Invoke();
                    break;
            }
        }
            public void OnFire(InputAction.CallbackContext context)
            {
                switch (context.phase)
                {
                    case InputActionPhase.Performed:
                        FireEvent?.Invoke();
                        break;
                    case InputActionPhase.Canceled:
                        FireCancelEvent?.Invoke();
                        break;
                }
            }
        public void OnCameraMove(InputAction.CallbackContext context)
        {
            var device = context.control.device;
            if(device is Mouse) 
            {
                MouseEvent?.Invoke(context.ReadValue<Vector2>());
            }
            else
            {
                MouseEvent?.Invoke(context.ReadValue<Vector2>()*15);
            }
        }
        public void OnNewaction(InputAction.CallbackContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}