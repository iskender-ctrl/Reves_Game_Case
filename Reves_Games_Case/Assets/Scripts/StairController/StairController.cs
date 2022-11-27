using System.Collections.Generic;
using UnityEngine;

public class StairController : MonoBehaviour
{
    public static StairController instance;
    public List<GameObject> stairObjects = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
}
