using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottas : MonoBehaviour
{

    List<Cell> SelectedOnBot = new List<Cell>();
    List<Cell> targetList = new List<Cell>();

    Cell botTarget;

    GameObject[] Cells;

    bool run = false;

    // Start is called before the first frame update
    void Start()
    {
        Cells = GameObject.FindGameObjectsWithTag("Cell");
    }

    // Update is called once per frame
    void Update()
    {
        BottasRun();
    }

    private void Seek()
    {
        foreach (GameObject GO in Cells)
        {
            Cell z;

            if (GO.TryGetComponent<Cell>(out z))
            {
                if (z.Team is Bot)
                    SelectedOnBot.Add(z);
                else
                    targetList.Add(z);
            }
        }
    }

    private void SeekTarget()
    {

        int x = Random.Range(0, targetList.Count);

        botTarget = targetList[x];

        targetList.Clear();

    }

    private void Destroy()
    {
        print(SelectedOnBot.Count);

        foreach (Cell x in SelectedOnBot)
        {
            if (SelectedOnBot.Count <= 1)
                x.Shoot(botTarget);
            else
            {
                if (Random.value > 0.5f)
                {
                    x.Shoot(botTarget);
                }
                else
                    continue;
            }
        }

        SelectedOnBot.Clear();
    }

    private void BottasRun()
    {
        if (!run)
            StartCoroutine(BottasBeing());
    }

    IEnumerator BottasBeing()
    {
        run = true; 

        Seek();

        yield return new WaitForSeconds(Random.Range(3f, 7f));
        SeekTarget();

        yield return new WaitForSeconds(Random.Range(3f, 7f));
        Destroy();

        yield return new WaitForSeconds(Random.Range(3f, 7f));

        run = false;
    }

}
