using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BTree
{
    //These scripts created originally created by Mina-Pecheux as referenced in report.
    //These scripts for the Behaviour tree were not created by me but were utilised for this project.
    //The behaviours and custom swarm tree in the swarm scripts folder were created by me.
    public abstract class BHTree : MonoBehaviour
    {
        private Node _root = null;

        protected void Start()
        {
            _root = SetupTree();
        }

        private void Update()
        {
            if (_root != null)
            {
                _root.Evaluate();
            }
        }

        protected abstract Node SetupTree();
    }
}

