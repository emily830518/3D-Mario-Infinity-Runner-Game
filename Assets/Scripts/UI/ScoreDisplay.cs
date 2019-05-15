using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private void Start()
    {
        // Add a handler to find out when the score has changed
        EventManager.Instance.AddHandler<ScoreChanged>(OnScoreChanged);
    }

    private void OnDestroy()
    {
        // Always make sure you remove registered handlers when you're done
        // Otherwise you can end up with memory leaks and odd bugs
        EventManager.Instance.RemoveHandler<ScoreChanged>(OnScoreChanged);
    }

    private void OnScoreChanged(GameEvent evt)
    {
        var scorechangedevent = evt as ScoreChanged;
        GetComponent<Text>().text = "SCORE " + scorechangedevent.NewScore.ToString();
    }
}
