using UnityEngine;

public class MainCoinMovement : MonoBehaviour
{
    Vector3 transformRotation;
    [SerializeField] float turnSpeed = 5;
    [SerializeField] float moveForwardSpeed = 5;

    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MainCoinHitCollisionObstacle.instance.cantMove)
        {
            transform.Translate(0, 0, moveForwardSpeed * Time.deltaTime);

            if (Input.touchCount == 1)
            {
                CoinMoveWithRotation();
            }
        }
    }
    void CoinMoveWithRotation()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            Vector3 NewTouchPosition = touch.deltaPosition;
            transformRotation = new Vector3(transformRotation.x, NewTouchPosition.x * turnSpeed * Time.deltaTime, transformRotation.z);
            transform.eulerAngles = transformRotation + transform.eulerAngles;
        }
    }
}
