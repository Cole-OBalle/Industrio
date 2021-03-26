using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopperScript : MonoBehaviour
{
    private int time;

    private GameObject dispenser;

    private Vector3 sp;
    Quaternion rot = new Quaternion(0, 0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        time++;
        if(time == 100)
        {
            time = 0;
            if (other.name.Contains("Tree"))
            {
                dispenser = GameObject.Find("Item");
                int itemID = 1;
                int itemValue = 1;
                switch (other.GetComponent<treeScript>().getType())
                {
                    case "OAK":
                        itemID = 1;
                        itemValue = 1;
                        break;
                    case "SPRUCE":
                        itemID = 2;
                        itemValue = 2;
                        break;
                    case "DARKOAK":
                        itemID = 5;
                        itemValue = 5;
                        break;
                    case "ACACIA":
                        itemID = 4;
                        itemValue = 4;
                        break;
                    case "JUNGLE":
                        itemID = 3;
                        itemValue = 3;
                        break;
                    case "CHERRY":
                        itemID = 6;
                        itemValue = 6;
                        break;
                }
                dispenser.GetComponent<itemScript>().set(1,1);
                Dispense(dispenser.transform, itemID, itemValue);
            }
        }

        if(other.name == "PlacementCube")
        {
            if (other.GetComponent<PlacementScript>().getDelete())
            {
                Destroy(gameObject);
            }
        }
        
    }

    void Dispense(Transform dispensed, int itemID, int itemValue)
    {
        switch (transform.eulerAngles.z)
        {
            case 0:
                sp = new Vector3(transform.position.x, transform.position.y + 1, -1);
                break;
            case 90:
                sp = new Vector3(transform.position.x - 1, transform.position.y, -1);
                break;
            case 270:
                sp = new Vector3(transform.position.x + 1, transform.position.y, -1);
                break;
            case 180:
                sp = new Vector3(transform.position.x, transform.position.y - 1, -1);
                break;
        }
        GameObject go = Instantiate(dispensed, sp, rot).gameObject;
        go.GetComponent<itemScript>().set(itemID, itemValue);
    }
}
