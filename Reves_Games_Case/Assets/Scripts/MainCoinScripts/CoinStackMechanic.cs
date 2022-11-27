using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinStackMechanic : MonoBehaviour
{
    public static CoinStackMechanic instance;
    public List<GameObject> coinsStack = new List<GameObject>();
    public List<Vector3> positionCoins = new List<Vector3>();
    public float coinsStackDistance, speed, endenPlatformStackSpeed;
    public int gap = 20;
    public bool stackOnEndedPlatform, hitToEndedPlatform;
    Vector3 endenPlatform;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        coinsStack.Add(gameObject);
    }
    private void Update()
    {
        if (!MainCoinHitCollisionObstacle.instance.cantMove)
        {
            MoveOnPlatform();
        }
        else if (hitToEndedPlatform)
        {
            MoveOnEndLine();
        }
    }
    // Move On Platform
    void MoveOnPlatform()
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
    //Stack On End Platform. Stack Coin On Main Coin And Move To Stair
    void MoveOnEndLine()
    {
        if (stackOnEndedPlatform)
        {
            for (int i = 0; i < coinsStack.Count; i++)
            {
                coinsStack[i].transform.position = Vector3.Lerp(coinsStack[i].transform.position, new Vector3(StairController.instance.stairObjects[i].transform.position.x / 2, StairController.instance.stairObjects[i].transform.position.y + 1, coinsStack[0].transform.position.z), endenPlatformStackSpeed * Time.deltaTime);
                coinsStack[i].transform.rotation = Quaternion.Euler(0, 0, 0);
                coinsStack[i].transform.GetComponent<BoxCollider>().isTrigger = false;
                coinsStack[i].transform.GetComponent<Rigidbody>().useGravity = false;
                StartCoroutine(ResetStackOnEndedPlatform());
            }
        }
        else
        {
            for (int i = 0; i < coinsStack.Count; i++)
            {
                coinsStack[i].transform.Translate(0, 0, 10 * Time.deltaTime);
                coinsStack[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            }
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
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ended")
        {
            endenPlatform = other.transform.position;
            stackOnEndedPlatform = true;
            hitToEndedPlatform = true;

            MainCoinHitCollisionObstacle.instance.cantMove = true;
        }
    }
    IEnumerator ResetStackOnEndedPlatform()
    {
        yield return new WaitForSeconds(0.5f);
        //coinsStack.Reverse();
        stackOnEndedPlatform = false;
    }
}
