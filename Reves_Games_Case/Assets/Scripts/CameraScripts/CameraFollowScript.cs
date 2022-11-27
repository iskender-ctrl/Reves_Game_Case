using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform target;
    public Vector3 Offset;
    public float SmoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCoin").transform;
        transform.position = target.position + Offset;
    }
    private void LateUpdate()
    {
        if (CoinStackMechanic.instance.coinsStack.Count > 0)
        {
            target = CoinStackMechanic.instance.coinsStack[0].transform;
        }
        Vector3 targetPosition = target.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);
    }
}
