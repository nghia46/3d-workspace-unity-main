using UnityEngine;

namespace Behaviours
{
    public class GunFollowPlayer : MonoBehaviour
    {
        private Transform _playerGunPos;
        private GameObject _gameObject;
        private Transform _cameraTransform;
        private void Awake()
        {
            _gameObject = GameObject.Find("GunPos");
            _cameraTransform = GameObject.FindWithTag("MainCamera").transform;
        }
        void Update()
        {
            _playerGunPos = _gameObject.transform;
            var transform1 = this.transform;
            transform1.position = _playerGunPos.position;
            transform1.rotation = _cameraTransform.rotation;
        }
    }
}
