#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private InputActionReference movementInput;
    [SerializeField] private float interpolationTime = .4f;
    private Vector3 targetPosition;

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -10f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.4f;
    public LayerMask groundMask;
    private Vector3 velocity;
    private bool isGrounded;

    private InputAction movement;
    private InputAction jump;

    private void Start() {
        targetPosition = transform.position;

        movement = new InputAction("PlayerMovement", binding: "<Gamepad>/leftStick");
        movement.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/s")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/a")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/d")
            .With("Right", "<Keyboard>/rightArrow");

        jump = new InputAction("PlayerJump", binding: "<Gamepad>/a");
        jump.AddBinding("<Keyboard>/space");

        movement.Enable();
        jump.Enable();
    }

    private void OnEnable() {
        movementInput.action.Enable();
    }

    private void Update() {
        float x;
        float z;
        bool jumpPressed = false;
        Vector2 delta = movementInput.action.ReadValue<Vector2>();
        x = delta.x;
        z = delta.y;
        Debug.Log(delta);
        jumpPressed = Mathf.Approximately(jump.ReadValue<float>(), 1);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        //if(isGrounded && velocity.y < 0) {
        //    velocity.y = -2f;
        //}

        targetPosition = transform.right * x + transform.forward * z;
        //transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * interpolationTime);

        controller.Move(targetPosition * speed * Time.deltaTime);

        //if(jumpPressed && isGrounded) {
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //}

        //velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);
    }
}
