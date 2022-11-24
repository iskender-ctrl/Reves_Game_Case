using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    Quaternion transformRotation;
    [SerializeField] float turnSpeed = 5;
    [SerializeField] float moveForwardSpeed = 5;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveForwardSpeed * Time.deltaTime, 0, 0);

        if (Input.touchCount == 1)
        {
            CoinMoveWithRotation();
        }
    }
    void CoinMoveWithRotation()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            Vector3 NewTouchPosition = touch.deltaPosition;
            transformRotation = Quaternion.Euler(transformRotation.x, NewTouchPosition.x * turnSpeed * Time.deltaTime, transformRotation.z);
            transform.rotation = transformRotation * transform.rotation;
        }
    }
}
