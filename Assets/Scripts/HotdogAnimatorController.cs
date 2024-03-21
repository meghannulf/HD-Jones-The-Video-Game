using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotdogAnimatorController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement

    private Rigidbody2D rb;
    private Animator animator;
    private HotdogState currentState;

    // Bool parameters in the Animator Controller
    private bool RunningUp;
    private bool RunningDown;
    private bool RunningLeft;
    private bool RunningRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentState = new IdleState(this);
    }

    void Update()
    {
        currentState.HandleInput();
    }

    void FixedUpdate()
    {
        currentState.Update();
        UpdateAnimatorParams();
    }

    public void SetState(HotdogState state)
    {
        currentState = state;
        currentState.EnterState();
    }

    public Rigidbody2D GetRigidbody()
    {
        return rb;
    }

    public Animator GetAnimator()
    {
        return animator;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    // Update bool parameters in the Animator Controller
    private void UpdateAnimatorParams()
    {
        animator.SetBool("RunningUp", RunningUp);
        animator.SetBool("RunningDown", RunningDown);
        animator.SetBool("RunningLeft", RunningLeft);
        animator.SetBool("RunningRight", RunningRight);
    }

    // Methods to set bool parameters
    public void SetRunningUp(bool value)
    {
        RunningUp = value;
    }

    public void SetRunningDown(bool value)
    {
        RunningDown = value;
    }

    public void SetRunningLeft(bool value)
    {
        RunningLeft = value;
    }

    public void SetRunningRight(bool value)
    {
        RunningRight = value;
    }
}

public abstract class HotdogState
{
    protected HotdogAnimatorController controller;

    public HotdogState(HotdogAnimatorController controller)
    {
        this.controller = controller;
    }

    public virtual void EnterState() { }
    public virtual void HandleInput() { }
    public virtual void Update() { }
}

public class IdleState : HotdogState
{
    public IdleState(HotdogAnimatorController controller) : base(controller) { }

    public override void EnterState()
    {
        // Set bool parameter for idle animation
        controller.SetRunningUp(false);
        controller.SetRunningDown(false);
        controller.SetRunningLeft(false);
        controller.SetRunningRight(false);
    }

    public override void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (horizontalInput > 0)
                controller.SetState(new MovingRightState(controller));
            else if (horizontalInput < 0)
                controller.SetState(new MovingLeftState(controller));
            else if (verticalInput > 0)
                controller.SetState(new MovingUpState(controller));
            else if (verticalInput < 0)
                controller.SetState(new MovingDownState(controller));
        }
    }
}

public class MovingRightState : HotdogState
{
    public MovingRightState(HotdogAnimatorController controller) : base(controller) { }

    public override void EnterState()
    {
        // Set bool parameter for running right animation
        controller.SetRunningRight(true);
        controller.SetRunningUp(false);
        controller.SetRunningDown(false);
        controller.SetRunningLeft(false);
    }

    public override void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput == 0)
            controller.SetState(new IdleState(controller));
    }

    public override void Update()
    {
        controller.GetRigidbody().velocity = Vector2.right * controller.GetMoveSpeed();
    }
}

// Similarly implement MovingLeftState, MovingUpState, and MovingDownState

public class MovingLeftState : HotdogState
{
    public MovingLeftState(HotdogAnimatorController controller) : base(controller) { }

    public override void EnterState()
    {
        // Set bool parameter for running left animation
        controller.SetRunningRight(false);
        controller.SetRunningUp(false);
        controller.SetRunningDown(false);
        controller.SetRunningLeft(true);
    }

    public override void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput == 0)
            controller.SetState(new IdleState(controller));
    }

    public override void Update()
    {
        controller.GetRigidbody().velocity = Vector2.left * controller.GetMoveSpeed();
    }
}

public class MovingUpState : HotdogState
{
    public MovingUpState(HotdogAnimatorController controller) : base(controller) { }

    public override void EnterState()
    {
        // Set bool parameter for running up animation
        controller.SetRunningRight(false);
        controller.SetRunningUp(true);
        controller.SetRunningDown(false);
        controller.SetRunningLeft(false);
    }

    public override void HandleInput()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput == 0)
            controller.SetState(new IdleState(controller));
    }

    public override void Update()
    {
        controller.GetRigidbody().velocity = Vector2.up * controller.GetMoveSpeed();
    }
}

public class MovingDownState : HotdogState
{
    public MovingDownState(HotdogAnimatorController controller) : base(controller) { }

    public override void EnterState()
    {
        // Set bool parameter for running down animation
        controller.SetRunningRight(false);
        controller.SetRunningUp(false);
        controller.SetRunningDown(true);
        controller.SetRunningLeft(false);
    }

    public override void HandleInput()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput == 0)
            controller.SetState(new IdleState(controller));
    }

    public override void Update()
    {
        controller.GetRigidbody().velocity = Vector2.down * controller.GetMoveSpeed();
    }
}