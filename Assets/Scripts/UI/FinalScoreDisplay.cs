using UnityEngine;
using UnityEngine.UI;


public class FinalScoreDisplay : MonoBehaviour
{
    int final_score;
    // Start is called before the first frame update
    void Start()
    {
        final_score=PlayerPrefs.GetInt("Player Score");
        GetComponent<Text>().text = final_score.ToString();
    }
}
