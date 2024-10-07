using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance; 

    private AsyncOperation loadingOperation; 
    private AsyncOperation unLoadingOperation;
    private bool hasLoaded;
    private bool hasUnloaded; 
    [SerializeField] private string currentMainSceneName; 
    [SerializeField] private string loadingSceneName; 
    private bool isAnimating; 
    [SerializeField] private VideoPlayer vp;

    [SerializeField] private float animTimer; 
    [SerializeField] private GameObject loadCamera; 
    [SerializeField] private Animator door, cameraMove;

    public AudioSource doorAudio; 

    private bool isFirst = true;  

    [SerializeField] private AudioClip[] loadingClips; 


    [SerializeField] private AudioSource source; 


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
        LoadScene("Nursery", null); 
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

            if (loadingOperation.progress >= 0.9f)
            {
                hasLoaded = true; 
            }
        }

        if (unLoadingOperation != null && !hasUnloaded)
        {
            if (unLoadingOperation.isDone)
            {
                hasUnloaded = true;
            }
        }

        if (hasLoaded  && !isAnimating)
        {
            StartCoroutine(AnimateAndLoad()); 
            isAnimating = true; 
            
            if (PlayerController.Instance != null)
            {
                PlayerController.Instance.transform.GetComponent<RoomHolder>().SceneName = currentMainSceneName; 
            }
            
            currentMainSceneName = loadingSceneName; 
            loadingSceneName = null; 
        }
    }

    private IEnumerator AnimateAndLoad()
    {

        vp.Play();
        doorAudio.Play();
        yield return new WaitForSeconds(animTimer); 


        /*var Randy = UnityEngine.Random.Range(0,10);

        if (Randy > 5)
        {
            source.clip = loadingClips[UnityEngine.Random.Range(0, loadingClips.Length)];
            source.Play();
        }*/

        loadingOperation.allowSceneActivation = true; 
        unLoadingOperation = null; 
        loadingOperation = null; 
        isAnimating = false; 
        hasLoaded = false; 
        hasUnloaded = false; 
        loadCamera.SetActive(false);
    }
}