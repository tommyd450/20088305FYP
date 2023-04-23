using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public sealed class World 
{
    /*
 * These Scripts were created following a course I did on Goal Oriented Action Planning,
 * The Course was created by Penny de Byl by following a course created by her at this site https://learn.holistic3d.com/course/goap/
 * These scripts are not used within the project as the project shifted away from Goal Oriented Action Planning
 * 
 */
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
