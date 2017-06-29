using UnityEngine;

public class CollisionSystem : EgoSystem
{
    public override void Start()
    {
        EgoEvents<CollisionEnterEvent>.AddHandler(Handle);
    }

    public override void Update()
    {

    }

    void Handle(CollisionEnterEvent e)
    {
        if(e.egoComponent1.HasComponents<Ball>() || e.egoComponent1.HasComponents<Ball>())
        {
            Transform padTransform = null;
            Rigidbody rigidbody;
            Transform transform;

            if(e.egoComponent1.HasComponents<Ball>())
            {
                rigidbody = e.egoComponent1.GetComponent<Rigidbody>();
                transform = e.egoComponent1.transform;
            }
            else
            {
                rigidbody = e.egoComponent2.GetComponent<Rigidbody>();
                transform = e.egoComponent2.transform;
            }

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
                float d = transform.position.x - padTransform.position.x;
                rigidbody.velocity = new Vector3(d, rigidbody.velocity.y + e.collision.contacts[0].normal.y * 2.5f, 0);
            }
            else
            {
                rigidbody.velocity = rigidbody.velocity + e.collision.contacts[0].normal * 2;
            }

            if(e.egoComponent1.HasComponents<Box>())
            {
                DestroyBox( e.egoComponent1 );
            }
            else if(e.egoComponent2.HasComponents<Box>())
            {
                DestroyBox( e.egoComponent2 );
            }
        }
    }

    void DestroyBox(EgoComponent brickEgoComponent)
    {
        Ego.DestroyGameObject(brickEgoComponent);
    }
}
