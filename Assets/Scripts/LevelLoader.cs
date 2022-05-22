using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingPanel;

    public void LoadLevel(string levelName)
    {


        int buildIndex = SceneUtility.GetBuildIndexByScenePath(levelName);

        if (buildIndex > -1)
        {
            StartCoroutine(LoadSceneAsync(levelName));
        }
        else
        {
            StartCoroutine(LoadSceneAsync("theend"));
        }

    }

    IEnumerator LoadSceneAsync(string levelName)
    {
        loadingPanel.SetActive(true);

        AsyncOperation op = SceneManager.LoadSceneAsync(levelName);




        while (!op.isDone)
        {
            loadingPanel.GetComponent<CanvasGroup>().alpha = 1;
            float progress = Mathf.Clamp01(op.progress / .9f);
            yield return null;
        }
    }
}