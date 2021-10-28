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

    public GameObject background;
    public Sprite nightGood;
    public Sprite dayGood;
    public Sprite nightEvil;
    public Sprite dayEvil;

    private void Awake()
    {
        curKarma = GameManager.GM.getKarma();
        if (curKarma == 0)
        {
            background.GetComponent<SpriteRenderer>().sprite = nightGood;
        }
        else
        {
            background.GetComponent<SpriteRenderer>().sprite = nightEvil;
        }

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
            background.GetComponent<SpriteRenderer>().sprite = dayGood;
            textBox.text = "> Mom: Good morning! Hope you rested well!  \n> Mom: Don't forget to do your chores again today!";
            
        } else
        {
            background.GetComponent<SpriteRenderer>().sprite = dayEvil;
            textBox.text = "> Mom: I expect today to be better than yesterday. Now go do your chores.";
            
        }
        levelButton.GetComponentInChildren<TMP_Text>().text = "Go Clean Dishes...";
        levelButton.SetActive(true);
    }
}
