

public class DeadState : PlayerState
{
    public DeadState(PlayerController controller)
      : base(controller) { }

    public override void Look() { }

    public override void Attack() { }

    public override void Block() { }

    public override void Dash() { }

    public override bool CanBeDamaged => false;
}
