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

    void Awake()
    {
        karma = PlayerPrefs.GetInt("Karma");
    }

    public void addKarma()
    {
        karma++;
    }

    public int getKarma()
    {
        return karma;
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

    public void quitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ResetData()
    {
        
    }

    void LoadData()
    {

    }
}
