using UnityEngine;

public class BallSystem : EgoSystem<
    EgoConstraint<Transform, Rigidbody, Ball>
    >
{
    public override void Start()
    {
        EgoEvents<CollisionEnterEvent>.AddHandler(Handle);
        EgoEvents<ShootEvent>.AddHandler(Handle);
    }

    public override void Update()
    {

    }

    void Handle(CollisionEnterEvent e)
    {
        constraint.ForEachGameObject( ( egoComponent, transform, rigidbody, ball ) =>
        {
            Transform padTransform = null;

            if(e.egoComponent1.HasComponents<Pad>())
            {
                padTransform = e.egoComponent1.transform;
            }
            else if(e.egoComponent2.HasComponents<Pad>())
            {
                padTransform = e.egoComponent2.transform;
            }

            if(padTransform != null)
            {
                Debug.Log("Yep");
                float d = transform.position.x - padTransform.position.x;
                rigidbody.velocity = new Vector3(d, rigidbody.velocity.y + e.collision.contacts[0].normal.y * 2, 0);
            }
            else
            {
                rigidbody.velocity = rigidbody.velocity + e.collision.contacts[0].normal * 2;
            }
        });

        if(e.egoComponent1.HasComponents<Box>() && e.egoComponent2.HasComponents<Ball>())
        {
            DestroyBox( e.egoComponent1 );
        }
        else if(e.egoComponent1.HasComponents<Ball>() && e.egoComponent2.HasComponents<Box>())
        {
            DestroyBox( e.egoComponent2 );
        }
    }

    void Handle(ShootEvent e)
    {
        constraint.ForEachGameObject( ( egoComponent, transform, rigidbody, ball ) =>
        {
            Debug.Log("Shoot!");
            rigidbody.AddForce(new Vector3(0, 1, 0), ForceMode.Impulse);
        });
    }

    void DestroyBox(EgoComponent brickEgoComponent)
    {
        Ego.DestroyGameObject(brickEgoComponent);
    }
}
