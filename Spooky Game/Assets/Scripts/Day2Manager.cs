using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Day2Manager : MonoBehaviour
{
    public GameObject mom;
    public GameObject background;
    public GameObject counter;
    public GameObject water;
    public GameObject[] tools;
    public TMP_Text textBox;
    public Sprite neutralMom;
    public GameObject evilText;
    public bool flag = false;
    public int curKarma;
    public GameObject levelButton;


    private int cleanAmnt = 0;
    private int dirtyAmnt = 0;

    public GameManager gameMan;
    private void OnLevelWasLoaded(int level)
    {
        gameMan = GameManager.GM;
        curKarma = GameManager.GM.getKarma();
    }

    
    public void Start()
    {
        textBox.text = "> Mom: Go ahead and clean the dishes for me sweetie! \n> Mom: Make sure to run them through the water. \n";
        if (curKarma == 1)
        {
            setEvilTools();
        }
    }

    public void nextLevel()
    {
        GameManager.GM.nextScene();
    }

    public void cleanTool()
    {
        cleanAmnt++;
    }

    public void dirtyTool()
    {
        if (dirtyAmnt == 0) textBox.text += "> Mom: Watch what you're doing!  That one was still dirty! \n";
        if (dirtyAmnt == 2) textBox.text += "> Mom: Don't you dare make me tell you again! \n";

        setNeutralMom();
        dirtyAmnt++;
    }

    public void setNeutralMom()
    {
        mom.GetComponent<SpriteRenderer>().sprite = neutralMom;
    }

    private void Update()
    {
        if (flag)
        {
            return;
        }
        if (dirtyAmnt == 5)
        {
            flag = true;
            setEvil();
            
        }
        else if(cleanAmnt == 5)
        {
            flag = true;
            allClean();
            
        }
        else if (dirtyAmnt + cleanAmnt == 5)
        {
            flag = true;
            neutralEnd();
            
        }
    }

    public void neutralEnd()
    {
        textBox.text += "> Mom: All right honey, be more careful next time but good job.";
        levelButton.SetActive(true);
    }

    public void setEvil()
    {
        mom.GetComponent<Evilify>().makeEvil();
        background.GetComponent<Evilify>().makeEvil();
        counter.GetComponent<Evilify>().makeEvil();
        water.GetComponent<Evilify>().makeEvil();
        evilText.SetActive(true);
        setEvilTools();
        GameManager.GM.addKarma();
        levelButton.SetActive(true);
    }

    public void allClean()
    {

        textBox.text += "> Mom: Good job sweetie pie. You deserve a nice nap! \n";
        levelButton.SetActive(true);
    }

    public void setEvilTools()
    {
        foreach(GameObject tool in tools)
        {
            tool.GetComponent<Evilify>().makeEvil();
        }
    }
}
