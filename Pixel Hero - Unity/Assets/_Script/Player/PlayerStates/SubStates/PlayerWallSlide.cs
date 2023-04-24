public class PlayerWallSlide : PlayerTouchingWallState
{
    public PlayerWallSlide(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            Movement?.SetVelocityY(-playerData.wallSlideVelocity);
        }
    }
}
