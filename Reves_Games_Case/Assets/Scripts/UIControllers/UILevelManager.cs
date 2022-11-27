using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UILevelManager : MonoBehaviour
{
    public Image levelBar;
    public Transform mainCoin, endedPlatform;
    float fullDistance;
    void Start()
    {
        mainCoin = GameObject.FindGameObjectWithTag("MainCoin").transform;
        endedPlatform = GameObject.FindGameObjectWithTag("Ended").transform;
        fullDistance = GetDistance();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MainCoinHitCollisionObstacle.instance.isHitToObstacle)
        {
            float newDistance = Vector3.Distance(mainCoin.position, endedPlatform.position);
            float levelBarValue = Mathf.InverseLerp(fullDistance, 0, newDistance);
            UpdateLevelBarFill(levelBarValue);
        }
    }
    private float GetDistance()
    {
        return Vector3.Distance(mainCoin.position, endedPlatform.position);
    }
    private void UpdateLevelBarFill(float value)
    {
        levelBar.fillAmount = value;
    }
    public void ClickToTryAgainButton(int i)
    {
        SceneManager.LoadSceneAsync(i);
    }
}
