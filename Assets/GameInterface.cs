using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;

public class GameInterface : MonoBehaviour
{
    static GameInterface()
    {
        EgoSystems.Add(
            new BoxSystem(),
            new GameSystem()
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

[CustomEditor( typeof( GameInterface ) ) ]
public class GameInterfaceEditor : EgoInterfaceEditor
{
}
