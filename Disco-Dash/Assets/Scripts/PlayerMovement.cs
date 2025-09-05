using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, HideInInspector] private Touch touch;
    [SerializeField, HideInInspector] private Vector2 touchStartPos, touchEndPos;
    [SerializeField, HideInInspector] private bool isDragging = false;
    [SerializeField, HideInInspector] private bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE//code for testing without mobile
        if (Input.GetMouseButtonDown(0))//when the lmb is first pressed
        {
            touchStartPos = Input.mousePosition;//sets the start position of the "touch" to the mouses pos
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)//if is dragging is true and the lmb is released
        {
            touchEndPos = Input.mousePosition;//sets the end position of the "touch" to the mouses pos
            Move();
            isDragging = false;
        }
#else
        if (Input.touchCount > 0)//checks if there is a touch
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)//checks if the touch has just started
            {
                touchStartPos = touch.position;//sets the start psoition to where is currently being touched
            }
        }
        else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)//checks if the touch has moved or been dragged
        {
            touchEndPos = touch.position;
            Move();
        }
#endif
    }

    private void Move()
    {
        float x = touchEndPos.x - touchStartPos.x;
        float y = touchEndPos.y - touchStartPos.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))//checks if the difference between the start and end is bigger on the x or y coordinate
        {
            if (x > 0)
            {
                if (transform.position.x < 3)//ensures its not more than the size of the lane
                {
                    transform.position = Vector3.MoveTowards(transform.position, Vector3.right * 3, 3);//moves the player into the next lane
                }
            }
            else
            {
                if (transform.position.x > -3)
                {
                    transform.position = Vector3.MoveTowards(transform.position, -Vector3.right * 3, 3);
                }
            }
        }
        else//if y is greater than x
        {
            if (y > 0 && isGrounded)//checks that the player is on the ground
            {
                transform.position += Vector3.up;
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
