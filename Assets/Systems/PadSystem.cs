using UnityEngine;

public class PadSystem : EgoSystem<
    EgoConstraint<Transform, Rigidbody, Pad>
    >
{
    public override void Start()
    {

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

        constraint.ForEachGameObject( ( egoComponent, transform, rigidbody, ball ) =>
        {
            var x = transform.position.x;

            x += move * speed * Time.deltaTime;

            transform.position = new Vector3(x, -2, 0);
        });
    }
}
