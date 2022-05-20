using UnityEngine;

public class FlightControl : MonoBehaviour
{
    public Joystick joystick;

    private float horizontalInput;
    private float verticalInput;

    [Header("Parameters")]
    [SerializeField] float maxRotation = 0.4f;
    [SerializeField] float maxRoll = 0.2f;
    [SerializeField] float rotationSmoothness;

    private float takeOffThreshold = 20f;
    private bool canTakeOff = false;

    private Rigidbody jet;
    
    void Awake()
    {
        jet = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        JetCrash.OnJetCrash += DisableFlight;
    }

    void OnDisable()
    {
        JetCrash.OnJetCrash -= DisableFlight;
    }

    void Update()
    {
        horizontalInput = joystick.Horizontal;
        verticalInput   = joystick.Vertical;        
    }

    void FixedUpdate()
    {
        JetMovement();
        JetRotation();
    }

    private void JetMovement()
    {
        jet.velocity = transform.forward * SpeedControl.speed;
    }

    private void JetRotation()
    {
        float horizontalRotation = horizontalInput  * maxRotation;
        float verticalRotation   = verticalInput    * maxRotation;
        float rollRotation       = -horizontalInput * maxRoll;

        // If jet cannot take off but trying to, then display a message.
        if (!CanTakeOff() && verticalRotation != 0)
        {
            verticalRotation = 0;
            rollRotation = 0;

            Debug.Log("You need speed to take off");
        }

        Quaternion desiredRot = new(verticalRotation, horizontalRotation, rollRotation, jet.rotation.w);

        jet.rotation = Quaternion.Lerp(jet.rotation, desiredRot, Time.deltaTime * rotationSmoothness);
    }

    private bool CanTakeOff()
    {
        // Once the threshold speed is achieved, canTakeOff becomes true and stays so for the rest
        if (SpeedControl.speed > takeOffThreshold)
        {
            canTakeOff = true;
        }

        return canTakeOff;
    }

    private void DisableFlight()
    {
        enabled = false;
        jet.useGravity = true;
    }
}
