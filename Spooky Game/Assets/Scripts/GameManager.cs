using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;


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

    private static int karma;
    [SerializeField] private TextAsset saveFile;

    [SerializeField] private AudioSource musicGood;
    [SerializeField] private AudioSource musicEvil1;
    [SerializeField] private AudioSource musicEvil2;
    [SerializeField] private AudioSource musicEvil3;
    [SerializeField] private AudioSource currentMusic;
    public int x = 0;
    public bool flag = true;

    void Awake()
    {
        karma = PlayerPrefs.GetInt("Karma");
        currentMusic = musicGood;
        currentMusic.Play();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (x >= 10000 && flag)
        {
            flag = false;
            currentMusic.Stop();
            currentMusic = musicEvil1;
            currentMusic.Play();
        }
        else x += 1;
    }

    void ResetData()
    {
        
    }

    void LoadData()
    {

    }
}
