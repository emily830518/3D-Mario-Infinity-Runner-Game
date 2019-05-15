public class ScoreChanged : GameEvent
{
    public int NewScore { get; }

    public ScoreChanged(int newScore)
    {
        NewScore = newScore;
    }
}

public class CoinChanged : GameEvent
{
    public int NewCoin { get; }

    public CoinChanged(int newCoin)
    {
        NewCoin = newCoin;
    }
}

public class LifeChanged : GameEvent
{
    public int NewLife { get; }

    public LifeChanged(int newLife)
    {
        NewLife = newLife;
    }
}

public class PlayerDied : GameEvent { }

public class EnemyDied : GameEvent
{
    public int PointValue { get; }

    public EnemyDied(int value)
    {
        PointValue = value;
    }
}

public class GetCoin : GameEvent
{
    public int PointValue { get; }

    public GetCoin(int value)
    {
        PointValue = value;
    }
}

public class GameStateChanged : GameEvent
{
    public GameState State { get; }
    public int FinalScore { get; }

    public GameStateChanged(GameState state, int finalScore)
    {
        State = state;
        FinalScore = finalScore;
    }
}