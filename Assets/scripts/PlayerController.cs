using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float fspeed = 4;

    private PlayerInput input = null;
    private InputAction moveAction = null;

    private Rigidbody2D rb = null;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new PlayerInput();
        moveAction = input.Player.Move;
    }

    private void OnEnable()
    {
        input.Enable();
        moveAction.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
        moveAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Move Action
        // moveInput.x = a/d or left/right
        // moveInput.y = w/s or up/down
        // moveInput = left jobstick / d-pad
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        Debug.Log("Player moveInput : " + moveInput);

        //Vector2 fwd = rb.transform.forward;

        //fwd.Normalize();

        Vector2 moveVelocity = moveInput * fspeed;

        Debug.Log("Player moveVelocity : " + moveVelocity);

        rb.linearVelocity = moveVelocity;
        //rb.angularVelocity = 0.0f;


    }
}
