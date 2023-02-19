using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using Unity.AI.Navigation;
using UnityEngine;

public class CellularAutomata : MonoBehaviour
{
    public NavMeshSurface nm;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject asteroid;
    [SerializeField] float birthVal;
    [SerializeField] float deathVal;
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] float startAlive;
    [SerializeField] float steps;
    GameObject[] bake;

    public string[,] rocks;

    void Start()
    {
        initialGen();
        cleanUp();
        MapOut();
        spawn();
        nm = GameObject.Find("Nav").GetComponent<NavMeshSurface>();
        bake = new GameObject[width * height];
        nm.BuildNavMesh();
        nm.UpdateNavMesh(nm.navMeshData);
    }

    public void initialGen()
    {
        
        rocks = new string[width,height];
        for (int i = 0; i < width; i++) 
        {
            for (int j = 0; j < height; j++)
            {
                float rand = Random.Range(0f,1f);
                if (rand < startAlive)
                {
                    rocks[i, j] = "w";
                }
                else 
                {
                    rocks[i, j] = "n";
                }
                //Debug.Log(rocks[i, j]);
            }
            
        }
    }

    public void cleanUp() 
    {
        for(int l = 0; l < steps; l++) {
            for (int i = 0; i < width - 1; i++)
            {

                for (int j = 0; j < height - 1; j++)
                {
                    int numNeighbours = 0;
                    int numEmpty = 0;

                    // Three Cells above ie . NW, N, NE
                    if (i != 0 && j > 0 && rocks[i, j - 1].Equals("w"))
                    {
                        numNeighbours++;
                    }
                    if (i > 0 && j > 0 && rocks[i - 1, j - 1].Equals("w"))
                    {
                        numNeighbours++;
                    }
                    if (i > 0 && j > 0 && i < width && rocks[i + 1, j - 1].Equals("w"))
                    {
                        numNeighbours++;
                    }
                    // Cells to the left and right ie. West and East
                    if (i != 0 && j > 0 && rocks[i - 1, j].Equals("w"))
                    {
                        numNeighbours++;
                    }
                    if (i != 0 && j > 0 && i < width && rocks[i + 1, j].Equals("w"))
                    {
                        numNeighbours++;
                    }
                    //Cells below ie SW, S , SE
                    if (i != 0 && j > 0 && j < height && rocks[i, j + 1].Equals("w"))
                    {
                        numNeighbours++;
                    }
                    if (i != 0 && j > 0 && i < width && j < height && rocks[i + 1, j + 1].Equals("w"))
                    {
                        numNeighbours++;
                    }
                    if (i != 0 && j > 0 && j < height && rocks[i - 1, j + 1].Equals("w"))
                    {
                        numNeighbours++;
                    }
                    //cout << numNeighbours << endl;

                    

                    if (rocks[i, j].Equals("w") && numNeighbours <birthVal)
                    {
                        rocks[i, j] = "";
                    }
                    else if (rocks[i, j].Equals("") && numNeighbours > deathVal)
                    {
                        rocks[i, j] = "w";
                    }

                    if (i != 0 && j > 0 && rocks[i, j - 1].Equals(""))
                    {
                        numEmpty++;
                    }
                    if (i > 0 && j > 0 && rocks[i - 1, j - 1].Equals(""))
                    {
                        numEmpty++;
                    }
                    if (i > 0 && j > 0 && i < height && rocks[i + 1, j - 1].Equals(""))
                    {
                        numEmpty++;
                    }
                    // Cells to the left and right ie. West and East
                    if (i != 0 && j > 0 && rocks[i - 1, j].Equals("w"))
                    {
                        numEmpty++;
                    }
                    if (i != 0 && j > 0 && i < height && rocks[i + 1, j].Equals(""))
                    {
                        numEmpty++;
                    }
                    //Cells below ie SW, S , SE
                    if (i != 0 && j > 0 && j < width && rocks[i, j + 1].Equals(""))
                    {
                        numEmpty++;
                    }
                    if (i != 0 && j > 0 && i < height && j < width && rocks[i + 1, j + 1].Equals(""))
                    {
                        numEmpty++;
                    }
                    if (i != 0 && j > 0 && j < width && rocks[i - 1, j + 1].Equals(""))
                    {
                        numEmpty++;
                    }
                   /* if (rocks[i, j].Equals("") && numEmpty == 5)
                    {
                        rocks[i, j] = "s";
                    }*/
                }
            }
        }
    }

    public void MapOut() 
    {
    
    
    }

    public void spawn() 
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (rocks[i, j] == "w")
                {
                    Vector3 pos = new Vector3(5* i, 0, 5 * j);


                    GameObject obj = Instantiate(asteroid);

                    obj.transform.position = pos;
                }

                if (rocks[i, j] == "s") 
                {
                    Vector3 pos = new Vector3(5 * i, 0, 5 * j);


                   // GameObject obj = Instantiate(enemy);

                   // obj.transform.position = pos;
                }
            }

        }
    }


}
