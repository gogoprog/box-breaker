using UnityEngine;

public class PadLockSystem : EgoSystem<
    EgoConstraint<Transform, Rigidbody, PadLock>
    >
{
    private float halfDistance;

    public override void Start()
    {
    }

    public override void Update()
    {
        constraint.ForEachGameObject((egoComponent, transform, rigidbody, padLock) =>
        {
            var x = transform.position.x;
            var y = transform.position.y;


            if(Input.GetKey(KeyCode.Space))
            {
                EgoEvents<ShootEvent>.AddEvent(new ShootEvent());
            }

            var ball = GameObject.Find("Ball");

            ball.transform.position = new Vector3(x, y + 0.5f, 0.0f);
        
        });
    }
}
