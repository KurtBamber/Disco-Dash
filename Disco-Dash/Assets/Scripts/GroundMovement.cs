using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;//how fast the gorund moves towards the player

    private void Update()
    {
        MoveGround();
    }

    private void MoveGround()
    {
        transform.Translate(transform.forward * -1 * moveSpeed * Time.deltaTime);//moves the ground backwards each second
    }
}
