using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Team 
{
    protected ColorContainer theme = new ColorContainer();

    abstract public string Name { get; }

    abstract public Color TeamColor { get; }
}
public class Player : Team
{
    public override string Name => "Player";

    public override Color TeamColor => Color.red;
}

public class Neutral : Team
{
    public override string Name => "Neutral";

    public override Color TeamColor => base.theme.neutral;

}

public class Bot : Team
{
    public override string Name => "Bot";

    public override Color TeamColor => Random.value > 0.5f ? theme.botBlue : theme.botYellow;
  
}

public enum TeamSelector
{
    Neutral = 0,

    Player = 1,

    Bot = 2,
}

public class ColorContainer
{
    public Color neutral = new Color(0.5137f, 0.9254902f, 0.7372549f, 1f);

    public Color botBlue = new Color(0.4352941F, 0.682353F, 0.9254902F);

    public Color botYellow = new Color(0.8392157F, 0.8509804F, 0.2784314F);

}


