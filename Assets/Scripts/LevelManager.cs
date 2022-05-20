using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    float levelTransitionTime = 1.5f;

    void OnEnable()
    {
        JetCrash.OnJetCrash           += RestartLevel;
        AutoLanding.OnLandingComplete += RestartLevel;
        OutOfMap.OnMissionFailed      += RestartLevel;
    }

    void OnDisable()
    {
        JetCrash.OnJetCrash           -= RestartLevel;
        AutoLanding.OnLandingComplete -= RestartLevel;
        OutOfMap.OnMissionFailed      -= RestartLevel;
    }

    private void RestartLevel()
    {
        StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(levelTransitionTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
