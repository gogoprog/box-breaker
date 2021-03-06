using UnityEngine;

public class PadSystem : EgoSystem<
    EgoConstraint<Transform, Rigidbody, Pad>
    >
{
    private float halfDistance;

    public override void Start()
    {
        halfDistance = GameObject.Find("WallRight").transform.position.x - 0.5f;
        EgoEvents<ShootEvent>.AddHandler(Handle);
        EgoEvents<LostEvent>.AddHandler(Handle);
    }

    public override void Update()
    {
        var mousePosition = Input.mousePosition;
        float move = 0;
        float speed = 5;

        if(Input.GetKey(KeyCode.A))
        {
            move -= 1;
        }

        if(Input.GetKey(KeyCode.D))
        {
            move += 1;
        }

        constraint.ForEachGameObject((egoComponent, transform, rigidbody, pad) =>
        {
            var x = transform.position.x;
            var y = transform.position.y;

            x += move * speed * Time.deltaTime;

            x = Mathf.Min(halfDistance, Mathf.Max(-halfDistance, x));

            transform.position = new Vector3(x, y, 0);
        });
    }

    void Handle(ShootEvent e)
    {
        constraint.ForEachGameObject((egoComponent, transform, rigidbody, pad) =>
        {
            var ball = GameObject.Find("Ball");
            ball.GetComponent<Rigidbody>().isKinematic = false;

            Ego.DestroyComponent<PadLock>(egoComponent);
            Ego.AddComponent<PadPlay>(egoComponent);
        });
    }

    void Handle(LostEvent e)
    {
        constraint.ForEachGameObject((egoComponent, transform, rigidbody, pad) =>
        {
            var ball = GameObject.Find("Ball");
            ball.GetComponent<Rigidbody>().isKinematic = true;
            
            Ego.DestroyComponent<PadPlay>(egoComponent);
            Ego.AddComponent<PadLock>(egoComponent);
        });
    }
}
