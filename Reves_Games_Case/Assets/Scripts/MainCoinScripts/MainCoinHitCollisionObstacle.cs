using UnityEngine;

public class MainCoinHitCollisionObstacle : MonoBehaviour
{
    public static MainCoinHitCollisionObstacle instance;
    public bool isHitToObstacle;
    public bool cantMove = true;
    private void Awake()
    {
        instance = this;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Obstacle")
        {
            isHitToObstacle = true;
            cantMove = true;

            for (int i = 0; i < CoinStackMechanic.instance.coinsStack.Count; i++)
            {
                Rigidbody rb = CoinStackMechanic.instance.coinsStack[i].GetComponent<Rigidbody>();
                BoxCollider boxCollider = CoinStackMechanic.instance.coinsStack[i].GetComponent<BoxCollider>();
                rb.AddForce(new Vector3(Random.Range(-2, 2), 3, Random.Range(-2, 2)), ForceMode.Impulse);
                boxCollider.isTrigger = false;
                rb.useGravity = true;
            }
        }
    }
}
