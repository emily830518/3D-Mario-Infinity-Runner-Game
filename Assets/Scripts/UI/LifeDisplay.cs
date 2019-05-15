using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    private void Start()
    {
        // Add a handler to find out when the score has changed
        EventManager.Instance.AddHandler<LifeChanged>(OnLifeChanged);
    }

    private void OnDestroy()
    {
        // Always make sure you remove registered handlers when you're done
        // Otherwise you can end up with memory leaks and odd bugs
        EventManager.Instance.RemoveHandler<LifeChanged>(OnLifeChanged);
    }

    private void OnLifeChanged(GameEvent evt)
    {
        var lifechangedevent = evt as LifeChanged;
        GetComponent<Text>().text = "x " + lifechangedevent.NewLife.ToString();
    }
}
