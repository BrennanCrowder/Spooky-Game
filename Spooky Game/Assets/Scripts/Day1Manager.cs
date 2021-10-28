using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Day1Manager : MonoBehaviour
{
    public TMP_Text textBox;
    public GameObject background;
    public GameObject mom;
    public GameObject ground;
    public Sprite neutralMom;
    public GameObject evilText;
    public GameObject levelButton;

    private int brokenCount = 0;
    private int trashCount = 0;
    private bool flag = false;

    void Start()
    {
        textBox.text = "> Mom: Take out the trash please, and be careful not to drop it! \n";
    }


    public void trashThrownAway()
    {
        trashCount++;
        Debug.Log("TrashThrownAway!");
        if(trashCount == 6)
        {
            Debug.Log("Trash Done!");
            textBox.text += "> Mom: Good job, all your chores are done for the day go ahead and get some rest";
            levelButton.SetActive(true);
        }
    }

    public void evilTrashBroken()
    {
        Debug.Log("Uh Oh...");
        setEvil();
    }

    public void nextLevel()
    {
        GameManager.GM.nextScene();
    }

    private void Update()
    {
        if (!flag && (brokenCount + trashCount == 6))
        {
            flag = true;
            textBox.text += "> Mom: Well, at least you threw out the important stuff.  Let's go inside. \n";
            levelButton.SetActive(true);
        }
    }

    public GameManager gameMan;
    private void OnLevelWasLoaded(int level)
    {
        gameMan = FindObjectOfType<GameManager>();
    }
    public void setEvil()
    {
        background.GetComponent<Evilify>().makeEvil();
        mom.GetComponent<Evilify>().makeEvil();
        ground.GetComponent<Evilify>().makeEvil();
        evilText.SetActive(true);
        levelButton.SetActive(true);
        GameManager.GM.addKarma();
    }

    public void normalTrashBroken()
    {
        mom.GetComponent<SpriteRenderer>().sprite = neutralMom;
        brokenCount++;
        Debug.Log("Trash Broken...");
        if (brokenCount == 1)
        {
            Debug.Log("Updating Text...");
            textBox.text += "> Mom: Please be more careful dear! \n";
        }
        /*else if (brokenCount == 2)
        {
            Debug.Log("Updating Text...");
            textBox.text += "> Mom: Stop playing around! \n";
        }*/
        else if (brokenCount == 3)
        {
            Debug.Log("Updating Text...");
            textBox.text += "> Mom: Stop playing around, you're really pushing it! \n";
        }
        /*else if (brokenCount == 4)
        {
            Debug.Log("Updating Text...");
            textBox.text += "> Mom: I said stop! \n";
        }*/
        else if (brokenCount == 5)
        {
            Debug.Log("Updating Text...");
            textBox.text += "> Mom: This is your final warning! \n";
        }


    }
}
