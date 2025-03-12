using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaceTower : MonoBehaviour
{
    public Camera cam;
    public GameObject selection;
    public GameObject placedObject;
    [Space]
    [Header("Materials")]
    public GameObject ghostObject;
    GameObject ghost;

    bool place;
    bool oneGhost;
    [Space]
    [Header("Money")]
    public Button button;
    public GameObject deSelect;
    public Money money;
    public int price;
    public int boughtCount;
    public TextMeshProUGUI pricetxt;
    public GameObject[] selectCollider;

    public bool isTutorial;

    void Start()
    {
        selection = GameObject.Find("Selection");
    }



    public void ClickSelect()
    {
        if (place)
        {
            ResetSelection();
        }
        else
        {
            if (selection.GetComponent<Selection>().placingTower != null) { selection.GetComponent<Selection>().placingTower.GetComponent<PlaceTower>().ResetSelection(); }
            place = true;

            selection.GetComponent<Selection>().placingTower = gameObject;
            deSelect.SetActive(true);

            //Find Colliders
            GameObject[] obj = GameObject.FindGameObjectsWithTag("Cat");
            selectCollider = obj;
            for (int i = 0; i < obj.Length; i++) { selectCollider[i] = obj[i].transform.Find("SelectCollider").gameObject; }
            foreach (GameObject col in selectCollider) { col.SetActive(false); }

            selection.gameObject.GetComponent<Selection>().ResetSelection(true);
        }
    }

    void Update()
    {
        if(price + ((price / 2) * boughtCount) > money.money) { button.interactable = false; }
        if (price + ((price / 2) * boughtCount) <= money.money) { button.interactable = true; }

        pricetxt.text = "$"+ (price + ((price / 2) * boughtCount));

        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);



        //Place Ghost object
        if (place && Physics.Raycast(ray, out hit))
        {
            if (oneGhost == false) { ghost = Instantiate(ghostObject); }
            oneGhost = true;
            ghost.transform.position = hit.point;
        }

        //PlaceObject
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && place)
        {

            if(hit.collider.gameObject.tag == "Placeable")
            {
                GameObject.Find("Select").GetComponent<AudioSource>().Play();

                ResetSelection();

                GameObject obj = Instantiate(placedObject);
                obj.transform.position = hit.point;


                money.money -= price + ((price / 2) * boughtCount);
                boughtCount++;

                if (isTutorial) { GameObject.Find("Greendot1").SetActive(false); }
            }

        }


        //Change to red
        if (Physics.Raycast(ray, out hit) && place)
        {
            if(hit.collider.gameObject.tag == "Placeable")
            {
                ghost.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
            {
                ghost.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    void ResetSelection()
    {
        Destroy(ghost);


        foreach (GameObject col in selectCollider) { col.SetActive(true); }
        deSelect.SetActive(false);
        selection.GetComponent<Selection>().placingTower = null;

        place = false;
        oneGhost = false;
    }
}
