using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BTree
{
    public abstract class Tree : MonoBehaviour
    {
        // Start is called before the first frame update
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
