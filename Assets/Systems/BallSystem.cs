using UnityEngine;

public class BallSystem : EgoSystem<
    EgoConstraint<Transform, Rigidbody, Ball>
    >
{
    public override void Start()
    {

    }

    public override void Update()
    {
        constraint.ForEachGameObject( ( egoComponent, transform, rigidbody, ball ) =>
        {
            transform.Translate(ball.velocity * Time.deltaTime);
        });
    }
}
