using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float fspeed = 4;

    private PlayerInput input = null;
    private InputAction moveAction = null;
    private InputAction freezeAction = null;

    private Rigidbody2D rb = null;

    // Delta time tracking
    private float localDelta = 0.0f;
    // Can be used to log only once per second
    private bool deltaWait = false;
    // local int for delta time tracking
    private int localInt = 0;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = new PlayerInput();
        moveAction = input.Player.Move;
        freezeAction = input.Player.FreezeAbility;
        freezeAction.performed += OnSpecicialButtonPressed;
    }

    private void OnEnable()
    {
        input.Enable();
        moveAction.Enable();
        freezeAction.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
        moveAction.Disable();
        freezeAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Move Action
        // moveInput.x = a/d or left/right
        // moveInput.y = w/s or up/down
        // moveInput = left jobstick / d-pad
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        //Vector2 fwd = rb.transform.forward;
        //fwd.Normalize();

        Vector2 moveVelocity = moveInput * fspeed;

        rb.linearVelocity = moveVelocity;
        //rb.angularVelocity = 0.0f;

        localDelta += Time.deltaTime;
        // Logs every second
        if ((int)localDelta > localInt)
        {
            ++localInt;
            Debug.Log($"Delta(int): {(int)localDelta} | DeltaTime: {Time.deltaTime} | Player moveVelocity: {moveVelocity}");
            deltaWait = true;
        }


        if (deltaWait)
        {

        }

        // old input system; unity will complain
        //if(UnityEngine.Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Space Key Pressed");
        //}

        // Must be at the end of this Update
        if (deltaWait) { deltaWait = false; }
    }

    void OnSpecicialButtonPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Special Button Pressed");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 v2;
        v2.y = 10;
        v2.x = 10;

        Debug.Log("Player OnCollisionEnter2D with " + collision.gameObject.name);
        // bounce away from enemy
        rb.linearVelocity = (-rb.linearVelocity * 20) - v2;
    }


}
