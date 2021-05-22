using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


[RequireComponent(typeof(BoxCollider2D))]
public class Cell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private GameObject selectIcon;

    [SerializeField] Inject Injection;

    private GameObject selectCirc;

    [SerializeField] private SpriteRenderer center;

    [SerializeField] private CellData type;

    [SerializeField] private TMP_Text hpView;

    [SerializeField] private int hp;

    LineRenderer line;

    Vector3 clickPos;

    private bool corutineRunning = false;

    public static event System.Action TeamChange;

    // Team variables
    public TeamSelector teamSelect;
    private Team team;

    public Team Team => team;

    // Dependent variables 
    private int maxHP;
    private float size;

    // List of PlayerCell
    public static List<Cell> OnSelect = new List<Cell>();
    public static Cell target;

    // Start is called before the first frame update
    void Awake()
    {
        print(clickPos);
        line = GetComponent<LineRenderer>();

        maxHP = type.MaxHP;
        size = type.Size;

        if (maxHP < hp)
            hp = maxHP;

        HpTextUpdate();

        Scale(this.gameObject);

        TeamSelect();
    }

    public void TeamSelect()
    {
        //Ну и это тоже
        switch (teamSelect)
        {
            case TeamSelector.Neutral:
                team = new Neutral();
                break;

            case TeamSelector.Player:
                team = new Player();
                break;

            case TeamSelector.Bot:
                team = new Bot();
                break;
        }

        center.color = team.TeamColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        eventData.pointerPress = this.gameObject;

        if (team is Player)
        {
            if (!OnSelect.Contains(this))
                clickPos = eventData.position;

            Select();
            SelectTargetOnTeam();
        }
        else
            target = this;

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (team is Player && clickPos != Vector3.zero)
        {
            target = null;
            clickPos = Vector3.zero;
        }
        else
            target = this;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        target = null;
        eventData.pointerPress = null;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (this == target)
        {
            foreach (Cell x in OnSelect)
            {
                if (x != target)
                {
                    x.Shoot(target);
                }
            }

            ClearSelect();
            target = null;
        }
    }

    public void Shoot(Cell target)
    {
        if (this != target)
        {
            int x = Mathf.CeilToInt(hp / 2);
            hp -= x;

            HpTextUpdate();
            HPChecker();

            for (var i = 0; i < x; i++)
            {
                Vector3 ranodmazi = new Vector3(transform.localPosition.x + Random.Range(-0.25F, 0.25F), transform.localPosition.y + Random.Range(-0.25F, 0.25F));

                var z = Instantiate(Injection, ranodmazi, transform.localRotation);
                z.Init(team);
                z.MovingToTarget(target);
            }
        }

    }

    public void Taking(Inject obj)
    {
        if (hp == 0)
        {
            this.team = obj.team;
            center.color = team.TeamColor;

            TeamChange?.Invoke();
        }

        if (obj.team == this.team)
            hp++;
        else
            hp--;

        Destroy(obj.gameObject);

        HpTextUpdate();

        HPChecker();
    }

    public static void ClearSelect()
    {
        if (OnSelect.Count > 0)
        {
            OnSelect.ForEach(Cell => Cell.Unselect());
            OnSelect.Clear();
        }
    }

    private void HPChecker()
    {
        if (team is Neutral)
            return;

        if (!corutineRunning)
            StartCoroutine(HpUp());
    }

    public void Select()
    {
        if (!OnSelect.Contains(this))
        {
            OnSelect.Add(this);
            SelectUI();
        }
    }

    public void SelectTargetOnTeam()
    {
        if (OnSelect.Count > 1)
            target = this;
    }

    private void SelectUI()
    {
        if (!selectCirc)
        {
            selectCirc = Instantiate(selectIcon, transform.localPosition, transform.localRotation);
            Scale(selectCirc);
        }

        line.enabled = true;
    }

    public void Unselect()
    {
        Destroy(selectCirc);
        LineFade();
    }

    private void Scale(GameObject obj)
    {
        Vector3 scale = obj.transform.localScale;

        scale.x *= size;
        scale.y *= size;

        obj.transform.localScale = scale;
    }

    private void HpTextUpdate()
    {
        hpView.text = hp == 0 ? "" : hp.ToString();
    }

    IEnumerator HpUp()
    {
        if (hp < maxHP)
        {
            corutineRunning = true;

            while (hp < maxHP)
            {
                this.hp++;

                yield return new WaitForSeconds(Random.Range(1.5f, 2f));

                HpTextUpdate();
            }
        }

        if (hp > maxHP)
        {
            corutineRunning = true;

            while (hp > maxHP)
            {
                this.hp -= 2;

                yield return new WaitForSeconds(Random.Range(1.5f, 2f));

                HpTextUpdate();
            }
        }

        corutineRunning = false;
    }

    public void LineToAim(Vector3 lol)
    {
        line.enabled = true;

        Vector3[] getToThePointMotherfacker;

        getToThePointMotherfacker = new Vector3[2] { transform.position, Camera.main.ScreenToWorldPoint(lol) };

        line.SetPositions(getToThePointMotherfacker);
    }

    public void LineFade()
    {
        line.enabled = false;
    }
}
