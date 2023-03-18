using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using System.Linq;



public class CellularAutomata : MonoBehaviour
{
    int cellvisits = 0;
    public NavMeshSurface nm;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject asteroid;
    [SerializeField] GameObject test;
    [SerializeField] GameObject test2;
    [SerializeField] float birthVal;
    [SerializeField] float deathVal;
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] float startAlive;
    [SerializeField] float steps;
    [Range(0.0f, 1f)] public float sizeOfLargest;
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
    List<List<Node>> actualCaves = new List<List<Node>>();

    void Start()
    {
        InitialGen();
        CleanUp();
        Visited = new int[width, height];
        FloodFillManager(Visited);
        caveCleaner();
        caveJoiner();
        Spawn();


        nm = GameObject.Find("Nav").GetComponent<NavMeshSurface>();
        bake = new GameObject[width * height];
        nm.BuildNavMesh();
        nm.UpdateNavMesh(nm.navMeshData);
        
        //Debug.Log("Cave Amount: " + caves.Count);
        
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
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                rocks[1, j] = "w";
                rocks[2, j] = "w";
                rocks[3, j] = "w";
                rocks[width - 1, j] = "w";
                rocks[width - 2, j] = "w";
                rocks[width - 3, j] = "w";
            }
            rocks[i, 1] = "w";
            rocks[i, 2] = "w";
            rocks[i, 3] = "w";
            rocks[i, height - 1] = "w";
            rocks[i, height - 2] = "w";
            rocks[i, height - 3] = "w";
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

                if (rocks[i, j] == "r") 
                {
                    Vector3 pos = new Vector3(15 * i, 0, 15 * j);
                    GameObject obj = Instantiate(test);
                    obj.transform.position = pos;
                    //deadCells++;
                }

                if (rocks[i, j] == "b")
                {
                    Vector3 pos = new Vector3(15 * i, 0, 15 * j);
                    GameObject obj = Instantiate(test2);
                    obj.transform.position = pos;
                    //deadCells++;
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
                }
                else 
                {
                    openCell = new List<Node>();
                }
            }   
        }
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


    public void caveCleaner() 
    {
        float sumSize = 0;
        float avgSize;
        float largest = 0;
        for (int i = 0; i < caves.Count; i++)
        {
            Debug.Log("Cave Number: " + i + " " + caves.ElementAt(i).Count);
            if (caves.ElementAt(i).Count > largest)
            {
                largest = caves.ElementAt(i).Count;
                Debug.Log("Largest " + largest);
            }
        }

        avgSize = sumSize / caves.Count;
        Debug.Log("Average Size = " + avgSize);

        for (int i = 0; i < caves.Count; i++)
        {
            if (caves.ElementAt(i).Count() < largest * sizeOfLargest)
            {
                foreach (Node f in caves.ElementAt(i))
                {
                    rocks[f.x, f.y] = "r";
                }
                Debug.Log("Smaller Than");
            }
            else
            {
                actualCaves.Add(caves.ElementAt(i));
            }

        }
        Debug.Log("Caves After: " + actualCaves.Count);
    }


    public void caveJoiner()
    {
        Vector2 pos1 = new Vector2(0,0);
        Vector2 pos2 = new Vector2(0,0);
        for (int i = 0; i < actualCaves.Count; i++)
        {
            pos1.x = 0;
            pos1.y = 0;
            pos2.x = 0;
            pos2.y = 0;
            for (int j = 0; j < actualCaves.Count; j++)
            {
                
                foreach (Node f in actualCaves.ElementAt(i))
                {
                    foreach (Node g in actualCaves.ElementAt(j))
                    {
                        Vector2 t1 = new Vector2(f.x, f.y);
                        Vector2 t2 = new Vector2(g.x, g.y);
                        if (Vector2.Distance(t1, t2) < Vector2.Distance(pos1,pos2) || Vector2.Distance(pos1, pos2)==0) 
                        {
                            pos1.x = f.x;
                            pos1.y = f.y;
                            pos2.x = g.x;
                            pos2.y = g.y;
                        }
                    }
                }
                
            }
            if (pos1.x != 0 && pos1.y != 0 && pos2.x != 0 && pos2.y != 0)
            {
                rocks[(int)pos1.x, (int)pos1.y] = "b";
                rocks[(int)pos2.x, (int)pos2.y] = "b";
            }
        }
    }
}
