using UnityEngine;

public class Flash : MonoBehaviour
{
    public float timer = 2f;
    void Start()
    {
        gameObject.AddComponent(typeof(SuperPower));
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        GetComponentInChildren<Renderer>().enabled = !GetComponentInChildren<Renderer>().enabled;
        if (timer <= 0){
            GetComponentInChildren<Renderer>().enabled = true;
            Destroy(this);
        }
    }
}
