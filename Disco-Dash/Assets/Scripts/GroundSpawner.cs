using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ground;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))//checks if the object is the ground
        {
            Instantiate(ground, new Vector3(0, -0.5f, 40), Quaternion.identity);//if so spawns a new ground object
        }
    }
}
