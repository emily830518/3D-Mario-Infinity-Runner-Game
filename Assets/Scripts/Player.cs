using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    AudioSource effectsrc;
    AudioClip lifesound;
    AudioClip flowerpowersound;
    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        effectsrc = player.GetComponent<AudioSource>();
        gameObject.AddComponent(typeof(Lifetime));
        gameObject.AddComponent(typeof(MoveForward));
        gameObject.AddComponent(typeof(Controlledbykeyboard));
        lifesound = Resources.Load<AudioClip>("SoundEffect/lifesound");
        flowerpowersound = Resources.Load<AudioClip>("SoundEffect/flowerpowersound");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boo")
        {
            if (gameObject.GetComponent<FlowerPower>() != null)
            {
                Destroy(gameObject.GetComponent<FlowerPower>());
                gameObject.AddComponent(typeof(Flash));
            }
            else
            {
                gameObject.GetComponent<Lifetime>().lifeLeft--;
                EventManager.Instance.Fire(new LifeChanged(gameObject.GetComponent<Lifetime>().lifeLeft));
                if (gameObject.GetComponent<Lifetime>().lifeLeft > 0)
                {
                    gameObject.AddComponent(typeof(Flash));
                }
            }
        }
        else if (collision.gameObject.tag == "mushroom")
        {
            SoundManager.instance.Play(effectsrc,lifesound);
            gameObject.GetComponent<Lifetime>().lifeLeft++;
            int life = gameObject.GetComponent<Lifetime>().lifeLeft;
            EventManager.Instance.Fire(new LifeChanged(life));
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "coin")
        {
            EventManager.Instance.Fire(new GetCoin(100));
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "flower")
        {
            if (gameObject.GetComponent<FlowerPower>() == null)
            {
                SoundManager.instance.Play(effectsrc,flowerpowersound);
                gameObject.AddComponent(typeof(FlowerPower));
            }
            Destroy(collision.gameObject);
        }
    }
}
