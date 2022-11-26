using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailController : MonoBehaviour
{
    public GameObject trayAgainPanel;

    // Update is called once per frame
    void Update()
    {
        if (MainCoinHitCollisionObstacle.instance.isHitToObstacle)
        {
            StartCoroutine(OpenFailPanel());
        }
    }
    IEnumerator OpenFailPanel()
    {
        yield return new WaitForSeconds(2);
        trayAgainPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
