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


    private int brokenCount = 0;
    private int trashCount = 0;

    void Start()
    {
        textBox.text = "> Mom: Take out the trash please! \n";
    }


    public void trashThrownAway()
    {
        trashCount++;
        if(trashCount == 6)
        {
            Debug.Log("Trash Done!");
            textBox.text += "> Mom: Good job, all your chores are done for the day go ahead and get some rest";
        }
    }

    public void evilTrashBroken()
    {
        Debug.Log("Uh Oh...");

        textBox.text += "> Mom: WHAT HAVE YOU DONE!";
        setEvil();
    }

    public void setEvil()
    {
        background.GetComponent<Evilify>().makeEvil();
        mom.GetComponent<Evilify>().makeEvil();
        ground.GetComponent<Evilify>().makeEvil();
        evilText.SetActive(true);
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
        else if (brokenCount == 2)
        {
            Debug.Log("Updating Text...");
            textBox.text += "> Mom: Stop playing around! \n";
        }
        else if (brokenCount == 3)
        {
            Debug.Log("Updating Text...");
            textBox.text += "> Mom: Your pushing it! \n";
        }
        else if (brokenCount == 4)
        {
            Debug.Log("Updating Text...");
            textBox.text += "> Mom: I said stop! \n";
        }
        else if (brokenCount == 5)
        {
            Debug.Log("Updating Text...");
            textBox.text += "> Mom: This is your final warning! \n";
        }


    }
}
