using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public int lifeLeft = 1;
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeLeft <= 0)
        {
            EventManager.Instance.Fire(new PlayerDied());
            this.gameObject.transform.Translate(new Vector3(0.0f,-0.6f,-1.0f));
            animator.SetBool("notDead", false);
            Destroy(GetComponent(typeof(MoveForward)));
            Destroy(GetComponent(typeof(Controlledbykeyboard)));
            Destroy(GetComponent(typeof(BoxCollider)));
            var camera = GameObject.FindGameObjectWithTag("MainCamera");
            Destroy(camera.GetComponent(typeof(MoveForward)));
            Destroy(this);
        }
    }
}
