using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    #region Variables
    private Rigidbody2D rb;
    private PlayerInputAction playerInput;
    private Vector2 moveInput;
    
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 200f;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    #endregion

    #region Input Methods
    private void OnEnable()
    {
        if (playerInput == null)
        {
            playerInput = new PlayerInputAction();
            playerInput.Player.Move.performed += Move_performed;
            playerInput.Player.Move.canceled += Move_canceled;
        }

        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    
    private void OnMove(InputValue value)
    {
        rb.velocity = value.Get<Vector2>() * moveSpeed * Time.fixedDeltaTime;
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        moveInput = obj.ReadValue<Vector2>();
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        moveInput = Vector2.zero;
    }
    #endregion
}
