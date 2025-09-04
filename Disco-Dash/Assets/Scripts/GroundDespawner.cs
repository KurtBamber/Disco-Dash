using UnityEngine;

public class GroundDespawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(other.gameObject);
        }
    }
}
