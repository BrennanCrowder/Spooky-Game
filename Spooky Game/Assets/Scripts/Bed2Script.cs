using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bed2Script : MonoBehaviour
{
    public TMP_Text textBox;
    public GameObject levelButton;
    public GameObject dayButton;
    public int curKarma;
    private void Awake()
    {
        curKarma = GameManager.GM.getKarma();
    }

    private void Start()
    {
        if (curKarma <= 0)
        {
            textBox.text = "> Mom: I am so proud of you honey! I hope you sleep well!";

        } 
        else if (curKarma == 1)
        {
            textBox.text = "> Mom: You have been a bit troublesome recently, I hope you aren't sick. \n> Mom: Get some good sleep tonight, ok?";
        }
        else
        {
            textBox.text = "> Mom: ......you know what you did. Go to sleep, NOW.";
        }
        dayButton.SetActive(true);
    }

    public void nextLevel()
    {
        GameManager.GM.nextScene();
    }

    public void dayTime()
    {
        dayButton.SetActive(false);
        if (curKarma == 0)
        {
            textBox.text = "> Mom: Good morning! I hope you have a wonderful day... after your chores of course!";
            
        }
        else if (curKarma == 1) {
            textBox.text = "> Mom: Good morning! Hope you're feeling better. \n> Mom: Now go on and do your chores.";
        }
        else
        {
            textBox.text = "> Mom: You'd better do things right today, you understand me?";

        }
        levelButton.GetComponentInChildren<TMP_Text>().text = "Go Mop...";
        levelButton.SetActive(true);
    }
}
