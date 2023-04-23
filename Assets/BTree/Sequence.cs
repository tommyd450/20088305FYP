using System.Collections;
using System.Collections.Generic;
using UnityEngine;


  

namespace BTree
{
    public class Sequence : Node
    {
        //These scripts created originally created by Mina-Pecheux as referenced in report.
        //These scripts for the Behaviour tree were not created by me but were utilised for this project.
        //The behaviours and custom swarm tree in the swarm scripts folder were created by me.
        public Sequence() : base() { }
        public Sequence(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            bool anyChildIsRunning = false;

            foreach (Node node in children)
            {
                switch (node.Evaluate())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }

            state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }

    }

}
