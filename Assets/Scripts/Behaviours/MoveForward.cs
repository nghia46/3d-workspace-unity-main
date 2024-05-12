using UnityEngine;
public class MoveForward : MonoBehaviour
{
    public float forceSize = 5f; // Adjust the speed as needed
    public Rigidbody rb;
    private void Awake()
    {
        var localForward = transform.TransformDirection(Vector3.forward);
        GetComponent<Rigidbody>().AddForce(localForward * forceSize, ForceMode.Impulse);
    }
}
