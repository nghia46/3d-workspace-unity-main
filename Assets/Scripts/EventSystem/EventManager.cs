using System;
using UnityEngine;

namespace EventSystem
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance;
        public event Action<int> CollectableEvent;
        public event Action FireEvent; 

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void StartCollectableCollectEvent(int id)
        {
            if (CollectableEvent != null)
            {
                CollectableEvent.Invoke(id);
            }
            else
            {
                Debug.LogWarning($"No event in CollectableEvent");
            }
        }

        public void StartFireEvent()
        {
            FireEvent?.Invoke();
        }
    }
}
