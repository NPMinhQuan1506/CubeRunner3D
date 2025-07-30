using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float laneDistance = 2f;
    private int currentLane = 0;

    void Update()
    {
        // Move the player forward along the Z axis at constant speed
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Handle input: move left if not already at the leftmost lane
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > -1)
            currentLane--;

        // Handle input: move right if not already at the rightmost lane
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 1)
            currentLane++;

        // Calculate target X position based on current lane (-1, 0, or 1)
        Vector3 targetPos = new Vector3(currentLane * laneDistance, transform.position.y, transform.position.z);

        // Smoothly interpolate the player's X position toward the target
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 10);

    }
}
