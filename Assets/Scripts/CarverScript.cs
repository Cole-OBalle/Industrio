using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarverScript : MonoBehaviour
{
    public static bool inMenu;

    public GameObject carverMenu;

    Vector2 dir;

    private string product;

    // Start is called before the first frame update
    void Start()
    {
        product = "PLANK";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            switch (other.GetComponent<itemScript>().getID())
            {
                case 1: case 2: case 3: case 4: case 5: case 6:
                    Carve(other.GetComponent<itemScript>().getID());
                    break;
            }
            other.GetComponent<itemScript>().Remove();
        }
    }

    private void Carve(int id)
    {
        Transform dispenser = GameObject.Find("Item").transform;

        switch (product)
        {
            case "PLANK":
                Dispense(dispenser, id + 6, id*2);
                break;
            case "CHISEL":
                Dispense(dispenser, id + 12, id*3);
                break;
            case "ROD":
                Dispense(dispenser, id + 18, id*2);
                break;
            case "PLATE":
                Dispense(dispenser, id + 24, id*2);
                break;
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

    public void EnterMenu()
    {
        carverMenu.SetActive(true);
        Time.timeScale = 0f;
        inMenu = true;
        General.setGameStatus(false);
        General.setCarverToUpdate(gameObject);
    }

    public void LeaveMenu()
    {
        carverMenu.SetActive(false);
        Time.timeScale = 1f;
        inMenu = true;
        General.setGameStatus(true);
        General.setCarverToUpdate(null);
    }

    public void setProduction(string production)
    {
        product = production;
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
