using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverterScript : MonoBehaviour
{
    Vector2 dir;

    private string outputSide;

    // Start is called before the first frame update
    void Start()
    {
        outputSide = "RIGHT";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "item")
        {

            Dispense(other.transform, other.GetComponent<itemScript>().getID(), other.GetComponent<itemScript>().getValue());
            other.GetComponent<itemScript>().Remove();

            if(outputSide == "RIGHT")
            {
                outputSide = "LEFT";
            }
            else
            {
                outputSide = "RIGHT";
            }
        }
    }

    void Dispense(Transform dispensed, int itemID, int itemValue)
    {
        Vector3 sp = new Vector3(transform.position.x, transform.position.y + 1, -1);
        Quaternion rot = new Quaternion(0, 0, 0, 0);

        switch (transform.eulerAngles.z)
        {
            case 0:
                if(outputSide == "RIGHT")
                {
                    sp = new Vector3(transform.position.x + 0.75f, transform.position.y, -1);
                }
                else
                {
                    sp = new Vector3(transform.position.x - 0.75f, transform.position.y, -1);
                }
                //sp = new Vector3(transform.position.x, transform.position.y + 0.5f, -1);
                break;
            case 90:
                if (outputSide == "RIGHT")
                {
                    sp = new Vector3(transform.position.x, transform.position.y + 0.75f, -1);
                }
                else
                {
                    sp = new Vector3(transform.position.x, transform.position.y - 0.75f, -1);
                }
                //sp = new Vector3(transform.position.x - 0.5f, transform.position.y, -1);
                break;
            case 270:
                if (outputSide == "RIGHT")
                {
                    sp = new Vector3(transform.position.x, transform.position.y - 0.75f, -1);
                }
                else
                {
                    sp = new Vector3(transform.position.x, transform.position.y + 0.5f, -1);
                }
                //sp = new Vector3(transform.position.x + 0.5f, transform.position.y, -1);
                break;
            case 180:
                if (outputSide == "RIGHT")
                {
                    sp = new Vector3(transform.position.x - 0.5f, transform.position.y, -1);
                }
                else
                {
                    sp = new Vector3(transform.position.x + 0.5f, transform.position.y, -1);
                }
                //sp = new Vector3(transform.position.x, transform.position.y - 0.5f, -1);
                break;
        }

        GameObject go = Instantiate(dispensed, sp, rot).gameObject;
        go.GetComponent<itemScript>().set(itemID, itemValue);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "PlacementCube")
        {
            if (other.GetComponent<PlacementScript>().getDelete())
            {
                Destroy(gameObject);
            }
        }
    }

    public void setDirection(Vector2 newDir)
    {
        dir = newDir;
    }

    public float getXDirection()
    {
        return (dir.x);
    }
    public float getYDirection()
    {
        return (dir.y);
    }
}
