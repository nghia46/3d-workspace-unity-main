using EventSystem;
using UnityEngine;
public class CollectableTrigger : MonoBehaviour
{
    [SerializeField] private int triggerId;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        EventManager.Instance.StartCollectableCollectEvent(triggerId);
        Destroy(this.gameObject);
    }
}
