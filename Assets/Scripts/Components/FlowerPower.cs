using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPower : MonoBehaviour
{
    public float timer = 10.0f;
    Material[] mat = new Material[4];
    Rigidbody fireball;
    AudioSource effectsrc;
    AudioClip firesound;
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        effectsrc = player.GetComponent<AudioSource>();
        fireball = Resources.Load<Rigidbody>("Prefabs/fire");
        mat[0] = Resources.Load<Material>("Materials/MarioCap2");
        mat[1] = Resources.Load<Material>("Materials/MarioBody2");
        mat[2] = Resources.Load<Material>("Materials/MarioCap.0");
        mat[3] = Resources.Load<Material>("Materials/MarioBody.0");
        firesound = Resources.Load<AudioClip>("SoundEffect/fireballsound");
        GetComponentInChildren<Renderer>().materials[7].mainTexture = mat[0].mainTexture;
        GetComponentInChildren<Renderer>().materials[8].mainTexture = mat[1].mainTexture;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.instance.Play(effectsrc,firesound);
            Vector3 shootDir = new Vector3(1.0f,0.0f,0.0f);
            Rigidbody fireclone = (Rigidbody)Instantiate(fireball, this.transform.position+new Vector3(-1.0f,2.75f,0f), this.transform.rotation);
            float speed = gameObject.GetComponent<MoveForward>().speed / 0.4f;
            fireclone.AddForce(shootDir*(2000.0f*speed));   
        }
        if (timer <= 0){
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        GetComponentInChildren<Renderer>().materials[7].mainTexture = mat[2].mainTexture;
        GetComponentInChildren<Renderer>().materials[8].mainTexture = mat[3].mainTexture;
    }
}
