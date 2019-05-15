using UnityEngine;

public class Bullets : MonoBehaviour
{
    float ExistTime = 1.5f;

    // Update is called once per frame
    void Update()
    {
        ExistTime -= Time.deltaTime;
        if (ExistTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "terrain" && collision.gameObject.tag != "Player")
        {
            if(collision.gameObject.tag == "Boo"){
                EventManager.Instance.Fire(new EnemyDied(200));
                Destroy(collision.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
}
