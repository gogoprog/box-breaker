using UnityEngine;

public class GameSystem : EgoSystem
{
    public override void Start()
    {
        Debug.Log("Start!!");

        var egoComponent = Ego.AddGameObject( GameObject.CreatePrimitive( PrimitiveType.Cube ) );
        egoComponent.transform.position = Vector3.zero;

        Ego.AddComponent<Box>( egoComponent );
    }

    public override void Update()
    {
        
    }
}