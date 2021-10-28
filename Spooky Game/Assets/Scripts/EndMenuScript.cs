using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenuScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer mop;
    [SerializeField] private Sprite mopFail;
    [SerializeField] private SpriteRenderer trash;
    [SerializeField] private Sprite trashFail;
    [SerializeField] private SpriteRenderer knife;
    [SerializeField] private Sprite knifeFail;
    [SerializeField] private SpriteRenderer mom;
    [SerializeField] private Sprite momFail;

    private int evilCount = 0;
    public int evilMax = 6;
    private double endCount = -1;
    public double endMax = 1;
    [SerializeField] private GameObject jumpscare;
    [SerializeField] private AudioSource jumpsound;
    [SerializeField] private GameObject canvas;

    public GameManager gameMan;
    private void OnLevelWasLoaded(int level)
    {
        gameMan = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        if (gameMan.getKarma() > 0)
        {
            mop.sprite = mopFail;
            trash.sprite = trashFail;
            knife.sprite = knifeFail;
            mom.sprite = momFail;
        }
    }

    public void newWeek()
    {
        gameMan.resetKarma();
        gameMan.loadScene("Bed0Scene");
    }

    public void evilEnd()
    {
        evilCount++;
        if (evilCount >= evilMax)
        {
            jumpscare.SetActive(true);
            jumpsound.Play();
            canvas.SetActive(false);
            endCount = 0;
        }
    }

    private void Update()
    {
        if (endCount >= 0)
        {
            endCount += Time.deltaTime;
            if (endCount >= endMax)
            {
                Application.Quit();
            }
        }
    }
}
