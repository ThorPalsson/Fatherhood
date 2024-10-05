using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance; 

    private AsyncOperation loadingOperation; 
    private AsyncOperation unLoadingOperation;
    private bool hasLoaded;
    private bool hasUnloaded; 
    private string currentMainSceneName; 
    private string loadingSceneName; 
    private bool isAnimating; 

    [SerializeField] private float animTimer; 
    [SerializeField] private GameObject loadCamera; 
    [SerializeField] private Animator door, cameraMove;

    private bool isFirst = true;  


    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(Instance);
        }   
        else 
        {
            Instance = this; 
        }
    }

    private void Start()
    {
        LoadScene("SampleScene", null); 
    }

    public void LoadScene(string sceneName, GameObject camera)
    {
        if (camera != null)
            camera.SetActive(false); 


        loadCamera.SetActive(true); 
        loadingSceneName = sceneName; 
        loadingOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive); 
        loadingOperation.allowSceneActivation = false; 
        DeloadScene();

        if (isFirst)
        {
            SceneManager.LoadSceneAsync("PlayerScene", LoadSceneMode.Additive);
            isFirst = false;
        }
    }

    private void DeloadScene()
    {
        print ("unloading " + currentMainSceneName); 
        if (String.IsNullOrEmpty(currentMainSceneName))
        {
            hasUnloaded = true;
            return;
        }
        unLoadingOperation = SceneManager.UnloadSceneAsync(currentMainSceneName); 
    }

    private void Update()
    {
        if (loadingOperation != null && !hasLoaded)
        {
            Debug.Log($"Loading progress is = {loadingOperation.progress}");

            if (loadingOperation.progress >= 0.9f)
            {
                hasLoaded = true; 
            }
        }

        if (unLoadingOperation != null && !hasUnloaded)
        {
            if (unLoadingOperation.isDone)
            {
                Debug.Log("Unloading complete.");
                hasUnloaded = true;
            }
        }

        if (hasLoaded && hasUnloaded && !isAnimating)
        {
            StartCoroutine(AnimateAndLoad()); 
            isAnimating = true; 
            currentMainSceneName = loadingSceneName; 
            loadingSceneName = null; 
        }
    }

    private IEnumerator AnimateAndLoad()
    {
        door.enabled = true;
        cameraMove.enabled = true; 

        yield return new WaitForSeconds(animTimer); 

        loadingOperation.allowSceneActivation = true; 

        if (PlayerController.Instance != null)
        {
            PlayerController.Instance.transform.GetComponent<RoomHolder>().SceneName = currentMainSceneName; 
        }


        unLoadingOperation = null; 
        loadingOperation = null; 
        isAnimating = false; 
        hasLoaded = false; 
        hasUnloaded = false; 

        loadCamera.SetActive(false);
        door.enabled = false;
        cameraMove.enabled = false;
    }
}
