using UnityEngine;

public class SuperPower : MonoBehaviour
{
    public float timer = 2f;
    private GameObject[] obstacles;

    void Start()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject o in obstacles)
        {
            if (o != null)
            {
                BoxCollider m_Collider;
                m_Collider = o.GetComponent<BoxCollider>();
                m_Collider.enabled = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            foreach (GameObject o in obstacles)
            {
                if (o != null)
                {
                    BoxCollider m_Collider;
                    m_Collider = o.GetComponent<BoxCollider>();
                    m_Collider.enabled = true;
                }
            }
        }
    }
}
