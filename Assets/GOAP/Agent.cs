using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SubGoal
{
    public Dictionary<string, int> sgoals;
    public bool remove;


    public SubGoal(string s, int i, bool r) 
    {
        sgoals = new Dictionary<string, int>();
        sgoals.Add(s, i);
        remove = r;
    }
}

public class Agent : MonoBehaviour
{
    public List<Action> actions = new List<Action>();
    public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>();

    Planner planner;
    Queue<Action> actionQueue;
    public Action currentAction;
    SubGoal currentGoal;
    // Start is called before the first frame update
   public void Start()
    {
        Action[] acts = this.GetComponents<Action>();
        foreach (Action a in acts)
            actions.Add(a);
    }

    // Update is called once per frame
    bool invoked = false;

    void CompleteAction() 
    {
        currentAction.running = false;
        currentAction.PostPerform();
        invoked = false;
    }

    void Update()
    {
        if (currentAction.target != null) 
        {
        
        }
    }

    void LateUpdate()
    {
        
        if (currentAction != null && currentAction.running) 
        {
            float distanceToTarget = Vector3.Distance(currentAction.target.transform.position, this.transform.position);
            if (currentAction.agent.hasPath && currentAction.agent.remainingDistance < 2f) 
            {
                //Debug.Log("Distance to goal: " + currentAction.agent.remainingDistance);
                if (!invoked) 
                {
                    Invoke("CompleteAction", currentAction.duration);
                    invoked = true;
                }
            }
            return;
        }

        if (planner == null || actionQueue == null) 
        {
            planner = new Planner();


            var sortedGoals = from entry in goals orderby entry.Value descending select entry;

            foreach (KeyValuePair<SubGoal, int> sg in sortedGoals)
            {
                actionQueue = planner.plan(actions, sg.Key.sgoals, null);
                if (actionQueue != null) 
                {
                    currentGoal = sg.Key;
                    break;
                }
            }
        }

        if (actionQueue != null && actionQueue.Count == 0) 
        {
            if (currentGoal.remove) 
            {
                goals.Remove(currentGoal);
            }
            planner = null;
        }

        if (actionQueue != null && actionQueue.Count > 0) 
        {
            currentAction = actionQueue.Dequeue();
            if (currentAction.PrePerform())
            {
                if (currentAction.target == null && currentAction.targetTag != "")
                {
                    currentAction.target = GameObject.FindWithTag(currentAction.targetTag);
                }
                if (currentAction.target != null)
                {
                    currentAction.running = true;
                    currentAction.agent.SetDestination(currentAction.target.transform.position);
                }
            }
            else 
            {
                actionQueue = null;
            }
        }
    }
}
