using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A-D or Left-Right
        float v = Input.GetAxis("Vertical");   // W-S or Up-Down

        Vector3 move = new Vector3(h, 0, v) * moveSpeed;
        Vector3 newVel = new Vector3(move.x, rb.velocity.y, move.z);
        rb.velocity = newVel;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
