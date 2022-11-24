using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwipeToPlay : MonoBehaviour
{
    [SerializeField] GameObject swipeTextAndHandIcon;
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Time.timeScale = 1;
            swipeTextAndHandIcon.SetActive(false);
        }
    }
}
