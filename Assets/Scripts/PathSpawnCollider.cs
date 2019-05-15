using UnityEngine;
using System.Collections;

public class PathSpawnCollider : MonoBehaviour {

    public float positionY = 0.81f;
    public Transform[] PathSpawnPoints;
    public GameObject Path;
    public GameObject DangerousBorder;

    void OnTriggerEnter(Collider hit)
    {

        //player has hit the collider
        if (hit.gameObject.tag == "Player")
        {
            //find whether the next path will be straight, left or right
            int randomSpawnPoint = Random.Range(0, PathSpawnPoints.Length);
            for (int i = 0; i < PathSpawnPoints.Length; i++)
            {
                //instantiate the path, on the set rotation
                if (i == randomSpawnPoint)
                {
                    var path=Instantiate(Path, PathSpawnPoints[i].position, PathSpawnPoints[i].rotation);
                    GameObject game = GameObject.Find("Game");
                    if(game.GetComponent<Game>().State == GameState.Easy)
                        path.GetComponentInChildren<StuffSpawner>().random_range=2;
                    else if(game.GetComponent<Game>().State == GameState.Difficult)
                        path.GetComponentInChildren<StuffSpawner>().random_range=3;
                }

            }
            
        }
    }

}
