using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrades : MonoBehaviour
{
    public Money money;
    public Selection selection;
    bool isOpen;

    public TowerReference currentCat;

    public RawImage upgradeBackground;

    public GameObject leftPath;
    public GameObject rightPath;


    public GameObject minor1;
    public GameObject minor2;
    public GameObject minor3;

    [Space]
    [Header("Prices")]
    public TextMeshProUGUI priceLeft;
    public TextMeshProUGUI priceRight;
    public TextMeshProUGUI priceMinor1;
    public TextMeshProUGUI priceMinor2;
    public TextMeshProUGUI priceMinor3;

    [Space]
    public TextMeshProUGUI sellButton;



    [Space]
    public Vector2 initalPathPosition;
    public Vector3 pricePos;
    public Vector3 priceScale;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            if(currentCat.path1Prices[currentCat.path1Upgrades] <= money.money && currentCat.path1Upgrades < 3) { leftPath.GetComponent<Button>().interactable = true; }
            else { leftPath.GetComponent<Button>().interactable = false; }

            if (currentCat.path2Prices[currentCat.path2Upgrades] <= money.money && currentCat.path2Upgrades < 3) { rightPath.GetComponent<Button>().interactable = true; }
            else { rightPath.GetComponent<Button>().interactable = false; }

            if (currentCat.minor1Prices[currentCat.minor1Upgrades] <= money.money && currentCat.minor1Upgrades < 3) { minor1.GetComponent<Button>().interactable = true; }
            else { minor1.GetComponent<Button>().interactable = false; }

            if (currentCat.minor2Prices[currentCat.minor2Upgrades] <= money.money && currentCat.minor2Upgrades < 3) { minor2.GetComponent<Button>().interactable = true; }
            else { minor2.GetComponent<Button>().interactable = false; }

            if (currentCat.minor3Prices[currentCat.minor3Upgrades] <= money.money && currentCat.minor3Upgrades < 3) { minor3.GetComponent<Button>().interactable = true; }
            else { minor3.GetComponent<Button>().interactable = false; }
        }
    }


    public void UpgradeSelect(GameObject selectedCat)
    {
        if(isOpen == false) { Open();}

        currentCat = selectedCat.GetComponent<TowerReference>();

        //Set Textures
        upgradeBackground.texture = currentCat.background;


        leftPath.GetComponent<RawImage>().texture = currentCat.path1[currentCat.path1Upgrades];
        rightPath.GetComponent<RawImage>().texture = currentCat.path2[currentCat.path2Upgrades];

        minor1.GetComponent<RawImage>().texture = currentCat.minor1;
        minor2.GetComponent<RawImage>().texture = currentCat.minor2;
        minor3.GetComponent<RawImage>().texture = currentCat.minor3;

        //Set Prices
        priceLeft.text = "$" + currentCat.path1Prices[currentCat.path1Upgrades];
        priceRight.text = "$" + currentCat.path2Prices[currentCat.path2Upgrades];
        priceMinor1.text = currentCat.minor1Upgrades + ": $" + currentCat.minor1Prices[currentCat.minor1Upgrades];
        priceMinor2.text = currentCat.minor2Upgrades + ": $" + currentCat.minor2Prices[currentCat.minor2Upgrades];
        priceMinor3.text = currentCat.minor3Upgrades + ": $" + currentCat.minor3Prices[currentCat.minor3Upgrades];

        priceLeft.gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 1);
        priceRight.gameObject.transform.localScale = new Vector3(2.5f,2.5f,1);

        sellButton.text = "Sell: $"+ currentCat.sellPrice;

        //Set Positions
        leftPath.GetComponent<Animator>().Play("Empty");
        rightPath.GetComponent<Animator>().Play("Empty");

        leftPath.transform.parent.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
        rightPath.transform.parent.GetComponent<RectTransform>().localScale = new Vector2(1,1);

        if (currentCat.path1Upgrades == 0) { leftPath.transform.parent.GetComponent<RectTransform>().localPosition = new Vector2(-initalPathPosition.x, initalPathPosition.y); }
        if(currentCat.path2Upgrades == 0) { rightPath.transform.parent.GetComponent<RectTransform>().localPosition = initalPathPosition; }

        if (currentCat.path1Upgrades > 0) {
            leftPath.transform.parent.GetComponent<RectTransform>().localPosition = new Vector2(0, initalPathPosition.y);
            leftPath.transform.parent.GetComponent<RectTransform>().localScale = new Vector2(2.3f, 1);

            rightPath.transform.parent.GetComponent<RectTransform>().localScale = Vector2.zero;

            priceLeft.gameObject.transform.localPosition = pricePos;
            priceLeft.gameObject.transform.localScale = priceScale;
        }
        if (currentCat.path2Upgrades > 0) {
            rightPath.transform.parent.GetComponent<RectTransform>().localPosition = new Vector2(0, initalPathPosition.y); ;
            rightPath.transform.parent.GetComponent<RectTransform>().localScale = new Vector2(2.3f, 1);

            leftPath.transform.parent.GetComponent<RectTransform>().localScale = Vector2.zero;

            priceRight.gameObject.transform.localPosition = pricePos;
            priceRight.gameObject.transform.localScale = priceScale;
        }
    }
    public void Open()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();


        gameObject.GetComponent<Animator>().Play("Open");
        isOpen = true;
    }

    public void Close()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();


        if (isOpen == true)
        {
            gameObject.GetComponent<Animator>().Play("Close");
            isOpen = false;
            selection.ResetSelection(false);

        }

    }

    public void UpgradeLeft()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();


        //InitalUpgrade Animation
        if (currentCat.path1Upgrades == 0)
        {
            leftPath.GetComponent<Animator>().Play("InitialUpgradeLeft");

            rightPath.GetComponent<Animator>().Play("Disappear");
        }

        money.money -= currentCat.path1Prices[currentCat.path1Upgrades];


        currentCat.GetLeft();
        leftPath.GetComponent<RawImage>().texture = currentCat.path1[currentCat.path1Upgrades];

        leftPath.transform.parent.GetComponent<RectTransform>().localScale = new Vector2(2.3f, 1);
        leftPath.transform.parent.GetComponent<RectTransform>().localPosition = new Vector2(0, initalPathPosition.y);

        priceLeft.gameObject.transform.localPosition = pricePos;
        priceLeft.gameObject.transform.localScale = priceScale;
        priceLeft.text = "$" + currentCat.path1Prices[currentCat.path1Upgrades];
    }

    public void UpgradeRight()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();


        //InitalUpgrade Animation
        if (currentCat.path2Upgrades == 0)
        {
            rightPath.GetComponent<Animator>().Play("InitialUpgradeRight");

            leftPath.GetComponent<Animator>().Play("Disappear");
        }

        money.money -= currentCat.path2Prices[currentCat.path2Upgrades];

        currentCat.GetRight();
        rightPath.GetComponent<RawImage>().texture = currentCat.path2[currentCat.path2Upgrades];

        rightPath.transform.parent.GetComponent<RectTransform>().localScale = new Vector2(2.3f, 1);
        rightPath.transform.parent.GetComponent<RectTransform>().localPosition = new Vector2(0, initalPathPosition.y);


        priceRight.gameObject.transform.localPosition = pricePos;
        priceRight.gameObject.transform.localScale = priceScale;
        priceRight.text = "$" + currentCat.path2Prices[currentCat.path2Upgrades];
    }

    public void UpgradeMinor1()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();


        money.money -= currentCat.minor1Prices[currentCat.minor1Upgrades];

        currentCat.GetMinor1();
        minor1.GetComponent<RawImage>().texture = currentCat.minor1;


        priceMinor1.text = currentCat.minor1Upgrades + ": $" + currentCat.minor1Prices[currentCat.minor1Upgrades];
    }

    public void UpgradeMinor2()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();


        money.money -= currentCat.minor2Prices[currentCat.minor2Upgrades];

        currentCat.GetMinor2();
        minor2.GetComponent<RawImage>().texture = currentCat.minor2;



        priceMinor2.text = currentCat.minor2Upgrades + ": $" + currentCat.minor2Prices[currentCat.minor2Upgrades];
    }

    public void UpgradeMinor3()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();


        money.money -= currentCat.minor3Prices[currentCat.minor3Upgrades];

        currentCat.GetMinor3();
        minor3.GetComponent<RawImage>().texture = currentCat.minor3;



        priceMinor3.text = currentCat.minor3Upgrades + ": $" + currentCat.minor3Prices[currentCat.minor3Upgrades];
    }


    public void SellCat()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();


        money.money += currentCat.sellPrice;
        selection.selectedObject = null;
        selection.selectedOutline = null;
        Close();
        Destroy(currentCat.gameObject);

    }
}
