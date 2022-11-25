using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMainCoin : MonoBehaviour
{
    GameObject mainCoin;
    public float mainCoinDistance, moveSpeed;
    void Start()
    {
        mainCoin = GameObject.FindGameObjectWithTag("MainCoin");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, mainCoin.transform.position);
        if (distance < mainCoinDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, mainCoin.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
