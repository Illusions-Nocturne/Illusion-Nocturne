using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GridBehaviour : MonoBehaviour
{
    private Coroutine coroutine;
    //gridBehavior
    public bool findDistance = false;
    public int rows;
    public int cols;
    public int scale;
    public GameObject gridPrefabs;
    public Vector3 SouthEastLoc;
    public GameObject[,] gridArray;
    public int startX;
    public int startY;
    public int endX = 2;
    public int endY = 2;
    public List<GameObject> path = new List<GameObject>();
    //SearchPlayer
    private GameObject player;
    private float distToPlayer = 100;
    private bool attack = false;
    [SerializeField]private Vector3 lastPlayerPos;

    private void Awake()
    {
        player = GameObject.Find("Player");
        transform.position = new Vector3(startX, 1.5f, startY);
        gridArray = new GameObject[cols, rows];
        if(gridPrefabs)
            GenerateGrids();
        coroutine = StartCoroutine(Mouvement());
    }
    //private void FixedUpdate()
    //{
    //    if(lastPlayerPos != player.transform.position)
    //    {
    //        lastPlayerPos = player.transform.position;
    //        StartCoroutine(Mouvement());
    //    }
    //}
    IEnumerator Mouvement()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 4.5f)
        {
            if(!attack)
            {
                StartCoroutine(StartAttack());
                coroutine = StartCoroutine(Mouvement());
            }
        }
        else
        {
            distToPlayer = 100;
            SetDistance();
            SetPath();
            FindPlayer();
            path.Reverse();
            int xTemp = endX;
            int yTemp = endY;
            if(path.Count > 1)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    if (xTemp != endX || yTemp != endY)
                    {

                        path.Clear();
                        coroutine = StartCoroutine(Mouvement());
                    }
                    else
                    {
                        transform.position = path[i].transform.position;
                        startX = (int)transform.position.x / 3;
                        startY = (int)transform.position.z / 3;
                        yield return new WaitForSeconds(1);
                    }
                }
            }
            coroutine = StartCoroutine(Mouvement());
        }
    }
    IEnumerator StartAttack()
    {
        attack = true;
        yield return null;
    }
    void GenerateGrids()
    {
        for (int i = 0; i < cols; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                GameObject obj = Instantiate(gridPrefabs,new Vector3(SouthEastLoc.x+scale*i, SouthEastLoc.y, SouthEastLoc.z+scale*j),Quaternion.identity,gameObject.transform.parent.parent);
                obj.name = "waypoint  " + i + "-" + j;
                obj.GetComponent<GridStats>().x = i;
                obj.GetComponent<GridStats>().y = j;
                gridArray[i,j] = obj;
            }
        }
    }
    void InitialSetup()
    {
        print(gridArray[0,0]);
        foreach (GameObject obj in gridArray)
        {
            obj.GetComponent<GridStats>().visited = -1;
        }
        gridArray[startX, startY].GetComponent<GridStats>().visited = 0;
    }
    bool TestDirection(int x, int y, int step, int direction)
    {
        switch (direction)
        {
            case 4:
                if (x - 1 > -1 && gridArray[x - 1, y] && gridArray[x - 1, y].GetComponent<GridStats>().visited == step)
                    return true;
                else
                    return false;
            case 3:
                if (y - 1 > -1 && gridArray[x, y-1] && gridArray[x , y-1].GetComponent<GridStats>().visited == step)
                    return true;
                else
                    return false;
            case 2:
                if (x + 1 < cols && gridArray[x + 1, y] && gridArray[x + 1, y].GetComponent<GridStats>().visited == step)
                    return true;
                else
                    return false;
            case 1:
                if (y + 1 < rows && gridArray[x, y+1] && gridArray[x, y+1].GetComponent<GridStats>().visited == step)
                    return true;
                else
                    return false;

        }
        return false;
    }
    void SetVisited(int x, int y, int step)
    {
        if (gridArray[x, y])
            gridArray[x, y].GetComponent<GridStats>().visited = step;
    }
    void SetDistance()
    {
        InitialSetup();
        int x = startX;
        int y = startY; 
        int[] testArray = new int[rows*cols];
        for(int step = 1; step < cols*rows; step++)
        {
            foreach(GameObject obj in gridArray)
            {
                if( obj.GetComponent<GridStats>().visited == step - 1)
                {
                    TestAllDirection(obj.GetComponent<GridStats>().x,obj.GetComponent<GridStats>().y,step);   
                }
            }
        }
    }
    void TestAllDirection(int x, int y, int step)
    {
        if (TestDirection(x, y, -1, 1))
        {
            SetVisited(x, y + 1, step);
        }
        if (TestDirection(x ,y , -1, 2))
        {
            SetVisited(x + 1, y, step);
        }
        if (TestDirection(x, y, -1, 3))
        {
            SetVisited(x, y - 1, step);
        }
        if (TestDirection(x, y, -1, 4))
        {
            SetVisited(x - 1, y, step);
        }
    }
    void SetPath()
    {       
        int step;
        int x = endX;
        int y = endY;
        List<GameObject> tempList = new List<GameObject>();
        path.Clear();
        if (gridArray[endX, endY] && gridArray[endX, endY].GetComponent<GridStats>().visited > 0)
        {
            
            path.Add(gridArray[x, y]);
            step = gridArray[x, y].GetComponent<GridStats>().visited - 1;
        }
        else
        {
            print("Can't reach");
            return;
        }
        for (int i = step; step > -1; step--)
        {
            if (TestDirection(x, y, step, 1))
            {
                tempList.Add(gridArray[x, y + 1]);
            }
            if (TestDirection(x, y, step, 2))
            {
                tempList.Add(gridArray[x + 1, y]);
            }
            if (TestDirection(x, y, step, 3))
            {
                tempList.Add(gridArray[x, y - 1]);
            }
            if (TestDirection(x, y, step, 4))
            {
                tempList.Add(gridArray[x - 1, y]);
            }

            GameObject tempObj = FindClosest(gridArray[endX, endY].transform, tempList);
            path.Add(tempObj);
            x = tempObj.GetComponent<GridStats>().x;
            y = tempObj.GetComponent<GridStats>().y;
            tempList.Clear();

        }
    } 
    GameObject FindClosest(Transform targetLocation,List<GameObject> list)
    {
        float currentDist = scale*rows*cols;
        int indexNumber = 0;
        for(int i = 0; i < list.Count; i++)
        {
            if (Vector3.Distance(targetLocation.position, list[i].transform.position) < currentDist)
            {
                currentDist = Vector3.Distance(targetLocation.position, list[i].transform.position);
                indexNumber = i;
            }
        }
        return list[indexNumber];
    }
    public void FindPlayer()
    {
        for(int i = 0; i < cols; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                if(distToPlayer > Vector3.Distance(gridArray[i, j].transform.position, player.transform.position))
                {
                    distToPlayer = Vector3.Distance(gridArray[i, j].transform.position, player.transform.position);
                    endX = i;
                    endY = j;
                }
            }
        }
    }
}
    