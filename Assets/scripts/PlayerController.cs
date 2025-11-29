using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float fspeed = 4;

    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private InputAction move;
    void Awake()
    {
        playerInput = new PlayerInput();
        move = playerInput.Player.Move;
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        playerInput.Enable();
        move.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
        move.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
