using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Day3Manager : MonoBehaviour
{
    public GameObject background;
    public GameObject bucket;
    public GameObject mom;
    public GameObject mop;
    private List<MessScript> messList = new List<MessScript>();

    [SerializeField] private int warningCount1 = 201;
    [SerializeField] private int warningCount2 = 300;
    private bool warned1 = false;
    private bool warned2 = false;
    [SerializeField] private int failCount = 400;

    public TMP_Text textBox;
    public Sprite neutralMom;
    public GameObject evilText;
    public bool flag = false;
    public int curKarma;
    public GameObject levelButton;

    public GameManager gameMan;

    private void OnLevelWasLoaded(int level)
    {
        gameMan = GameManager.GM;
        curKarma = GameManager.GM.getKarma();
    }

    public void Start()
    {
        textBox.text = "> Mom: Could you mop the floor for me honey? \n> Mom: Make sure to dip the mop in bucket often so it stays clean! \n";
        if (curKarma >= 1)
        {
            setEvilObjects();
        }
    }
    public void nextLevel()
    {
        GameManager.GM.nextScene();
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
        if (messList.Count == 0)
        {
            flag = true;
            goodEnd();
        }
        else if (messList.Count >= failCount)
        {
            flag = true;
            setEvil();
        }
        else if (!warned2 && messList.Count >= warningCount2)
        {
            warned2 = true;
            textBox.text += "> Mom: You'd better stop smearing all that dirt right this instant! \n";
        }
        else if (!warned1 && messList.Count >= warningCount1)
        {
            warned1 = true;
            textBox.text += "> Mom: You're making a mess!  Dip the mop in the bucket! \n";
            setNeutralMom();
        }
    }

    public void goodEnd()
    {
        textBox.text += "> Mom: Great job dear!  Go on back to your room, mom is busy now. \n";
        levelButton.SetActive(true);
    }

    public void setEvil()
    {
        background.GetComponent<Evilify>().makeEvil();
        bucket.GetComponent<Evilify>().makeEvil();
        mom.GetComponent<Evilify>().makeEvil();
        mop.GetComponent<MopScript>().evilify();

        foreach (MessScript item in messList)
        {
            item.evilify();
        }

        evilText.SetActive(true);
        levelButton.SetActive(true);
        GameManager.GM.addKarma();
        
    }

    public void addMess(MessScript mess)
    {
        messList.Add(mess);
    }

    public void removeMess(MessScript mess)
    {
        messList.Remove(mess);
    }

    public void setEvilObjects()
    {
        bucket.GetComponent<Evilify>().makeEvil();
        mop.GetComponent<MopScript>().evilify();
        foreach (MessScript item in messList)
        {
            item.evilify();
        }
    }
}
