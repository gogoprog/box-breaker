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
            new BoxSystem(),
            new AutoRemoveSystem(),
            new HitSystem()
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

