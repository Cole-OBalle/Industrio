using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilterScript : MonoBehaviour
{
    Vector2 dir;

    int filterID;

    public GameObject filterMenu;
    // Start is called before the first frame update
    void Start()
    {
        filterID = 0;
        transform.Translate(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            if(other.GetComponent<itemScript>().getID() == filterID)
            {
                Dispense(other.transform, other.GetComponent<itemScript>().getID(), other.GetComponent<itemScript>().getValue());
                other.GetComponent<itemScript>().Remove();
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
                sp = new Vector3(transform.position.x, transform.position.y + 0.75f, -1);
                break;
            case 90:
                sp = new Vector3(transform.position.x - 0.75f, transform.position.y, -1);
                break;
            case 270:
                sp = new Vector3(transform.position.x + 0.75f, transform.position.y, -1);
                break;
            case 180:
                sp = new Vector3(transform.position.x, transform.position.y - 0.75f, -1);
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
    public void EnterMenu()
    {
        filterMenu.SetActive(true);
        Time.timeScale = 0f;
        General.setGameStatus(false);
        General.setFilterToUpdate(gameObject);
    }

    public void LeaveMenu()
    {
        filterMenu.SetActive(false);
        Time.timeScale = 1f;
        General.setGameStatus(true);
        General.setFilterToUpdate(null);
    }

    public void setFilter(InputField input)
    {
        int newFilterID;
        if(int.TryParse(input.text, out newFilterID))
        {
            filterID = newFilterID;
        }
        else
        {
            newFilterID = 0;
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
