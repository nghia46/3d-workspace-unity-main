using System;
using EventSystem;
using Input;
using UnityEngine;

namespace Behaviours
{
    public class GunController : MonoBehaviour
    {
        [SerializeField] private InputReader input;
        [SerializeField] private Transform gunHolder;
        [SerializeField] private GameObject bullet;
        private bool _isShooting;
        private void Awake()
        {
            input.FireEvent += HandleFire;
            input.FireCancelEvent += HandleFireCancel;
        }

        private void HandleFireCancel()
        {
            _isShooting = false;
        }

        private void HandleFire()
        {
            if (!_isShooting)
            {
                _isShooting = true;
                Shoot();
            }
        }
        void Shoot()
        {
            EventManager.Instance.StartFireEvent();
            Instantiate(bullet, gunHolder.position, gunHolder.rotation,GameObject.FindWithTag($"GarbagePool").transform);
        }
    }
}
