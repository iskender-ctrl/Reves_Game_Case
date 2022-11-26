using UnityEngine;
using DG.Tweening;
public class DoorController : MonoBehaviour
{
    public float targetPos,duration;
    public int loop;
    void Start()
    {
        transform.DOMoveY(targetPos, duration).SetLoops(loop, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
