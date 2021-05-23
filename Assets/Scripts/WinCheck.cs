using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCheck : MonoBehaviour
{
    [SerializeField] FinalScreen screen;

    public static List<Cell> Cells;

    bool botWin;
    bool playerWin;

    void Awake()
    {
        Cells = new List<Cell>();

        botWin = false;
        playerWin = false;

        Cell.TeamChange += OnTeamChange;

        foreach (GameObject GO in GameObject.FindGameObjectsWithTag("Cell"))
        {
            Cell z;

            if (GO.TryGetComponent<Cell>(out z))
            {
                Cells.Add(z);
            }
        }
    }

    public void OnTeamChange()
    {
        botWin = true;
        playerWin = true;

        foreach (Cell x in Cells)
        {
            if (x.Team is Player)
                botWin = false;

            if (x.Team is Bot)
                playerWin = false;
        }

        Destiny();

    }

    private void Destiny()
    {
        if (botWin && !playerWin)
            screen.Lose();
        else if (!botWin && playerWin)
            screen.Win();

        Debug.Log(botWin + " " + playerWin);
    }

    private void OnDestroy()
    {
        Cell.TeamChange -= OnTeamChange;
    }

}
