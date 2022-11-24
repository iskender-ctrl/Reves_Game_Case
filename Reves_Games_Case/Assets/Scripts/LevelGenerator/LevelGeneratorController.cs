using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorController : MonoBehaviour
{
    public GameObject[] runPartPrefabs, obstacles, coins;
    [SerializeField] List<GameObject> newRunPartList = new List<GameObject>();
    public GameObject coin, newRunPurt, obstacle;
    Vector3 newPosition, lastPosition;
    public int runPartCount, instantiateIndex, levelNumber;
    int targetRunPartCountIndex;
    public float runPartObjectDistance;
    bool canContinue;
    PlatformPart platformPart;
    void Start()
    {
        InstantiatePlatform();
        InstantiateCoins();
        InstantiateObstacles();
    }
    void InstantiatePlatform()
    {
        for (int i = 0; i < runPartCount; i++)
        {
            targetRunPartCountIndex++;

            if (GameObject.Find("RunPart-Start(Clone)") == null)
            {
                instantiateIndex = 0;
            }
            else
            {
                int random = Random.Range(1, runPartPrefabs.Length - 1);
                instantiateIndex = random;
            }

            if (targetRunPartCountIndex == runPartCount)
            {
                instantiateIndex = runPartPrefabs.Length - 1;
            }

            newPosition = InstantiateFunction(runPartPrefabs[instantiateIndex].gameObject, new Vector3(0, 0, lastPosition.z + runPartObjectDistance), runPartPrefabs[instantiateIndex].gameObject.transform.rotation);
            lastPosition = newPosition;

            if (newRunPurt.gameObject.tag == "RunPlatform")
            {
                newRunPartList.Add(newRunPurt);
            }
        }
    }
    void InstantiateCoins()
    {
        for (int i = 0; i < newRunPartList.Count; i++)
        {
            platformPart = newRunPartList[i].transform.GetComponent<PlatformPart>();
            InstantiateObstacleAndCoins(coin, platformPart.coinPoint, coins);
        }
    }
    void InstantiateObstacles()
    {
        for (int i = 0; i < newRunPartList.Count; i++)
        {
            platformPart = newRunPartList[i].transform.GetComponent<PlatformPart>();
            InstantiateObstacleAndCoins(obstacle, platformPart.obstaclePoint, obstacles);
        }
    }
    void InstantiateObstacleAndCoins(GameObject targetObject, List<GameObject> targetArray, GameObject[] prefabObjects)
    {
        for (int j = 0; j < levelNumber; j++)
        {
            targetObject = targetArray[Random.Range(0, targetArray.Count)];
            targetArray.Remove(targetObject);
            int randomObstacle = Random.Range(0, prefabObjects.Length);
            InstantiateFunction(prefabObjects[randomObstacle], targetObject.transform.position, Quaternion.Euler(prefabObjects[randomObstacle].transform.eulerAngles.x, -targetObject.transform.localEulerAngles.y, prefabObjects[randomObstacle].transform.eulerAngles.z));
        }
    }
    Vector3 InstantiateFunction(GameObject spawnObj, Vector3 position, Quaternion rotation)
    {
        newRunPurt = Instantiate(spawnObj, position, rotation);
        return position;
    }
}
