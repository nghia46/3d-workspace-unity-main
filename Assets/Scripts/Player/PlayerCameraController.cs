using Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerCameraController : MonoBehaviour
    {
        [SerializeField] private InputReader input;
        [SerializeField] [Range(0.1f, 20)] private float sensitivity = 2f;
        private Vector2 _rotation;
        private Vector2 _mouseDir;
        private Transform _playerOrientation;

        private void Awake()
        {
            _playerOrientation = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Start()
        {
            input.MouseEvent += HandleMouse;
        }

        private void HandleMouse(Vector2 obj)
        {
            _mouseDir = obj;
        }

        private void Update()
        {
            var mousePos = _mouseDir * (Time.deltaTime * sensitivity);
            _rotation.y += mousePos.x;
            _rotation.x -= mousePos.y;
            _rotation.x = Mathf.Clamp(_rotation.x, -90, 90);
        
            transform.rotation = Quaternion.Euler(_rotation.x, _rotation.y, 0);
            _playerOrientation.rotation = Quaternion.Euler(0, _rotation.y, 0);
        }
    }
}