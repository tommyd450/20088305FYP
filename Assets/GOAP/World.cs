using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public sealed class World 
{

    private static readonly World instance = new World();
    private static WorldStates world;
    // Start is called before the first frame update

    static World()
    {
        world = new WorldStates();
    }

    private World() { }

    public static World Instance 
    {
        get { return instance;  }
    }

    public WorldStates GetWorld() 
    {
        return world;
    }
}
