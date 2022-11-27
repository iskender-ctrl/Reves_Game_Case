using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairCollisionController : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Stair")
        {

            CoinStackMechanic.instance.coinsStack.Remove(this.gameObject);
            rb.useGravity = true;
            rb.AddForce(new Vector3(Random.Range(-1, 1), 0, 0), ForceMode.Impulse);
        }
    }
}
