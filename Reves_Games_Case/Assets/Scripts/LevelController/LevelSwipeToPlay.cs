using UnityEngine;

public class LevelSwipeToPlay : MonoBehaviour
{
    public GameObject swipeTextAndHandIcon;
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MainCoinHitCollisionObstacle.instance.isHitToObstacle)
        {
            if (Input.touchCount == 1)
            {
                Time.timeScale = 1;
                swipeTextAndHandIcon.SetActive(false);
            }
        }
    }
}
