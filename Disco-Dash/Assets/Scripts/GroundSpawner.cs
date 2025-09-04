using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefab;
    [SerializeField, HideInInspector] private int i;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))//checks if the object is the ground
        {
            i = Random.Range(0, groundPrefab.Length);
            Instantiate(groundPrefab[i], new Vector3(0, -0.5f, 30), Quaternion.identity);//if so spawns a new ground object
        }
    }
}
