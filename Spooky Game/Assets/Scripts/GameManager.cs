using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;



public class GameManager : MonoBehaviour
{
    #region GameManagerSingleton
    static GameManager gm;
    public static GameManager GM
    {
        get
        {
            return gm;
        }
    }
    void checkGameManagerInScene()
    {
        if (gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public static int karma;
    private int sceneCount = 1;

    [SerializeField] private TextAsset saveFile;

    [SerializeField] private AudioSource musicGood;
    [SerializeField] private AudioSource musicEvil1;
    [SerializeField] private AudioSource musicEvil2;
    [SerializeField] private AudioSource musicEvil3;
    private AudioSource currentMusic;
    [SerializeField] private AudioSource failSound;

    void Awake()
    {
        karma = PlayerPrefs.GetInt("Karma");
        currentMusic = musicGood;
        currentMusic.Play();
    }

    public void addKarma()
    {
        karma++;
    }

    public int getKarma()
    {
        return karma;
    }

    public void resetKarma()
    {
        karma = 0;
        sceneCount = 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        checkGameManagerInScene();
    }

    public void nextScene()
    {
        Debug.Log("Next Scene");
        SceneManager.LoadScene(sceneCount);
        sceneCount++;
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (karma == 0)
        {
            if (currentMusic != musicGood)
            {

                musicGood.time = currentMusic.time;
                currentMusic.Stop();
                currentMusic = musicGood;
                currentMusic.Play();
            }

        }
        else if (karma == 1)
        {
            if (currentMusic != musicEvil1)
            {
                failSound.Play();
                musicEvil1.time = currentMusic.time;
                currentMusic.Stop();
                currentMusic = musicEvil1;
                currentMusic.Play();
            }
        }
        else if (karma == 2)
        {
            if (currentMusic != musicEvil2)
            {
                failSound.Play();
                musicEvil2.time = currentMusic.time;
                currentMusic.Stop();
                currentMusic = musicEvil2;
                currentMusic.Play();
            }
        }
        else 
        {
            if (currentMusic != musicEvil3)
            {
                failSound.Play();
                musicEvil3.time = currentMusic.time;
                currentMusic.Stop();
                currentMusic = musicEvil3;
                currentMusic.Play();
            }
        }
    }

    void ResetData()
    {
        
    }

    void LoadData()
    {

    }
}
