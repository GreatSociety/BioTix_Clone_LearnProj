using UnityEngine;
using DG.Tweening;

public class Inject : MonoBehaviour
{
    public Team team;
    Sequence snakeScale;

    Tween movingToTarget;

    public void Awake()
    {
        snakeScale = DOTween.Sequence();
    }

    public void SnakeScale()
    {
        snakeScale.Append(transform.DOScale(new Vector3(2f, 0.5f), 0.2f));
        snakeScale.Append(transform.DOScale(new Vector3(1f, 1f), 0.2f));
        snakeScale.Append(transform.DOLocalMoveX(1f, 0.1f));
        snakeScale.SetLoops(30);
    }

    public void MovingToTarget(Cell target)
    {
        Vector3 lol = new Vector3(target.transform.position.x + Random.Range(-0.4F, 0.4F), target.transform.position.y + Random.Range(-0.4F, 0.4F));

        movingToTarget = transform.DOMove(lol, Random.Range(4f, 8f)).OnComplete(() => target.Taking(this));
        movingToTarget.SetEase(Ease.Linear);

        SnakeScale();

        snakeScale.Play();
    }

    public void Init(Team team)
    {
        this.team = team;
        GetComponent<SpriteRenderer>().color = team.TeamColor;
    }

    private void OnDestroy()
    {
        snakeScale.Complete();
        movingToTarget.Complete();
    }

}
