using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private static int karma;
    [SerializeField] private TextAsset saveFile;

    void Awake()
    {
        karma = PlayerPrefs.GetInt("Karma");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
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
