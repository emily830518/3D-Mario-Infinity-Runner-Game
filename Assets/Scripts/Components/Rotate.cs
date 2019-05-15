using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotate_angle = 3.0f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, rotate_angle, 0);
    }
}