using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawDashDirectionInput { get; private set; }
    public Vector2Int DashDirectionInput { get; private set; }

    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool DashInput { get; private set; }
    public bool DashInputStop { get; private set; }
    public bool InteractInput { get; private set; }
    public bool InteractInputStop { get; private set; }
    public bool InventoryInput { get; private set; }
    public bool InventoryInputStop { get; private set; }

    public bool[] AttackInputs { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float jumpInputStartTime;
    private float dashInputStartTime;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;

        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[count];
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.primary] = true;
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }

    public void OnSecondaryAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        NormInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput = true;
            DashInputStop = false;
            dashInputStartTime = Time.time;
        }

        else if (context.canceled)
        {
            DashInputStop = true;
        }
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InteractInput = true;
            InteractInputStop = false;
        }

        else if (context.canceled)
        {
            InteractInputStop = true;
        }
    }

    public void OnInventoryInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InventoryInput = true;
            InventoryInputStop = false;
        }

        else if (context.canceled)
        {
            InventoryInputStop = true;
        }
    }

    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
        RawDashDirectionInput = context.ReadValue<Vector2>();

        if (playerInput.currentControlScheme == "Keyboard")
        {
            RawDashDirectionInput = cam.ScreenToWorldPoint((Vector3)RawDashDirectionInput) - transform.position;
        }

        DashDirectionInput = Vector2Int.RoundToInt(RawDashDirectionInput.normalized);
    }

    public void UseJumpInput() => JumpInput = false;

    public void UseDashInput() => DashInput = false;

    public void UseInteractInput() => InteractInput = false;

    public void UseInventoryInput() => InventoryInput = false;

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    private void CheckDashInputHoldTime()
    {
        if (Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }
}

public enum CombatInputs
{
    primary,
    secondary
}
