using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class CharacterController : MonoBehaviour
{
    #region Variables
    private Rigidbody2D rb;
    private PlayerInputAction playerInput;
    private PlayerInput playerInputComponent;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 200f;
    [SerializeField] private SpriteRenderer bodySpriteRenderer;

    [Header("Scale Effect")]
    [SerializeField] private float scaleSpeed = 1.0f;
    [SerializeField] private float changeSize = 0.1f;
    private Vector3 currentScale = new Vector3();
    private Vector3 constantScale;
    private float minScale;
    private float maxScale;
    private int scaleDirection = 1;

    private bool isMove = false;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        InitializePlayerInput();
        InitializedScale();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Update()
    {
        if(isMove) UpdateScale();
        else ResetScale();
    }
    #endregion

    #region Initialization Methods
    private void InitializePlayerInput()
    {
        playerInputComponent = GetComponent<PlayerInput>();
        playerInput = new PlayerInputAction();

        playerInput.Enable();
        if (playerInputComponent.actions == null)
        {
            playerInputComponent.actions = playerInput.asset;
        }

        playerInput.Player.Move.performed += Move_performed;
        playerInput.Player.Move.canceled += Move_canceled;
    }

    private void InitializedScale()
    {
        constantScale = bodySpriteRenderer.transform.localScale;
        minScale = constantScale.y - changeSize;
        maxScale = constantScale.y + changeSize;
    }
    #endregion

    #region Input Methods
    private void Move_performed(InputAction.CallbackContext obj)
    {
        rb.velocity = obj.ReadValue<Vector2>() * moveSpeed * Time.fixedDeltaTime;

        if (obj.ReadValue<Vector2>().x > 0)
        {
            bodySpriteRenderer.flipX = false;
        }
        else if (obj.ReadValue<Vector2>().x < 0)
        {
            bodySpriteRenderer.flipX = true;
        }

        isMove = true;
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        rb.velocity = Vector2.zero;
        isMove = false;
    }
    #endregion

    #region Scale Effect Methods
    private void UpdateScale()
    {
        currentScale.y += scaleDirection * scaleSpeed * Time.deltaTime;
        currentScale.y = Mathf.Clamp(currentScale.y, minScale, maxScale);
        bodySpriteRenderer.transform.localScale = new Vector3(constantScale.x, currentScale.y, constantScale.z);

        if (currentScale.y <= minScale || currentScale.y >= maxScale)
        {
            scaleDirection *= -1;
        }
    }

    private void ResetScale()
    {
        currentScale = constantScale;
        bodySpriteRenderer.transform.localScale = new Vector3(constantScale.x, currentScale.y, constantScale.z);
    }
    #endregion
}
