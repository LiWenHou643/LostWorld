using UnityEngine;

public class PlayerMoment : MonoBehaviour
{
    public float speed = 5f;
    public int facingDirection = 1; // 1: right, -1: left
    public Rigidbody2D rb;
    public Animator animator;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0)
        {
            Flip();
        }

        animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
        animator.SetFloat("Vertical", Mathf.Abs(vertical));

        rb.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void Flip()
    {
        facingDirection *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
