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
        int width = 5;
        int height = 5;
        float offsetX = bounds.size.z * 10 * width * -0.5f;

        for (int i = 0; i <= width; i++)
        {
            for (int j = 0; j <= height; j++)
            {
                var egoComponent = Factory.createBox();
                egoComponent.transform.position = new Vector3(offsetX + i * bounds.size.z * 10, j * bounds.size.y * 10, 0);
            }
        }

        {
            var egoComponent = Factory.createBall();
            egoComponent.transform.position = new Vector3(0, -3, 0);
            egoComponent.gameObject.name = "Ball";
        }

        {
            var egoComponent = Factory.createPad();
            egoComponent.transform.position = new Vector3(0, -4, 0);
        }
    }

    public override void Update()
    {
        
    }
}