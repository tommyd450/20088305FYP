using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Action : MonoBehaviour
{
    /*
     * These Scripts were created following a course I did on Goal Oriented Action Planning,
     * The Course was created by Penny de Byl by following a course created by her at this site https://learn.holistic3d.com/course/goap/
     * These scripts are not used within the project as the project shifted away from Goal Oriented Action Planning
     * 
     */

    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;
    public string targetTag;
    public float duration = 0;
    public WorldState[] preConditions;
    public WorldState[] afterEffects;
    public NavMeshAgent agent;

    public Dictionary<string, int> preconditions;
    public Dictionary<string, int> effects;

    public WorldStates agentBeliefs;

    public bool running = false;

    public Action() 
    {
        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
        //agentBeliefs = 
    }

    public void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();

        if (afterEffects != null) 
        {
            foreach (WorldState w in preConditions) 
            {
                preconditions.Add(w.key, w.value);
            }
        }
        if (preconditions != null)
        {
            foreach (WorldState w in afterEffects)
            {
                effects.Add(w.key, w.value);
            }
        }
    }

    public bool IsAchieveable() 
    {
        return true;
    }

    public bool IsAchievableGiven(Dictionary<string, int> conditions)
    {
        foreach (KeyValuePair<string, int> p in preconditions) 
        {
            if (!conditions.ContainsKey(p.Key))
            {
                return false;
            }

        }
        return true;
    }

    public abstract bool PrePerform();
    public abstract bool PostPerform();

}
