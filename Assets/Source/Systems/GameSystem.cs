using UnityEngine;

public class GameSystem : EgoSystem
{
    public override void Start()
    {
        Debug.Log("Start!!");

        Factory.Initialize();

        var prefab = Factory.boxPrefab;
        var mesh = prefab.transform.GetComponent<MeshFilter>().sharedMesh;
        Bounds bounds = mesh.bounds;

        for (int i = 0; i <= 5; i++)
        {
            for (int j = 0; j <= 5; j++)
            {
                var egoComponent = Factory.createBox();
                egoComponent.transform.position = new Vector3(i * bounds.size.z * 10, j * bounds.size.y * 10, 0);
            }
        }

        {
            var egoComponent = Factory.createBall();
            egoComponent.transform.position = new Vector3(0, -1, 0);
        }

        {
            var egoComponent = Factory.createPad();
            egoComponent.transform.position = new Vector3(0, -2, 0);
        }

         EgoEvents<ShootEvent>.AddEvent(new ShootEvent());
    }

    public override void Update()
    {
        
    }
}