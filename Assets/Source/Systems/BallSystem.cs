using UnityEngine;

public class BallSystem : EgoSystem<
    EgoConstraint<Transform, Rigidbody, Ball>
    >
{
    public override void Start()
    {
        EgoEvents<ShootEvent>.AddHandler(Handle);
    }

    public override void Update()
    {

    }

    void Handle(ShootEvent e)
    {
        constraint.ForEachGameObject((egoComponent, transform, rigidbody, ball) =>
        {
            Debug.Log("Shoot!");
            rigidbody.AddForce(new Vector3(0, 1, 0), ForceMode.Impulse);
        });
    }

}
