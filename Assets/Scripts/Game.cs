using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Game : MonoBehaviour
{
    AudioSource bgmusicsrc;
    AudioSource effectsrc;
    AudioClip coinsound;
    AudioClip gameoversound;
    bool setLevel = true;
    private int basicPoint = 100;
    private IEnumerator coroutine;
    private int _score;
    private int Score
    {
        get => _score;
        set
        {
            _score = value;
            EventManager.Instance.Fire(new ScoreChanged(_score));
        }
    }
    private int _coin;
    private int Coin
    {
        get => _coin;
        set
        {
            _coin = value;
            EventManager.Instance.Fire(new CoinChanged(_coin));
        }
    }
    public GameState _gameState = GameState.Over;
    public GameState State
    {
        get => _gameState;
        set
        {
            _gameState = value;
            EventManager.Instance.Fire(new GameStateChanged(_gameState, Score));
        }
    }
    private void Start()
    {
        var camera = GameObject.FindGameObjectWithTag("MainCamera");
        bgmusicsrc = camera.GetComponent<AudioSource>();
        var player = GameObject.FindGameObjectWithTag("Player");
        effectsrc = player.GetComponent<AudioSource>();
        Score = 0;
        Coin = 0;
        State = GameState.Easy;
        coroutine = WaitAndScore(1.0f);
        StartCoroutine(coroutine);
        EventManager.Instance.AddHandler<EnemyDied>(OnEnemyDied);
        EventManager.Instance.AddHandler<GetCoin>(OnGetCoin);
        EventManager.Instance.AddHandler<PlayerDied>(OnPlayerDied);
        EventManager.Instance.AddHandler<GameStateChanged>(OnGameStateChanged);
        coinsound = Resources.Load<AudioClip>("SoundEffect/coinsound");
        gameoversound = Resources.Load<AudioClip>("SoundEffect/gameoversound");
    }
    private void Update()
    {
        if(Score>=2000 && setLevel){
            State = GameState.Difficult;
            setLevel = false;
        }
    }
    private IEnumerator WaitAndScore(float waitTime)
    {
        while (State!=GameState.Over)
        {
            yield return new WaitForSeconds(waitTime);
            Score += basicPoint;
            var player = GameObject.FindGameObjectWithTag("Player");
            if(player.GetComponent<MoveForward>()!=null)
                player.GetComponent<MoveForward>().speed += 0.01f;
            var camera = GameObject.FindGameObjectWithTag("MainCamera");
            if (camera.GetComponent<MoveForward>() != null)
                camera.GetComponent<MoveForward>().speed += 0.01f;
        }
    }
    private void OnDestroy()
    {
        EventManager.Instance.RemoveHandler<EnemyDied>(OnEnemyDied);
        EventManager.Instance.RemoveHandler<GetCoin>(OnGetCoin);
        EventManager.Instance.RemoveHandler<PlayerDied>(OnPlayerDied);
        EventManager.Instance.RemoveHandler<GameStateChanged>(OnGameStateChanged);

    }
    private void OnPlayerDied(GameEvent evt)
    {
        State = GameState.Over;
    }
    private void OnEnemyDied(GameEvent evt)
    {
        var enemydiedevent = evt as EnemyDied;
        Score += enemydiedevent.PointValue;
    }
    private void OnGetCoin(GameEvent evt)
    {
        var getcoinevt = evt as GetCoin;
        Coin += 1;
        Score += getcoinevt.PointValue;
        SoundManager.instance.Play(effectsrc,coinsound);
    }
    private void OnGameStateChanged(GameEvent evt)
    {
        var gamestatechangedevent = evt as GameStateChanged;
        if (gamestatechangedevent.State == GameState.Over)
        {
            StopCoroutine(coroutine);
            SoundManager.instance.PlayMusic(bgmusicsrc,gameoversound);
            RecordHighestScore(Score);
            Invoke("LoadSceneAftertime", 5);
        }
        if (gamestatechangedevent.State == GameState.Difficult)
        {
            basicPoint = 300;
        }
    }
    private void LoadSceneAftertime()
    {
        SceneManager.LoadScene("GAMEOVER");
    }
    private void RecordHighestScore(int score)
    {
        int highest = PlayerPrefs.GetInt("Player Score");
        if(score>highest)
            PlayerPrefs.SetInt("Player Score", score);
    }
}
