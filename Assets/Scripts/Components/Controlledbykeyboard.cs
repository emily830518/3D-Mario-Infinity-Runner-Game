using UnityEngine;

public class Controlledbykeyboard : MonoBehaviour
{
    public float step = 6.0f;
    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = this.transform.position;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            newPos.z = Mathf.Round(newPos.z + step);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            newPos.z = Mathf.Round(newPos.z - step);
        if (newPos.z <= 9.0f && newPos.z >= -3.0f)
            this.transform.position = newPos;
    }
}
