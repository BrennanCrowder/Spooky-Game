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
        else if (curKarma <= 2)
        {
            textBox.text = "> Mom: You have been a bit rebelous recently I hope you arn't sick. Get a good night sleep.";
        }
        else
        {
            textBox.text = "> Mom: ...... you know what you did. Go to sleep.";
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
            textBox.text = "> Mom: Good Morning! I hope you have a wonderful day... after your chores of course!";
            
        }
        else if (curKarma <= 2) {
            textBox.text = "> Mom: Good Morning! Hope you are feeling better now go do your chores.";
        }
        else
        {
            textBox.text = "> Mom: Do better today.";

        }
        levelButton.GetComponentInChildren<TMP_Text>().text = "Go Mop...";
        levelButton.SetActive(true);
    }
}
