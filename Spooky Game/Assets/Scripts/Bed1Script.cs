using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bed1Script : MonoBehaviour
{
    public TMP_Text textBox;
    public GameObject levelButton;
    public GameObject dayButton;

    public int curKarma;
    private void Awake()
    {
        curKarma = GameManager.GM.getKarma();
    }

    public void nextLevel()
    {
        GameManager.GM.nextScene();
    }

    private void Start()
    {
        if (curKarma == 0)
        {
            textBox.text = "> Mom: You did good today, rest well!";
            
        } 
        else
        {
            textBox.text = "> Mom: Try ANYTHING like that again and you will be in BIG trouble! \n> Mom: NOW GO TO SLEEP!";
        }
        
        dayButton.SetActive(true);

        
    }

    public void dayTime()
    {
        dayButton.SetActive(false);
        if (curKarma == 0)
        {
            textBox.text = "> Mom: Good Morning! Hope you rested well!  \n> Mom: Don't forget to do your chores again today!";
            
        } else
        {
            textBox.text = "> Mom: I expect today to be better than yesterday. Now go do your chores.";
            
        }
        levelButton.GetComponentInChildren<TMP_Text>().text = "Go Clean Dishes...";
        levelButton.SetActive(true);
    }
}
