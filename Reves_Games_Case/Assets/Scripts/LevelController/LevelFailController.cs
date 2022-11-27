using System.Collections;
using UnityEngine;

public class LevelFailController : MonoBehaviour
{
    public GameObject trayAgainPanel, mainCoin;
    private void Start()
    {
        mainCoin = GameObject.FindGameObjectWithTag("MainCoin");
    }

    // Update is called once per frame
    void Update()
    {
        if (MainCoinHitCollisionObstacle.instance.isHitToObstacle || mainCoin.transform.position.y < 0)
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
