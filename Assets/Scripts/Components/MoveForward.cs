using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 0.4f;
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, 0, speed);
    }
}
