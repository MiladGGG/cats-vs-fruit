using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    public Camera cam;
    public Upgrades upgrades;
    public GameObject hoverObj;


    [Space]
    public string targetObject;
    public LayerMask mask;

    [Space]
    public GameObject selectedObject;

    GameObject hoveredObj;

    public Outline[] outline;
    public Outline[] selectedOutline;

    public GameObject placingTower;
    void Start()
    {

    }


    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        //Set Array
        if (hoveredObj != null)
        {
            outline = hoveredObj.GetComponentsInChildren<Outline>();
        }

        //Reset Last Hovered Object
        if(hoverObj != null)
        {
            hoveredObj = hoverObj;

        }



        //Find Hovered Object
        if (Physics.Raycast(ray, out hit, mask))
        {
            //Hover Object is the PARENTS Object OR if not then its just the hit object
            if (hit.collider.transform.parent != null) { hoverObj = hit.collider.transform.parent.gameObject; }
            if (hit.collider.transform.parent == null) { hoverObj = hit.collider.gameObject; }


            if (hoveredObj != null && hoveredObj.gameObject.tag == targetObject ) 
            {

                outline = hoveredObj.GetComponentsInChildren<Outline>();
                foreach (Outline line in outline)
                {
                    line.OutlineColor = line.GetComponent<Outline>().hovColor;
                    line.OutlineWidth = line.GetComponent<Outline>().hovThickness;
                }

            }
        }


        //Reset Unhovered Object Outline
        if (hoveredObj != null && hoverObj != hoveredObj && hoveredObj.gameObject.tag == targetObject)
        {
            foreach (Outline line in outline)
            {
                line.OutlineColor = line.GetComponent<Outline>().noColor;
                line.OutlineWidth = line.GetComponent<Outline>().noThickness;
            }
        }






        //Click to select
        if (Input.GetMouseButtonDown(0))
        {


            //Select Target Object
            if (hoveredObj.tag == targetObject)
            {
                //Reset
                if (selectedObject != null)
                {
                    selectedObject.GetComponent<TowerReference>().Targeter.GetComponent<MeshRenderer>().enabled = false;

                    foreach (Outline line in selectedOutline)
                    {
                        line.OutlineColor = line.GetComponent<Outline>().noColor;
                        line.OutlineWidth = line.GetComponent<Outline>().noThickness;
                    }
                }


                //Set new
                selectedObject = hoveredObj;
                if (selectedObject != null) { selectedOutline = selectedObject.GetComponentsInChildren<Outline>(); }

                selectedObject.GetComponent<TowerReference>().Targeter.GetComponent<MeshRenderer>().enabled = true;

                upgrades.UpgradeSelect(selectedObject);
            }


            //Reset Selection when clicking the floor or something
            if (hoveredObj.tag != targetObject)
            {
                //ResetSelection();
            }
            
        }


        //Set Selected object outline
        if(selectedObject != null && hoveredObj != null && selectedOutline != null)
        {
            foreach (Outline line in selectedOutline)
            {
                line.OutlineColor = line.GetComponent<Outline>().selectColor;
                line.OutlineWidth = line.GetComponent<Outline>().selectThickness;

            }
        }

    }


    public void ResetSelection(bool close)
    {
        if (selectedOutline != null)
        {
            foreach (Outline line in selectedOutline)
            {
                line.OutlineColor = line.GetComponent<Outline>().noColor;
                line.OutlineWidth = line.GetComponent<Outline>().noThickness;
            }
        }
        if (close == true) { upgrades.Close(); }

        if (selectedObject != null) { selectedObject.GetComponent<TowerReference>().Targeter.GetComponent<MeshRenderer>().enabled = false; }

        selectedObject = null;
    }
}
