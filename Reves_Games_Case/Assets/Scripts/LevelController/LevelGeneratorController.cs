using UnityEngine;

public class LevelGeneratorController : MonoBehaviour
{
    public GameObject[] runStartPartPrefabs, runEndPartPrefabs, runPartPrefabs, obstacles, coins;
    public int runPartCount, levelNumber;
    public float runPartObjectDistance;
    public GameObject mainCoinPrefab;

    void Awake()
    {
        GameObject lastObject = CreateStartObject();
        Instantiate(mainCoinPrefab, new Vector3(lastObject.transform.position.x / 2, lastObject.transform.position.y + 1.228f, lastObject.transform.position.z / 2), mainCoinPrefab.transform.rotation);

        for (int i = 0; i < runPartCount; i++)
        {
            lastObject = CreatePartObject(lastObject);
        }
        CreateEndObject(lastObject);
    }

    GameObject CreateStartObject()
    {
        GameObject choosedStartObjectPrefab = runStartPartPrefabs[Random.Range(0, runStartPartPrefabs.Length)];

        return Instantiate(choosedStartObjectPrefab, Vector3.zero, choosedStartObjectPrefab.transform.rotation);
    }

    GameObject CreatePartObject(GameObject referenceObject)
    {
        GameObject choosedPartPrefab = runPartPrefabs[Random.Range(0, runPartPrefabs.Length)];
        GameObject currentPartObject = Instantiate(choosedPartPrefab, new Vector3(0, 0, referenceObject.transform.position.z + runPartObjectDistance), choosedPartPrefab.transform.rotation);

        PlatformPart platformPart = currentPartObject.GetComponent<PlatformPart>();
        for (int j = 0; j < levelNumber; j++)
        {
            CreatePartObjectCoin(platformPart);
            CreatePartObjectObstacle(platformPart);
        }

        return currentPartObject;
    }

    void CreatePartObjectCoin(PlatformPart platformPart)
    {
        GameObject targetCoin = platformPart.coinPoints[Random.Range(0, platformPart.coinPoints.Count)];
        platformPart.coinPoints.Remove(targetCoin);
        int randomCoin = Random.Range(0, coins.Length);
        Instantiate(coins[randomCoin], targetCoin.transform.position, Quaternion.Euler(coins[randomCoin].transform.eulerAngles.x, -targetCoin.transform.localEulerAngles.y, coins[randomCoin].transform.eulerAngles.z));
    }

    void CreatePartObjectObstacle(PlatformPart platformPart)
    {
        GameObject targetObstacle = platformPart.obstaclePoints[Random.Range(0, platformPart.obstaclePoints.Count)];
        platformPart.obstaclePoints.Remove(targetObstacle);
        int randomObstacle = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[randomObstacle], targetObstacle.transform.position, Quaternion.Euler(obstacles[randomObstacle].transform.eulerAngles.x, -targetObstacle.transform.localEulerAngles.y, obstacles[randomObstacle].transform.eulerAngles.z));
    }

    GameObject CreateEndObject(GameObject referenceObject)
    {
        GameObject choosedEndObjectPrefab = runEndPartPrefabs[Random.Range(0, runEndPartPrefabs.Length)];

        return Instantiate(choosedEndObjectPrefab, new Vector3(0, 0, referenceObject.transform.position.z + runPartObjectDistance), choosedEndObjectPrefab.transform.rotation);
    }
}
