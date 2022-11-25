using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinStackMechanic : MonoBehaviour
{
    public List<GameObject> coinsStack = new List<GameObject>();
    public List<Vector3> positionCoins = new List<Vector3>();
    public float coinsStackDistance, speed;
    public int gap = 20;
    private void Start()
    {
        coinsStack.Add(gameObject);
    }
    private void Update()
    {
        positionCoins.Insert(0, transform.position);
        int i = 0;
        foreach (GameObject coin in coinsStack)
        {
            Vector3 position = positionCoins[Mathf.Min(i * gap, positionCoins.Count - 1)];
            Vector3 positionForward = position - coin.transform.position;
            coin.transform.position += positionForward * speed * Time.deltaTime;
            coin.transform.LookAt(position);
            i++;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            coinsStack.Add(other.gameObject);
            other.gameObject.GetComponent<MoveToMainCoin>().enabled = false;
        }
    }
}
