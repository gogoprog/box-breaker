using UnityEngine;

public class AutoRemoveSystem : EgoSystem<
    EgoConstraint<AutoRemove>
    >
{
    public override void Start()
    {
    }

    public override void Update()
    {
        constraint.ForEachGameObject( (egoComponent, autoRemove) =>
        {
            autoRemove.time += Time.deltaTime;

            if(autoRemove.time >= autoRemove.duration)
            {
                Ego.DestroyGameObject(egoComponent);
            }
        });
    }
}
