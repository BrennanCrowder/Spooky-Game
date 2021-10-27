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

    private int cleanAmnt = 0;
    private int dirtyAmnt = 0;


    public void Start()
    {
        textBox.text = "> Mom: Go ahead and clean the dishes for me sweety! \n";
    }

    public void cleanTool()
    {
        cleanAmnt++;
    }

    public void dirtyTool()
    {
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
            setEvil();
            flag = true;
        }
        else if(cleanAmnt == 5)
        {
            allClean();
            flag = true;
        }
        else if (dirtyAmnt + cleanAmnt == 5)
        {
            neutralEnd();
            flag = true;
        }
    }

    public void neutralEnd()
    {
        textBox.text += "> Mom: All right honey be more careful next time but good job.";
    }

    public void setEvil()
    {
        mom.GetComponent<Evilify>().makeEvil();
        background.GetComponent<Evilify>().makeEvil();
        counter.GetComponent<Evilify>().makeEvil();
        water.GetComponent<Evilify>().makeEvil();
        evilText.SetActive(true);
        setEvilTools();
    }

    public void allClean()
    {

        textBox.text += "> Mom: Good job sweetie pie. \n";
    }

    public void setEvilTools()
    {
        foreach(GameObject tool in tools)
        {
            tool.GetComponent<Evilify>().makeEvil();
        }
    }
}
