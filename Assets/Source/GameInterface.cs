using UnityEngine;
using System.Collections.Generic;

public class GameInterface : MonoBehaviour
{
    static GameInterface()
    {
        EgoSystems.Add(
            new GameSystem(),
            new BallSystem(),
            new CollisionSystem(),
            new PadSystem(),
            new PadLockSystem(),
            new PadPlaySystem(),
            new BoxSystem(),
            new AutoRemoveSystem(),
            new HitSystem(),
            new CameraSystem()
        );
    }

    void Start()
    {
        EgoSystems.Start();
    }
    
    void Update()
    {
        EgoSystems.Update();
    }
    
    void FixedUpdate()
    {
        EgoSystems.FixedUpdate();
    }
}

