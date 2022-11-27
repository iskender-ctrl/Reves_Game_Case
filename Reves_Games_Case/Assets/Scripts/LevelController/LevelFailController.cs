using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailController : MonoBehaviour
{
    public GameObject trayAgainPanel, mainCoin;
    Vector3 firstPos, firstRot;
    private void Start()
    {
        mainCoin = GameObject.FindGameObjectWithTag("MainCoin");
        firstPos = mainCoin.transform.position;
        firstRot = mainCoin.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (MainCoinHitCollisionObstacle.instance.isHitToObstacle || mainCoin.transform.position.y < firstPos.y || mainCoin.transform.rotation.z + 1 < firstRot.z)
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
