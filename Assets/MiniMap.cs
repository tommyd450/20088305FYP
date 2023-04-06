using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject mapFrag;
    // Start is called before the first frame update
    void Start()
    {
        
    }




    // Update is called once per frame
    void Update()
    {
    }

    public void makeMap() 
    {
        GameObject gen = GameObject.Find("Generation");
        int width = gen.GetComponent<CellularAutomata>().width;
        int height = gen.GetComponent<CellularAutomata>().height;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (i!=0  && j!= 0 &&gen.GetComponent<CellularAutomata>().rocks[i, j] == "")
                {
                    GameObject m = Instantiate(mapFrag, this.transform);
                    m.transform.localPosition = new Vector3(i+20, j+20, 0);
                }

            }
        }
    }
}
