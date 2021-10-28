using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bed0Script : MonoBehaviour
{
    public TMP_Text textBox;
    public GameObject levelButton;


    private void Start()
    {
        textBox.text = "> Mom: Good morning sweetie! Don't forget to be a good boy and do your weekly chores!";
        levelButton.SetActive(true);
    }

    public void nextLevel()
    {
        Debug.Log("NextScenePLZ");
        GameManager.GM.nextScene();
    }
}
