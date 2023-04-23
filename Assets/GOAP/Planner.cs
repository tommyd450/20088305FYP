using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GOAP
{/*
 * These Scripts were created following a course I did on Goal Oriented Action Planning,
 * The Course was created by Penny de Byl by following a course created by her at this site https://learn.holistic3d.com/course/goap/
 * These scripts are not used within the project as the project shifted away from Goal Oriented Action Planning
 * 
 */
    public class Node
    {
        public Node parent;
        public float cost;
        public Dictionary<string, int> state;
        public Action action;

        public Node(Node parent, float cost, Dictionary<string, int> allstates, Action action)
        {
            this.parent = parent;
            this.cost = cost;
            this.state = new Dictionary<string, int>(allstates);
            this.action = action;
        }
    }

    public class Planner
    {

        public Queue<Action> plan(List<Action> actions, Dictionary<string, int> goal, WorldStates states)
        {
            List<Action> usableActions = new List<Action>();
            foreach (Action a in actions)
            {
                if (a.IsAchieveable())
                    usableActions.Add(a);
            }

            List<Node> leaves = new List<Node>();
            Node start = new Node(null, 0, World.Instance.GetWorld().GetStates(), null);

            bool success = BuildGraph(start, leaves, usableActions, goal);

            if (!success)
            {
                Debug.Log("No PLAN");
                return null;
            }

            Node cheapest = null;
            foreach (Node leaf in leaves)
            {
                if (cheapest == null)
                    cheapest = leaf;
                else
                {
                    if (leaf.cost < cheapest.cost)
                        cheapest = leaf;
                }
            }

            List<Action> result = new List<Action>();
            Node n = cheapest;
            while (n != null)
            {
                if (n.action != null)
                {
                    result.Insert(0, n.action);
                }
                n = n.parent;
            }

            Queue<Action> queue = new Queue<Action>();
            foreach (Action a in result)
            {
                queue.Enqueue(a);
            }

            Debug.Log("The Plan is:");
            foreach (Action a in queue)
            {
                Debug.Log("Q: " + a.actionName);
            }
            return queue;
        }

        private bool BuildGraph(Node parent, List<Node> leaves, List<Action> usuableActions, Dictionary<string, int> goal)
        {
            bool foundPath = false;
            foreach (Action action in usuableActions)
            {
                if (action.IsAchievableGiven(parent.state))
                {
                    Dictionary<string, int> currentState = new Dictionary<string, int>(parent.state);
                    foreach (KeyValuePair<string, int> eff in action.effects)
                    {
                        if (!currentState.ContainsKey(eff.Key))
                            currentState.Add(eff.Key, eff.Value);
                    }

                    Node node = new Node(parent, parent.cost + action.cost, currentState, action);
                    if (GoalAchieved(goal, currentState))
                    {
                        leaves.Add(node);
                        foundPath = true;
                    }
                    else
                    {
                        List<Action> subset = ActionSubset(usuableActions, action);
                        bool found = BuildGraph(node, leaves, subset, goal);
                        if (found)
                            foundPath = true;
                    }
                }
            }
            return foundPath;
        }

        private bool GoalAchieved(Dictionary<string, int> goal, Dictionary<string, int> state)
        {
            foreach (KeyValuePair<string, int> g in goal)
            {
                if (!state.ContainsKey(g.Key))
                    return false;
            }
            Debug.Log("Achieved");
            return true;


        }

        private List<Action> ActionSubset(List<Action> actions, Action removeMe)
        {
            List<Action> subset = new List<Action>();
            foreach (Action a in actions)
            {
                if (!a.Equals(removeMe))
                    subset.Add(a);
            }
            return subset;
        }
    }
}
