using UnityEngine;

public class CameraSystem : EgoSystem<
    EgoConstraint<Transform, Rigidbody, Ball>
    >
{
    private EgoComponent egoCamera;

    public override void Start()
    {
        egoCamera = Ego.AddGameObject(GameObject.Find("MainCamera"));
        Ego.AddComponent<Shaker>(egoCamera);
    }

    public override void Update()
    {
        Transform transform = null;

        constraint.ForEachGameObject( ( egoComponent, _transform, rigidbody, ball ) =>
        {
            transform = _transform;
        });

        if(transform != null)
        {
            var t = egoCamera.transform;
            t.position = new Vector3(t.position.x, transform.position.y * 0.1f, t.position.z);
        }
    }
}
