using UnityEngine;

public class SpeedControl : MonoBehaviour
{
    public static readonly float minSpeed = 5f, maxSpeed = 260f;
    public static float speed;

    private float acceleration = 0f;

    void Start()
    {
        speed = minSpeed;
    }

    void Update()
    {
        Accelerate();
    }

    private void Accelerate()
    {
        speed = Mathf.Clamp(speed + acceleration * Time.deltaTime, minSpeed, maxSpeed);
    }

    // Set acceleration value from button Unity Events in Editor
    public void SetAcceleration(float value)
    {
        acceleration = value;
    }
}
