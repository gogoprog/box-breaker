using UnityEngine;

public static class Factory
{
    public static GameObject boxPrefab;
    public static GameObject ballPrefab;
    public static GameObject padPrefab;
    public static GameObject explosionPrefab;

    public static void Initialize()
    {
        boxPrefab = Resources.Load ("Brick0") as GameObject;
        ballPrefab = Resources.Load ("Ball0") as GameObject;
        padPrefab = Resources.Load ("Pad0") as GameObject;
        explosionPrefab = Resources.Load ("Explosion0") as GameObject;
    }

    public static EgoComponent createBox()
    {
        var egoComponent = Ego.AddGameObject(Object.Instantiate<GameObject>(boxPrefab));

        Ego.AddComponent<Box>(egoComponent);
        Ego.AddComponent<Life>(egoComponent);

        return egoComponent;
    }

    public static EgoComponent createBall()
    {
        var egoComponent = Ego.AddGameObject(Object.Instantiate<GameObject>(ballPrefab));

        Ego.AddComponent<Ball>(egoComponent);
        Ego.AddComponent<OnCollisionEnterComponent>(egoComponent);

        return egoComponent;
    }

    public static EgoComponent createPad()
    {
        var egoComponent = Ego.AddGameObject(Object.Instantiate<GameObject>(padPrefab));

        Ego.AddComponent<Pad>(egoComponent);
        Ego.AddComponent<PadLock>(egoComponent);

        return egoComponent;
    }

    public static EgoComponent createExplosion()
    {
        var egoComponent = Ego.AddGameObject(Object.Instantiate<GameObject>(explosionPrefab));
        
        Ego.AddComponent<AutoRemove>(egoComponent); 

        return egoComponent;
    }

}