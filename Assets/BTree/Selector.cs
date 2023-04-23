using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BTree
{
    public class Selector : Node
    {
        //These scripts created originally created by Mina-Pecheux as referenced in report.
        //These scripts for the Behaviour tree were not created by me but were utilised for this project.
        //The behaviours and custom swarm tree in the swarm scripts folder were created by me.
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        continue;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }

    }
}