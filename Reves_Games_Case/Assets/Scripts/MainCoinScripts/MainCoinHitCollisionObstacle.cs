using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCoinHitCollisionObstacle : MonoBehaviour
{
    public static MainCoinHitCollisionObstacle instance;
    List<GameObject> coinsList = new List<GameObject>();
    public bool isHitToObstacle;
    public bool canMove = true;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        coinsList = GetComponent<CoinStackMechanic>().coinsStack;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Obstacle")
        {
            isHitToObstacle = true;

            for (int i = 0; i < coinsList.Count; i++)
            {
                Rigidbody rb = coinsList[i].GetComponent<Rigidbody>();
                BoxCollider boxCollider = coinsList[i].GetComponent<BoxCollider>();
                rb.AddForce(new Vector3(Random.Range(-2, 2), 3, Random.Range(-2, 2)), ForceMode.Impulse);
                boxCollider.isTrigger = false;
                rb.useGravity = true;
            }
        }
    }
}
