using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public Animator ani;
    public TextMeshProUGUI text;
    public int phase;
    public bool isOpen;



    [Space]
    public GameObject greendot1;
    void Start()
    {
        ani.Play("Open");
        isOpen = true;

        NewTip();
        Invoke("StartingNewTip", 10);
    }


    void Update()
    {
        
    }

    public void CloseTip()
    {


        if (phase == 1)
        {
            NewTip();
        }
        else 
        {
            ani.Play("Close");
            isOpen = false;
        }

    }

    public void NewTip()
    {
        if(isOpen == false)
        {
            ani.Play("Open");
            isOpen = true;
        }

        phase++;

        if(phase == 1)
        {
            text.text = "You will soon need to defend against waves of fruit by using a team of cats.";
        }
        if (phase == 2)
        {
            greendot1.SetActive(true);
            text.text = "Click on \"Knife Cat\" and place it down on the green marker. To start a wave, press the green play button.";
        }
        if (phase == 3)
        {
            text.text = "Keep an eye on your health and money at the top left. Start the next wave!";
        }
        if (phase == 4)
        {
            text.text = "Click on any cat to upgrade it. You can view what upgrades do by pausing the game and checking the guide.";
        }
        if (phase == 5)
        {
            text.text = "Each fruit has different strengths and weaknesses. These can also be viewed in the guide.";
        }
        if (phase == 5)
        {
            text.text = "Try adding new cats! Find a strategy that works for you.";
        }
        if (phase == 6)
        {
            text.text = "As you progress, fruit get stronger. Make sure you keep upgrading your cats to keep up.";
        }
        if (phase == 7)
        {
            text.text = "You lose when enough fruit make it through the path. You win when you make it past the final wave.";
        }
        if (phase == 8)
        {
            text.text = "Each cat has two upgrade paths which grant unique abilities.";
        }
        if (phase == 9)
        {
            text.text = "There are also three minor upgrade options for each cat.";
        }
        if (phase == 10)
        {
            text.text = "Placement is very important! Make sure your cats are able to reach the path.";
        }

        if (phase == 11)
        {
            text.text = "Watch out! Next wave will have a coconut. Make sure you have a Hammer Cat to break it.";
        }
        if (phase == 12)
        {
            text.text = text.text = "This is the final wave of the tutorial. Try the other levels next!"; 
        }

    }

    public void StartingNewTip()
    {
        if(phase == 1)
        {
            NewTip();
        }
    }
}
