using UnityEngine;

//SingletonMonobehaviours'tan alýp kullanýcý kontrolü yapýyor
public class Player : SingletonMonobehaviour<Player>
{
    //Movement Parameters
    private float xInput;
    private float yInput;
    private bool isCarrying = false;
    private bool isIdle;
    private bool isLiftingToolDown;
    private bool isLiftingToolUp;
    private bool isLiftingToolRight;
    private bool isLiftingToolLeft;
    private bool isRunning;
    private bool isUsingToolDown;
    private bool isUsingToolUp;
    private bool isUsingToolRight;
    private bool isUsingToolLeft;
    private bool isSwingingToolDown;
    private bool isSwingingToolUp;
    private bool isSwingingToolRight;
    private bool isSwingingToolLeft;
    private bool isWalking;
    private bool isPickingUp;
    private bool isPickingRight;
    private bool isPickingLeft;
    private bool isPickingDown;
    private ToolEffect toolEffect = ToolEffect.none;

    private Rigidbody2D rigidbody2D;

    private Direction playerDirection;

    private float movementSpeed;

    private bool _playerInputIsDýsabled = false;

    public bool PlayerInputIsDisabled { get => _playerInputIsDýsabled; set => _playerInputIsDýsabled=value; }

    protected override void Awake()
    {
        base.Awake();

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        #region Player Input

        ResetAnimationTriggers();

        PlayerMovementInput();

        PlayerWalkInput();

        //Send event to any listeners for player movement input
        EventHandler.CallMovementEvent(xInput, yInput, isWalking, isRunning, isIdle, isCarrying, toolEffect,
            isUsingToolRight,isUsingToolLeft, isUsingToolUp, isUsingToolDown, isLiftingToolRight, isLiftingToolLeft,
            isLiftingToolUp, isLiftingToolDown, isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
            isSwingingToolRight, isSwingingToolLeft, isSwingingToolUp, isSwingingToolDown, 
            false, false, false, false);

        #endregion
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 move = new Vector2(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime);

        rigidbody2D.MovePosition(rigidbody2D.position +  move);
    }

    private void ResetAnimationTriggers()
    {
        isLiftingToolDown = false;
        isLiftingToolUp = false;
        isLiftingToolRight = false;
        isLiftingToolLeft = false;
        isUsingToolDown = false;
        isUsingToolUp = false;
        isUsingToolRight = false;
        isUsingToolLeft = false;
        isSwingingToolDown = false;
        isSwingingToolUp = false;
        isSwingingToolRight = false;
        isSwingingToolLeft = false;
        isPickingUp = false;
        isPickingRight = false;
        isPickingLeft = false;
        isPickingDown = false;
        toolEffect = ToolEffect.none;
     }

    private void PlayerMovementInput()
    {
        yInput = Input.GetAxisRaw("Vertical");
        xInput = Input.GetAxisRaw("Horizontal");

        if(yInput != 0 &&  xInput != 0)
        {
            xInput = xInput * 0.71f;
            yInput = yInput * 0.71f;
        }

        if(xInput != 0 ||  yInput != 0)
        {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;

            //Capture player direction for save game
            if(xInput < 0)
            {
                playerDirection = Direction.left;
            }
            else if(xInput > 0)
            {
                playerDirection = Direction.right;
            }
            else if(yInput < 0)
            {
                playerDirection = Direction.down;
            }
            else
            {
                playerDirection = Direction.up;
            }
        }
        else if(xInput == 0 && yInput == 0)
        {
            isWalking = false;
            isRunning = false;
            isIdle = true;
        }
    }

    private void PlayerWalkInput()
    {
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isRunning = false;
            isWalking = true;
            isIdle = false;
            movementSpeed = Settings.walkingSpeed;
        }
        else
        {
            isRunning = true;
            isWalking = false;
            isIdle = false;
            movementSpeed = Settings.runningSpeed;
        }
    }
}
