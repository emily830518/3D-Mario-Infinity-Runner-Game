using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour
{
    public Transform[] StuffSpawnPoints;
    public GameObject[] bonus;
    public GameObject[] obstacles;
    public int random_range = 2;
    float[] place_x = { -3.0f, 3.0f, 9.0f };

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < StuffSpawnPoints.Length; i++){
            if(i==0)
            {
                if (Random.Range(0, 10) == 0 && random_range > 2)
                {
                    CreateBonus(StuffSpawnPoints[i].position, 2);
                }

                else if (Random.Range(0, 3) == 0)
                {
                    if (Random.Range(0, 3) == 0)
                    {
                        CreateBonus(StuffSpawnPoints[i].position, 0);
                    }
                    else if (Random.Range(0, 8) == 0)
                    {
                        CreateBonus(StuffSpawnPoints[i].position, 1);
                    }
                }

            }
            else{
                if(Random.Range(0,2) == 0){
                    CreateObstacle(StuffSpawnPoints[i].position, Random.Range(0, random_range));
                }
                else
                {
                    if (Random.Range(0, 2) == 0)
                    {
                        CreateBonus(StuffSpawnPoints[i].position, 0);
                    }
                    else if (Random.Range(0, 8) == 0)
                    {
                        CreateBonus(StuffSpawnPoints[i].position, 1);
                    }
                }
            }
        }
        //bool placeObstacle = Random.Range(0, 2) == 0;
        //int obstacleIndex = -1;
        //if(placeObstacle)
        //{
        //    obstacleIndex = Random.Range(1, StuffSpawnPoints.Length);
        //    CreateObstacle(StuffSpawnPoints[obstacleIndex].position, Random.Range(0, random_range));
        //}

        //for (int i = 0; i < StuffSpawnPoints.Length; i++){
        //    if (i == obstacleIndex) continue;
        //    if (Random.Range(0,3)==0)
        //    {
        //        CreateBonus(StuffSpawnPoints[i].position, Random.Range(0, random_range));
        //    }
        //}
    }

    void CreateObstacle(Vector3 position, int type)
    {
        var prefab = obstacles[type];
        position.z = place_x[Random.Range(0, 3)];
        if (type == 0){ // tube
            position.y = 3.5f;
            var obj = Instantiate(prefab, position, Quaternion.identity);
            obj.AddComponent(typeof(TimeDestroyer));
        }
        else if (type == 1){ // brick
            position.y = 0f;
            var obj = Instantiate(prefab, position, Quaternion.identity);
            obj.AddComponent(typeof(TimeDestroyer));
        }
        if (type == 2){ //boo
            position.y = 3.0f;
            var obj = Instantiate(prefab, position, Quaternion.Euler(0, 90.0f, 0));
            obj.AddComponent(typeof(MoveLeftToRight));
            obj.AddComponent(typeof(TimeDestroyer));
        }
    }

    void CreateBonus(Vector3 position, int type)
    {
        var prefab = bonus[type];
        position.z = place_x[Random.Range(0, 3)];
        if(type == 0){ // coin
            position.y = 0f;
            var obj = Instantiate(prefab, position, Quaternion.identity);
            obj.AddComponent(typeof(Rotate));
            obj.AddComponent(typeof(TimeDestroyer));
        }
        else if(type==1){ // mushroom
            position.y = 0.3f;
            var obj = Instantiate(prefab, position, Quaternion.Euler(0, 90.0f, 0));
            obj.AddComponent(typeof(MoveLeftToRight));
            obj.AddComponent(typeof(TimeDestroyer));
        }
        else if(type==2){ // flower
            position.y = 1f;
            var obj = Instantiate(prefab, position, Quaternion.identity);
            obj.AddComponent(typeof(Rotate));
            obj.AddComponent(typeof(TimeDestroyer));
        }
    }
}
