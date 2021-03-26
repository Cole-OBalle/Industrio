using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblerScript : MonoBehaviour
{
    Vector2 dir;

    int[] inventory = new int[itemScript.getNumItems()];

    Transform dispenser;

    int time;

    public GameObject assemblerMenu;
    // Inventory keeps track of number of each item that has entered it by containing an integer corresponding to the item ID.

    string product;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;

        dispenser = GameObject.Find("Item").transform;

        product = "BASIC_TABLE";
        for(int i = 0; i < inventory.Length; i++)
        {
            inventory[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        if(time >= 100)
        {
            time = 0;
            checkCraft();
        }
    }

    void checkCraft()
    {
        switch (product)
        {
            case "BASIC_TABLE":
                if(hasType("ROD", 1) && hasType("PLATE", 1))
                {
                    int value = getValue(getType("ROD", 1)) + getValue(getType("PLATE", 1) + 1);

                    Craft(dispenser, 31, value);

                    inventory[getType("ROD", 1)]--;
                    inventory[getType("PLATE", 1)]--;
                }
                break;
            case "BASIC_STOOL":
                if (hasType("ROD", 3) && hasType("PLATE", 1))
                {
                    int value = getValue(getType("ROD", 3))*3 + getValue(getType("PLATE", 1) + 1);

                    Craft(dispenser, 32, value);

                    inventory[getType("ROD", 3)] -= 3;
                    inventory[getType("PLATE", 1)]--;
                }
                break;
            case "BASIC_CHAIR":
                if (hasType("ROD", 4) && hasType("PLATE", 2))
                {
                    int value = getValue(getType("ROD", 4)) * 4 + getValue(getType("PLATE", 2) * 2 + 1);

                    Craft(dispenser, 33, value);

                    inventory[getType("ROD", 4)] -= 4;
                    inventory[getType("PLATE", 2)] -= 2;
                }
                break;
            case "FANCY_TABLE":
                if (hasType("CHISEL", 4) && hasType("PLATE", 1))
                {
                    int value = getValue(getType("CHISEL", 4)) * 4 + getValue(getType("PLATE", 1) + 3);

                    Craft(dispenser, 34, value);

                    inventory[getType("CHISEL", 4)] -= 4;
                    inventory[getType("PLATE", 1)] -= 1;
                }
                break;
            case "FANCY_STOOL":
                if (hasType("CHISEL", 3) && hasType("PLATE", 1))
                {
                    int value = getValue(getType("CHISEL", 3)) * 3 + getValue(getType("PLATE", 1) + 3);

                    Craft(dispenser, 35, value);

                    inventory[getType("CHISEL", 3)] -= 3;
                    inventory[getType("PLATE", 1)] -= 1;
                }
                break;
            case "FANCY_CHAIR":
                if (hasType("CHISEL", 4) && hasType("PLATE", 1) && hasType("PLANK", 2))
                {
                    int value = getValue(getType("CHISEL", 4)) * 4 + getValue(getType("PLATE", 1) + getValue(getType("PLANK", 2)) * 2 + 3);

                    Craft(dispenser, 36, value);

                    inventory[getType("CHISEL", 4)] -= 4;
                    inventory[getType("PLANK", 2)] -= 2;
                    inventory[getType("PLATE", 1)] -= 1;
                }
                break;
            case "CRATE":
                if (hasType("PLATE", 6))
                {
                    int value = getValue(getType("PLATE", 6)) * 6 + 1;

                    Craft(dispenser, 37, value);

                    inventory[getType("PLATE", 6)] -= 6;
                }
                break;
            case "BASIC_BED":
                if (hasType("PLANK", 6) && hasType("PLATE", 2) && hasType("ROD", 4))
                {
                    int value = getValue(getType("PLANK", 6)) * 6  + getValue(getType("PLATE",2)) * 2 + getValue(getType("ROD", 4)) * 4 + 1;

                    Craft(dispenser, 38, value);

                    inventory[getType("PLANK", 6)] -= 6;
                    inventory[getType("PLATE", 2)] -= 2;
                    inventory[getType("ROD", 4)] -= 4;
                }
                break;
            case "FANCY_BED":
                if (hasType("PLANK", 8) && hasType("PLATE", 2) && hasType("CHISEL", 4))
                {
                    int value = getValue(getType("PLANK", 8)) * 8 + getValue(getType("PLATE", 2)) * 2 + getValue(getType("CHISEL", 4)) * 4 + 3;

                    Craft(dispenser, 39, value);

                    inventory[getType("PLANK", 8)] -= 8;
                    inventory[getType("PLATE", 2)] -= 2;
                    inventory[getType("CHISEL", 4)] -= 4;
                }
                break;
            case "MODEL_HOUSE":
                if (inventory[37] > 0 && hasType("PLATE", 2) )
                {
                    int value = 36 + getValue(getType("PLATE", 2)) * 2 + 1;

                    Craft(dispenser, 40, value);

                    inventory[37] -= 1;
                    inventory[getType("PLATE", 2)] -= 2;
                }
                break;
            case "BASIC_DOLL_HOUSE":
                if (inventory[40] > 0 && inventory[38] > 0 && inventory[31] > 0 && inventory[33] > 1 )
                {
                    int value = 175;

                    Craft(dispenser, 41, value);

                    inventory[40] -= 1;
                    inventory[38] -= 1;
                    inventory[31] -= 1;
                    inventory[33] -= 2;
                }
                break;
             case "FANCY_DOLL_HOUSE":
                if (inventory[40] > 1 && inventory[39] > 1 && inventory[34] > 2 && inventory[36] > 5)
                {
                    int value = 200;

                    Craft(dispenser, 42, value);

                    inventory[40] -= 2;
                    inventory[39] -= 2;
                    inventory[34] -= 3;
                    inventory[36] -= 6;
                }
                break;
            case "DRAWER":
                if (hasType("PLANK", 4) && hasType("PLATE", 1))
                {
                    int value = getValue(getType("PLANK", 4)) * 4 + getValue(getType("PLATE", 1) + 1);

                    Craft(dispenser, 43, value);

                    inventory[getType("PLANK", 4)] -= 4;
                    inventory[getType("PLATE", 1)] -= 1;
                }
                break;
            case "BASIC_CABINET":
                if (hasType("PLATE", 4) && inventory[43] > 3)
                {
                    int value = getValue(getType("PLATE", 4)) * 4 + 75;

                    Craft(dispenser, 44, value);

                    inventory[43] -= 4;
                    inventory[getType("PLATE", 4)] -= 4;
                }
                break;
            case "FANCY_CABINET":
                if (hasType("PLANK", 4) &&  hasType("PLATE", 2) && inventory[43] > 5)
                {
                    int value = getValue(getType("PLANK", 4)) * 4 + getValue(getType("PLATE", 2)) * 2 + 100;

                    Craft(dispenser, 45, value);

                    inventory[43] -= 6;
                    inventory[getType("PLATE", 2)] -= 2;
                    inventory[getType("PLANK", 4)] -= 4;
                }
                break;
            case "BEDNIGHT_STAND":
                if (hasType("PLATE", 2) && hasType("PLANK", 2) && inventory[43] > 0)
                {
                    int value = getValue(getType("PLANK", 2)) * 2 + getValue(getType("PLATE", 2)) * 2 + 50;

                    Craft(dispenser, 46, value);

                    inventory[43] -= 1;
                    inventory[getType("PLATE", 2)] -= 2;
                    inventory[getType("PLANK", 2)] -= 2;
                }
                break;
            case "WOOD_BLADE":
                if (hasType("PLANK", 2))
                {
                    int value = getValue(getType("PLANK", 2)) * 2;

                    Craft(dispenser, 47, value);

                    inventory[getType("PLANK", 2)] -= 2;
                }
                break;
            case "MODEL_PLANE":
                if (hasType("PLANK", 4) && inventory[47] > 3)
                {
                    int value = getValue(getType("PLANK", 4)) * 4 + 25;

                    Craft(dispenser, 48, value);

                    inventory[47] -= 4;
                    inventory[getType("PLANK", 4)] -= 4;
                }
                break;
            case "WAIFU_SCULPTURE":
                if (hasType("CHISEL", 4) && inventory[47] > 0)
                {
                    int value = getValue(getType("CHISEL", 4)) * 4 + 200;

                    Craft(dispenser, 49, value);

                    inventory[47] -= 1;
                    inventory[getType("CHISEL", 4)] -= 4;
                }
                break;
            case "WHEEL":
                if (hasType("PLATE", 2))
                {
                    int value = getValue(getType("PLATE", 2)) * 2;

                    Craft(dispenser, 50, value);

                    inventory[getType("PLATE", 2)] -= 2;
                }
                break;
            case "CAR":
                if (hasType("PLATE", 8) && hasType("ROD", 10) && inventory[50] > 4 && inventory[36] > 3 )
                {
                    int value = getValue(getType("PLATE", 8)) * 8 + getValue(getType("ROD", 10)) * 10 + 100;

                    Craft(dispenser, 51, value);

                    inventory[50] -= 5;
                    inventory[36] -= 4;
                    inventory[getType("PLATE", 8)] -= 8;
                    inventory[getType("ROD", 10)] -= 10;
                }
                break;
            case "TANK":
                if (hasType("PLATE", 12) && inventory[50] > 11 && inventory[37] > 3)
                {
                    int value = getValue(getType("PLATE", 12)) * 12 + 200;

                    Craft(dispenser, 52, value);

                    inventory[50] -= 12;
                    inventory[37] -= 3;
                    inventory[getType("PLATE", 12)] -= 12;
                }
                break;
            case "DESK":
                if (hasType("PLANK", 2) && hasType("ROD", 4) &&  inventory[43] > 1)
                {
                    int value = getValue(getType("PLANK", 2)) * 2 + getValue(getType("ROD", 4)) * 4 + 50;

                    Craft(dispenser, 53, value);

                    inventory[43] -= 2;
                    inventory[getType("PLANK", 2)] -= 2;
                    inventory[getType("ROD", 4)] -= 4;
                }
                break;
            case "SUPREME_GAMING_DESK":
                if (hasType("PLANK", 2) && hasType("CHISEL", 4) && inventory[46] > 1)
                {
                    int value = getValue(getType("PLANK", 2)) * 2 + getValue(getType("CHISEL", 4)) * 4 + 200;

                    Craft(dispenser, 53, value);

                    inventory[46] -= 2;
                    inventory[getType("CHISEL", 4)] -= 4;
                    inventory[getType("PLANK", 2)] -= 2;
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "item")
        {
            inventory[other.GetComponent<itemScript>().getID()]++;
        }

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

    void Craft(Transform dispensed, int itemID, int itemValue)
    {

        Vector3 sp = new Vector3(transform.position.x, transform.position.y + 1, -1);
        Quaternion rot = new Quaternion(0, 0, 0, 0);

        switch (transform.eulerAngles.z)
        {
            case 0:
                sp = new Vector3(transform.position.x, transform.position.y + 1.75f, -1);
                break;
            case 90:
                sp = new Vector3(transform.position.x - 1.75f, transform.position.y, -1);
                break;
            case 270:
                sp = new Vector3(transform.position.x + 1.75f, transform.position.y, -1);
                break;
            case 180:
                sp = new Vector3(transform.position.x, transform.position.y - 1.75f, -1);
                break;
        }
        GameObject go = Instantiate(dispensed, sp, rot).gameObject;
        go.GetComponent<itemScript>().set(itemID, itemValue);
    }

    bool hasType(string type, int amount)
    {
        int lowIndex = 0, highIndex = 0;

        switch (type)
        {
            case "PLANK":
                lowIndex = 7;
                highIndex = 12;
                break;
            case "CHISEL":
                lowIndex = 13;
                highIndex = 18;
                break;
            case "ROD":
                lowIndex = 19;
                highIndex = 24;
                break;
            case "PLATE":
                lowIndex = 25;
                highIndex = 30;
                break;
        }

        for(int i = lowIndex; i < highIndex + 1; i++)
        {
            if(inventory[i] >= amount)
            {
                return (true);
            }

        }
        return (false);
    }
    int getType(string type, int amount)
    {
        if (hasType(type, amount))
        {
            int lowIndex = 0, highIndex = 0;

            switch (type)
            {
                case "PLANK":
                    lowIndex = 7;
                    highIndex = 12;
                    break;
                case "CHISEL":
                    lowIndex = 13;
                    highIndex = 18;
                    break;
                case "ROD":
                    lowIndex = 19;
                    highIndex = 24;
                    break;
                case "PLATE":
                    lowIndex = 25;
                    highIndex = 30;
                    break;
            }

            for (int i = lowIndex; i < highIndex + 1; i++)
            {
                if (inventory[i] >= amount)
                {
                    return (i);
                }

            }
        }
        return (0);
    }

    int getValue(int index)
    {
        switch (index)
        {
            case 1: case 2: case 3: case 4: case 5: case 6:
                return index;
            case 7: case 8: case 9: case 10: case 11: case 12:
                return index * 2;
            case 13: case 14: case 15: case 16: case 17: case 18:
                return index * 3;
            case 19: case 20: case 21: case 22: case 23: case 24:
                return index * 2;
            case 25: case 26: case 27: case 28: case 29: case 30:
                return index * 2;
        }

        return 0;
    }

    public void EnterMenu()
    {
        assemblerMenu.SetActive(true);
        Time.timeScale = 0f;
        General.setGameStatus(false);
        General.setAssemblerToUpdate(gameObject);
    }

    public void LeaveMenu()
    {
        assemblerMenu.SetActive(false);
        Time.timeScale = 1f;
        General.setGameStatus(true);
        General.setAssemblerToUpdate(null);
    }

    public void setProduction(string production)
    {
        product = production;
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
