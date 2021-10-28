using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bed3Script : MonoBehaviour
{
    public TMP_Text textBox;
    public GameObject endButton;
    public GameObject endButtonEvil;
    public int curKarma;

    public GameObject background;
    public Sprite nightGood;
    public Sprite nightEvil1;
    public Sprite nightEvil2;
    public Sprite nightEvil3;

    private void Awake()
    {
        curKarma = GameManager.GM.getKarma();
        if (curKarma == 0)
        {
            background.GetComponent<SpriteRenderer>().sprite = nightGood;
        }
        else if (curKarma == 1)
        {
            background.GetComponent<SpriteRenderer>().sprite = nightEvil1;
        }
        else if (curKarma == 2)
        {
            background.GetComponent<SpriteRenderer>().sprite = nightEvil2;
        }
        else
        {
            background.GetComponent<SpriteRenderer>().sprite = nightEvil3;
        }
    }

    private void Start()
    {
        if (curKarma <= 0)
        {
            textBox.text = "> Mom: You aced all of your chores this week!  Great job honey! \n> Mom: Those trash bags were pretty fragile, so it's good that you didn't drop them. \n> Mom: There might've been some trouble if you did...\n> Mom: Anyway, keep up the good work next week!  Sweet dreams!";
            endButton.SetActive(true);

        }
        else if (curKarma == 1)
        {
            textBox.text = "> Mom: I know this week was a bit rough, and your chores weren't all perfect. \n> Mom: You would be in a lot more trouble if you'd messed up the other chores too. \n> Mom: That being said, let's make sure next week is better, ok honey? \n> Mom: Goodnight.";
            endButton.SetActive(true);
        }
        else if (curKarma == 2)
        {
            textBox.text = "> Mom: I know the things you saw, and it's a bit of a problem. \n> Mom: I need you to forget about all of it, don't tell a single person. \n> Mom: You'd better make up for it next week.  Who knows what I might have to do otherwise... \n> Mom: Now go to sleep.";
            endButton.SetActive(true);
        }
        else
        {
            textBox.text = "> Mom: YOU'VE SEEN TOO MUCH. \n> Mom: YOU SHOULD HAVE DONE YOUR CHORES AND STAYED A NAIVE LITTLE CHILD. \n> Mom: THERE IS NO GOING BACK NOW. \n> Mom: ... ";
            endButtonEvil.SetActive(true);
        }
    }

    public void nextLevel()
    {
        GameManager.GM.nextScene();
    }

    public void evilLevel()
    {
        GameManager.GM.loadScene("EndMenuEvil");
    }
}