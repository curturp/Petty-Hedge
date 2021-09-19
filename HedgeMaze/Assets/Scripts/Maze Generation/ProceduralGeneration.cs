using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    // Made using this tutorial by Joseph Hocking, modified for use in a 2D space, and to generate the maze accoridng to my needs: https://www.raywenderlich.com/82-procedural-generation-of-mazes-with-unity

    [Header("Maze Size")]
    [SerializeField] private Vector2Int mazeDimenstions = new Vector2Int(31, 21);

    [Header("Objects for the Maze")]
    [SerializeField] private GameObject obstacle, buildNode, pathFinder, goal;

    [Header("Pathfinders Starting Position in the Maze")]
    [SerializeField] private Vector2Int startPosition = new Vector2Int(-14, 9);

    private MazeDataGenerator dataGenerator;

    GameObject instancedGoal;
    GameObject instancedPathFinder;

    public GameManager gameManager;

    public int[,] data
    {
        get; private set;
    }

    private void Awake()
    {
        dataGenerator = new MazeDataGenerator();

        data = new int[,]
        {
            {1, 1, 1},
            {1, 0, 1},
            {1, 1, 1}
        };
    }

    void Start()
    {
        GenerateNewMaze(mazeDimenstions.x, mazeDimenstions.y);
        GenerateMaze();
        FindStartPosition();
        FindGoalPosition();
    }

    void GenerateMaze()
    {

        int[,] maze = data;
        int rMax = maze.GetUpperBound(0);
        int cMax = maze.GetUpperBound(1);


        for (int i = rMax; i >= 0; i--)
        {
            for (int j = 0; j <= cMax; j++)
            {
                if (maze[i, j] == 0)
                {
                    SpawnObj(buildNode, i, j, 2);
                }
                else
                {
                    SpawnObj(obstacle, i, j, 2);
                }
            }
        }
    }

    public void GenerateNewMaze(int sizeRows, int sizeCols)
    {
        data = dataGenerator.FromDimensions(sizeRows - 2, sizeCols - 2);

        if (sizeRows % 2 == 0 && sizeCols % 2 == 0)
        {
            Debug.LogError("Odd numbers work better for maze size.");
        }
    }

    public void FindStartPosition()
    {
        int[,] maze = data;
        int rMax = maze.GetUpperBound(0);
        int cMax = maze.GetUpperBound(1);

        for (int i = 0; i <= rMax; i++)
        {
            for (int j = 0; j <= cMax; j++)
            {
                if (maze[i,j] == 0)
                {
                    instancedPathFinder = SpawnObj(pathFinder, i, j, 0);
                    if (gameManager == null)
                    {
                        Debug.Log("PF CREATED WITHOUT SCRIPT");
                    }
                    else gameManager.SetPathFinder(instancedPathFinder);
                    return;
                }
            }
        }
    }

    public void FindGoalPosition()
    {
        int[,] maze = data;
        int rMax = maze.GetUpperBound(0);
        int cMax = maze.GetUpperBound(1);

        for (int i = rMax ; i >= 0; i--)
        {
            for (int j = cMax; j >= 0; j--)
            {
                if (maze[i, j] == 0)
                {
                    instancedGoal = SpawnObj(goal, i, j, 1);  
                    if (gameManager == null)
                    {
                        Debug.Log("GOAL CREATED WITHOUT SCRIPT");
                    }
                    else gameManager.SetGoal(instancedGoal);
                    return;
                }
            }
        }
    }

    GameObject SpawnObj(GameObject obj, int width, int height, int forward)
    {
        obj = Instantiate(obj, new Vector3(startPosition.x + width, startPosition.y - height, forward), Quaternion.identity);
        obj.transform.parent = this.transform;
        return obj;
    }

}
