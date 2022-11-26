using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public float turnSpeed;
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
