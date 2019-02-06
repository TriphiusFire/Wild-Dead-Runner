using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacles;

    //dynamic size list, add, remove, etc
    //<GameObject>, generic
    private List<GameObject> obstaclesForSpawning = new List<GameObject>();
    
    
    
    // Start is called before the first frame update
    void Awake()
    {
        InitializeObstacles();
    }

    void Start()
    {
        StartCoroutine(SpawnRandomObstacle());
    }

    void InitializeObstacles()
    {
        int index = 0;
        
        for(int i = 0; i < obstacles.Length * 3; i++)
        {
            GameObject obj = Instantiate(obstacles[index], transform.localPosition, Quaternion.identity) as GameObject;
            obstaclesForSpawning.Add(obj);
            obstaclesForSpawning[i].SetActive(false);

            index++;
            if(index == obstacles.Length)
            {
                index = 0;
            }

        }        
    }

    void Shuffle()
    {
        for(int i = 0; i < obstaclesForSpawning.Count; i++)
        {
            GameObject temp = obstaclesForSpawning[i];
            int random = Random.Range(i, obstaclesForSpawning.Count);
            obstaclesForSpawning[i] = obstaclesForSpawning[random];
            obstaclesForSpawning[random] = temp;
        }
    }

    IEnumerator SpawnRandomObstacle()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 1f));

        int index = Random.Range(0, obstaclesForSpawning.Count);

        while (true)
        {
            if (!obstaclesForSpawning[index].activeInHierarchy)
            {
                obstaclesForSpawning[index].SetActive(true);
                
                
                if (obstaclesForSpawning[index].gameObject.name == "Barrel")
                {
                    Debug.Log("HI");
                    obstaclesForSpawning[index].transform.position = new Vector2(obstaclesForSpawning[index].transform.position.x, obstaclesForSpawning[index].transform.position.y+6f);
                }
                else
                {
                    obstaclesForSpawning[index].transform.position = transform.localPosition;
                }

                break;
            }
            else
            {
                index = Random.Range(0, obstaclesForSpawning.Count);
            }
        }

        StartCoroutine(SpawnRandomObstacle());
    }


}//ObstacleSpawner
