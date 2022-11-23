using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorController : MonoBehaviour
{
    public GameObject[] runPartPrefabs, obstacles;
    [SerializeField] List<GameObject> newRunPartList = new List<GameObject>();
    public GameObject coin, newRunPurt;
    Vector3 newPosition, lastPosition;
    public int runPartCount, instantiateIndex, levelNumber;
    int targetRunPartCountIndex;
    public float runPartObjectDistance;
    bool canContinue;
    void Start()
    {
        InstantiatePlatform();
        InstantiateObstacleAndCoins();
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
    void InstantiateObstacleAndCoins()
    {
        for (int i = 0; i < newRunPartList.Count; i++)
        {
            PlatformPart platformPart = newRunPartList[i].transform.GetComponent<PlatformPart>();
            GameObject coinPoint = platformPart.coinPoint[Random.Range(0, platformPart.coinPoint.Length)];
            InstantiateFunction(coin, coinPoint.transform.position, coin.transform.rotation);

            GameObject point = platformPart.obstaclePoint[Random.Range(0, platformPart.obstaclePoint.Length)];
            int randomObstacle = Random.Range(0, obstacles.Length);
            InstantiateFunction(obstacles[randomObstacle], point.transform.position, Quaternion.Euler(obstacles[randomObstacle].transform.eulerAngles.x, -point.transform.localEulerAngles.y, obstacles[randomObstacle].transform.eulerAngles.z));
        }
    }
    Vector3 InstantiateFunction(GameObject spawnObj, Vector3 position, Quaternion rotation)
    {
        newRunPurt = Instantiate(spawnObj, position, rotation);
        return position;
    }
}
