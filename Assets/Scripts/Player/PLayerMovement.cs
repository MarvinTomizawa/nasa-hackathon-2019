using UnityEngine;

public class PLayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private Rigidbody2D rigidbody;

    private bool canMove = true;

    private Vector2 direction = new Vector3();

    public void LetMove()
    {
        canMove = true;
    }

    public void StopMovement()
    {
        canMove = false;
        direction = Vector2.zero;
    }

    void Update()
    {
        if (canMove)
        {
            direction.x = Input.GetAxis("Horizontal");
            direction.y = Input.GetAxis("Vertical");
        }
    }

    private void FixedUpdate()
    {
        this.rigidbody.MovePosition(new Vector2(transform.position.x, transform.position.y) + direction * speed * Time.deltaTime);
    }
}
