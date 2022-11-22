using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorController : MonoBehaviour
{
    public GameObject[] runPartPrefabs;
    public GameObject startPrefabs, endPrefabs;
    Vector3 newPosition, lastPosition;
    [SerializeField] List<GameObject> platformObjectsList = new List<GameObject>();
    public int runPartCount, lastAddedObject;
    public float objectDistance;
    void Start()
    {
        InstantiatePlatform();
    }
    void InstantiatePlatform()
    {
        GameObject startObject = Instantiate(startPrefabs, Vector3.zero, Quaternion.identity);
        platformObjectsList.Add(startObject);

        for (int i = 0; i < runPartCount; i++)
        {
            int random = Random.Range(0, runPartPrefabs.Length);
            newPosition = platformObjectsList[i].transform.position;
            GameObject newObject = Instantiate(runPartPrefabs[random].gameObject, new Vector3(0, 0, newPosition.z + objectDistance), runPartPrefabs[random].gameObject.transform.rotation);
            platformObjectsList.Add(newObject);
            lastAddedObject = i;
        }

        lastPosition = platformObjectsList[lastAddedObject].transform.position;
        GameObject endObject = Instantiate(endPrefabs, new Vector3(0, 0, lastPosition.z + objectDistance + 10), endPrefabs.transform.rotation);
        platformObjectsList.Add(endObject);
    }
}
