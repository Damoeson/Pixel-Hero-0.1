using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected SO_WeaponsData weaponsData;

    protected Animator Animator;

    protected PlayerAttackState state;

    protected Core core;

    protected int attackCounter;

    protected virtual void Awake()
    {
        Animator = transform.Find("Weapon").GetComponent<Animator>();

        gameObject.SetActive(false);
    }

    public virtual void EnterWeapon()
    {
        gameObject.SetActive(true);

        if (attackCounter >= weaponsData.amountOfAttacks)
        {
            attackCounter = 0;
        }

        Animator.SetBool("attack", true);

        Animator.SetInteger("attackCounter", attackCounter);

        SoundManager.instance.PlaySound(weaponsData.WeaponSound);
    }

    public virtual void ExitWeapon()
    {
        Animator.SetBool("attack", false);

        attackCounter++;

        gameObject.SetActive(false);
    }

    #region Animation Triggers

    public virtual void AnimationFinishTrigger()
    {
        state.AnimationFinishTrigger();
    }

    public virtual void AnimationStartMovementTrigger()
    {
        state.SetPlayerVelocity(weaponsData.movementSpeed[attackCounter]);
    }

    public virtual void AnimationStopMovementTrigger()
    {
        state.SetPlayerVelocity(0f);
    }

    public virtual void AnimationTurnOffFlipTrigger()
    {
        state.SetFlipCheck(false);
    }

    public virtual void AnimationTurnOnFlipTrigger()
    {
        state.SetFlipCheck(true);
    }

    public virtual void AnimationActionTrigger()
    {

    }

    #endregion

    public void InitializeWeapon(PlayerAttackState state, Core core)
    {
        this.state = state;
        this.core = core;
    }
}
