using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using System.Linq;



public class CellularAutomata : MonoBehaviour
{
    int cellvisits =0;
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

    public int[,] Visited;

    public class Node
    {
        public int x;
        public int y;
    }

    List<Node> openCell = new List<Node>();

    List<List<Node>> caves = new List<List<Node>>();

    void Start()
    {
        InitialGen();
        CleanUp();
        Visited = new int[width, height];
        FloodFillManager(Visited);

        Spawn();
        nm = GameObject.Find("Nav").GetComponent<NavMeshSurface>();
        bake = new GameObject[width * height];
        nm.BuildNavMesh();
        nm.UpdateNavMesh(nm.navMeshData);
        //Debug.Log("Cave Amount: " + caves.Count);
        for (int i = 0; i < caves.Count; i++) 
        {
            Debug.Log("Cave Number: "+i+" "+caves.ElementAt(i).Count);
        }
    }

    public void InitialGen()
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
                    rocks[i, j] = "";
                }
                //Debug.Log(rocks[i, j]);
            }
            
        }
    }

    public void CleanUp() 
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
                    if (rocks[i, j].Equals("") && numNeighbours > deathVal)
                    {
                        rocks[i, j] = "w";
                    }


                    

                    
                }
            }
        }
    }
    public void Spawn() 
    {
        int deadCells = 0;
        int openCells = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (rocks[i, j] == "w")
                {
                    Vector3 pos = new Vector3(15 * i, 0, 15 * j);


                    GameObject obj = Instantiate(asteroid);

                    obj.transform.position = pos;
                    deadCells++;
                }
                else 
                {
                    openCells++;
                }

                if (rocks[i, j] == "s") 
                {
                    Vector3 pos = new Vector3(5 * i, 0, 5 * j);


                   // GameObject obj = Instantiate(enemy);

                   // obj.transform.position = pos;
                }
            }

        }
        Debug.Log("deadCells "+ deadCells);
        Debug.Log("cellVisits " + cellvisits);
        Debug.Log("openCells " + openCells);

    }

    


    public void FloodFillManager(int[,] visited) 
    {
        List<Node> temp = new List<Node>();
        //List<int[,]> caves = new List<int[,]>();
        for (int i = 0; i < width; i++) 
        {
            
            for (int j = 0; j < height; j++)
            {

                if (Visited[i, j] == 0)
                {

                    Visited = FloodFill(i, j, Visited);


                    if (Visited[i, j] == 1)
                    {
                        caves.Add(openCell);


                    }



                    //Debug.Log("Current Cave Size: "+openCell.Count);
                }
                else 
                {
                    openCell = new List<Node>();
                }
                


            }
            
        }

        //Debug.Log("VisitedLenght: "+Visited.Length);
    }


    // The aim of this method is to use disjoint sets to measure cave sizes and filter out smaller caves
    public int[,] FloodFill(int x, int y, int[,] visited)
    {
        //Pick point to start at
        //Visit all neighbours recursively
        //Only use point x if it is empty/dead
        //Mark all visited with num

        //visited = 0 = wall
        //visited = 1 = open

        if (rocks[x, y].Equals("") && visited[x, y] != 1)
        {

            openCell.Add(new Node() { x = x, y = y });
            cellvisits++;
            visited[x, y] = 1;
        }
        
        
        

        
        if (rocks[x,y].Equals("")&&visited[x,y]==1) 
        {
            if (x-1>=0 && rocks[x - 1, y].Equals("") && visited[x-1, y] != 1)
            {
                
                visited = FloodFill(x - 1, y, visited);         
            }
            
            if (x + 1 <= width-1 &&  x != width &&   y<=height &&rocks[x + 1, y].Equals("") && visited[x+1, y] != 1)
            {

                visited = FloodFill(x + 1, y, visited);
            }
            if (y-1>=0 && rocks[x, y - 1].Equals("") && visited[x, y-1] != 1)
            {

                visited = FloodFill(x, y-1, visited);
            }
            if (y+1<=height-1 && x<=width &&rocks [x,y+1].Equals("") && visited[x, y+1] != 1)
            {
                
                visited = FloodFill (x, y + 1, visited);
            }

            
        }
        




        return visited;
    }
        
    
}
