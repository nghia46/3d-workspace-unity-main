using UnityEngine;

namespace Player
{
    public class FollowPlayer : MonoBehaviour
    {
        private Transform _playerCameraPos;
        private GameObject _gameObject;

        private void Awake()
        {
            _gameObject = GameObject.FindWithTag("PlayerCamera");
        }

        void Update()
        {
            _playerCameraPos = _gameObject.transform;
            this.transform.position = _playerCameraPos.position;
        }
    }
}