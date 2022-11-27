using System.Collections;
using UnityEngine;

public class StairCollisionController : MonoBehaviour
{
    Rigidbody rb;
    public GameObject winPanelObject;
    private void Awake()
    {
        winPanelObject = GameObject.FindWithTag("UIWinLevelPanel");
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();


        if (winPanelObject.activeInHierarchy)
        {
            winPanelObject.SetActive(false);
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Stair")
        {
            CoinStackMechanic.instance.coinsStack.Remove(this.gameObject);
            rb.useGravity = true;
            rb.AddForce(new Vector3(Random.Range(-1, 1), 0, 0), ForceMode.Impulse);

            if (CoinStackMechanic.instance.coinsStack.Count <= 1)
            {
                StartCoroutine(OpenWinPanel());
            }
        }
    }
    IEnumerator OpenWinPanel()
    {
        yield return new WaitForSeconds(1);
        print("tövbe tövbe");
        winPanelObject.SetActive(true);
    }
}
