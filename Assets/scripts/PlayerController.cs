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

    private Rigidbody2D rb = null;

    // Delta time tracking
    private float localDelta = 0.0f;
    // wait timer for delta time tracking
    private int deltaWait = 1;
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

        localDelta += Time.deltaTime;
        //Debug.Log("Delta : " + localDelta + ", " + (int)localDelta);

        //if ((int)localDelta % deltaWait == 0)
        //{ Debug.Log("DeltaTime : " + Time.deltaTime); }

        //if ((int)localDelta % deltaWait == 0)
        //{ Debug.Log("Player moveInput : " + moveInput); }

        //Vector2 fwd = rb.transform.forward;

        //fwd.Normalize();

        Vector2 moveVelocity = moveInput * fspeed;

        //if ((int)localDelta % deltaWait == 0)
        //{ Debug.Log("Player moveVelocity : " + moveVelocity); }

        rb.linearVelocity = moveVelocity;
        //rb.angularVelocity = 0.0f;

        OnKeyDownEvent(new KeyDownEvent());
    }

    void OnKeyDownEvent(KeyDownEvent e)
    {
        if (e.keyCode != KeyCode.None)
        {
            Debug.Log("Key Down: " + e.keyCode);
        }
        
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
