using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    private void Start()
    {
        // Add a handler to find out when the score has changed
        EventManager.Instance.AddHandler<CoinChanged>(OnCoinChanged);
    }

    private void OnDestroy()
    {
        // Always make sure you remove registered handlers when you're done
        // Otherwise you can end up with memory leaks and odd bugs
        EventManager.Instance.RemoveHandler<CoinChanged>(OnCoinChanged);
    }

    private void OnCoinChanged(GameEvent evt)
    {
        var coinchangedevent = evt as CoinChanged;
        GetComponent<Text>().text = "x " + coinchangedevent.NewCoin.ToString();
    }
}
