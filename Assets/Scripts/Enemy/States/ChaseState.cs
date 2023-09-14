public class ChaseState : State
{
    private float _moveSpeed = 3.2f;

    private void FixedUpdate()
    {
        ReachTarget();
    }

    private void ReachTarget()
    {
        Movement.MoveTo(Target.transform, _moveSpeed);
    }
}
