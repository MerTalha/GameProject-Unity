using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
    public float inputX;
    public float inputY;
    public bool isWalking;
    public bool isRunning;
    public bool isIdle;
    public bool isCarrying;
    public ToolEffect toolEffect;
    public bool isUsingToolRight;
    public bool isUsingToolLeft;
    public bool isUsingToolDown;
    public bool isUsingToolUp;
    public bool isLiftingToolRight;
    public bool isLiftingToolLeft;
    public bool isLiftingToolUp;
    public bool isLiftingToolDown;
    public bool isPickingToolRight;
    public bool isPickingToolLeft;
    public bool isPickingToolUp;
    public bool isPickingToolDown;
    public bool isSwingingToolRight;
    public bool isSwingingToolLeft;
    public bool isSwingingToolUp;
    public bool isSwingingToolDown;
    public bool idleUp;
    public bool idleDown;
    public bool idleLeft;
    public bool idleRight;

    public void Update()
    {
        EventHandler.CallMovementEvent(inputX, inputY,isWalking,isRunning,isIdle,isCarrying,toolEffect,isUsingToolRight,
            isUsingToolLeft,isUsingToolUp,isUsingToolDown,isLiftingToolRight,isLiftingToolLeft,isLiftingToolUp,
            isLiftingToolDown, isPickingToolRight,isPickingToolLeft,isPickingToolUp,isPickingToolDown,
            isSwingingToolRight,isSwingingToolLeft, isSwingingToolUp,isSwingingToolDown,idleUp,idleDown,idleRight,
            idleLeft);
    }
}
