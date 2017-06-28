using UnityEngine;

public class GameSystem : EgoSystem
{
    public override void Start()
    {
        Debug.Log("Start!!");

        var prefab = Resources.Load ("Brick0") as GameObject;
        var mesh = prefab.transform.GetChild(0).GetComponent<MeshFilter>().sharedMesh;
        Bounds bounds = mesh.bounds;

        for (int i = 0; i <= 5; i++)
        {
            for (int j = 0; j <= 5; j++)
            {
                var egoComponent = Ego.AddGameObject(Object.Instantiate<GameObject>(prefab));
                egoComponent.transform.position = new Vector3(i * bounds.size.z * 10, j * bounds.size.y * 10, 0);

                Ego.AddComponent<Box>(egoComponent);
            }
        }


        {
            var ballPrefab = Resources.Load ("Ball0") as GameObject;

            var egoComponent = Ego.AddGameObject(Object.Instantiate<GameObject>(ballPrefab));
            egoComponent.transform.position = new Vector3(0, -2, 0);

            Ego.AddComponent<Ball>(egoComponent);

            egoComponent.GetComponent<Ball>().velocity = new Vector3(0, 1, 0);
        }
    }

    public override void Update()
    {
        
    }
}