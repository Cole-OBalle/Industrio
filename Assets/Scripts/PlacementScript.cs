using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementScript : MonoBehaviour
{
    int x;
    int y;
    Vector3 MousePos;

    float screenWidth;
    float screenHeight;
    float pixelsPerSquare;

    public Transform obj;
    Vector3 sp = new Vector3(0, 0, 0);
    Quaternion rot = new Quaternion(0, 0, 0, 0);

    public Transform mainCamera;

    public AudioSource audio;

    public RawImage Selector;
    public RawImage conveyorFrame;
    public RawImage chopperFrame;
    public RawImage carverFrame;
    public RawImage treeSeedsFrame;
    public RawImage assemblerFrame;
    public RawImage filterFrame;
    public RawImage diverterFrame;

    public Image directionSelector;
    public Sprite DS_UP;
    public Sprite DS_DOWN;
    public Sprite DS_LEFT;
    public Sprite DS_RIGHT;

    public RawImage treeSelector;
    public Image TS_image;
    public Text TS_cost;
    public Sprite[] tsImages = new Sprite[6];

    string blockPlaced;
    int blockPlacedVal;
    Vector2 blockDir;

    bool deleted;

    bool placeable;

    static int currTree;

    bool placingTree;

    // Start is called before the first frame update
    void Start()
    {
        TS_cost.text = 100 + " Yc";

        placingTree = false;

        directionSelector.sprite = DS_UP;

        directionSelector.enabled = true;
        treeSelector.enabled = false;
        TS_image.enabled = false;

        currTree = 0;

        placeable = true;

        y = 0;
        x = 0;

        screenHeight = Screen.height;
        screenWidth = Screen.width;
        pixelsPerSquare = Screen.height / 2 / Camera.main.orthographicSize;

        obj = GameObject.Find("Conveyor").transform;
        blockPlaced = "CONVEYOR";
        blockPlacedVal = 0;
        blockDir = new Vector2(0, 1);

        deleted = false;

        Selector.transform.position = conveyorFrame.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(currTree < 0)
        {
            currTree = 5;
        }
        else if(currTree > 5)
        {
            currTree = 0;
        }

        if (placingTree)
        {
            treeSelector.enabled = true;
            TS_image.enabled = true;
            directionSelector.enabled = false;
            TS_image.sprite = tsImages[currTree];
            switch (currTree)
            {
                case 0:
                    blockPlacedVal = 100;
                    TS_cost.text = 100 + " Yc";
                    break;
                case 1:
                    blockPlacedVal = 200;
                    TS_cost.text = 200 + " Yc";
                    break;
                case 2:
                    blockPlacedVal = 500;
                    TS_cost.text = 500 + " Yc";
                    break;
                case 3:
                    blockPlacedVal = 400;
                    TS_cost.text = 400 + " Yc";
                    break;
                case 4:
                    blockPlacedVal = 300;
                    TS_cost.text = 300 + " Yc";
                    break;
                case 5:
                    blockPlacedVal = 600;
                    TS_cost.text = 600 + " Yc";
                    break;
            }
        }
        else
        {
            directionSelector.enabled = true;
            treeSelector.enabled = false;
            TS_image.enabled = false;
        }


        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float xAdjust = 0, yAdjust = 0;
        if (MousePos.x > 0)
        {
            xAdjust = 0.5f;
        }
        else if (MousePos.x < 0)
        {
            xAdjust = -0.5f;
        }

        if ((MousePos.y > 0))
        {
            yAdjust = 0.5f;
        }
        else if(MousePos.y < 0)
        {
            yAdjust = -0.5f;
        }

        x = (int)(MousePos.x + xAdjust);
        y = (int)(MousePos.y + yAdjust);
        

        transform.position = new Vector3((float)x, (float)y, 0);
        sp = transform.position;

        if (Input.GetMouseButtonDown(1) && placeable)
        {
            paint();
            deleted = false;
        }

        deleted = Input.GetMouseButton(0);

        if (deleted)
        {
            placeable = true;
        }

        if (Input.GetKeyDown("f"))
        {
            if (placingTree)
            {
                currTree--;
            }
            else
            {
                directionSelector.sprite = DS_LEFT;
                rot.eulerAngles = new Vector3(0, 0, 90);
                blockDir = new Vector2(-1,0);
            } 
        }
        else if (Input.GetKeyDown("h"))
        {
            if (placingTree)
            {
                currTree++;
            }
            else
            {
                directionSelector.sprite = DS_RIGHT;
                rot.eulerAngles = new Vector3(0, 0, -90);
                blockDir = new Vector2(1, 0);
            }   
        }
        else if (Input.GetKeyDown("t"))
        {
            if (!placingTree)
            {
                directionSelector.sprite = DS_UP;
                rot.eulerAngles = new Vector3(0, 0, 0);
                blockDir = new Vector2(0, 1);
            }
            
        }
        else if (Input.GetKeyDown("g"))
        {
            if (!placingTree)
            {
                directionSelector.sprite = DS_DOWN;
                rot.eulerAngles = new Vector3(0, 0, 180);
                blockDir = new Vector2(0, -1);
            } 
        }

        if (Input.GetKey("1"))
        {
            placingTree = false;
            obj = GameObject.Find("Conveyor").transform;
            Selector.transform.position = conveyorFrame.transform.position;
            blockPlaced = "CONVEYOR";
            blockPlacedVal = 5;
        }
        else if (Input.GetKey("2"))
        {
            placingTree = false;
            obj = GameObject.Find("Chopper").transform;
            Selector.transform.position = chopperFrame.transform.position;
            blockPlaced = "CHOPPER";
            blockPlacedVal = 15;
        }
        else if (Input.GetKey("3"))
        {
            placingTree = false;
            obj = GameObject.Find("Carver").transform;
            Selector.transform.position = carverFrame.transform.position;
            blockPlaced = "CARVER";
            blockPlacedVal = 100;
        }
        else if (Input.GetKey("4"))
        {
            placingTree = true;
            obj = GameObject.Find("Tree").transform;
            Selector.transform.position = treeSeedsFrame.transform.position;
            blockPlaced = "TREE";
        }
        else if (Input.GetKey("5"))
        {
            placingTree = false;
            obj = GameObject.Find("Assembler").transform;
            Selector.transform.position = assemblerFrame.transform.position;
            blockPlaced = "ASSEMBLER";
            blockPlacedVal = 700;
        }
        else if (Input.GetKey("6"))
        {
            placingTree = false;
            obj = GameObject.Find("Filter").transform;
            Selector.transform.position = filterFrame.transform.position;
            blockPlaced = "FILTER";
            blockPlacedVal = 200;
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            placingTree = false;
            obj = GameObject.Find("Diverter").transform;
            Selector.transform.position = diverterFrame.transform.position;
            blockPlaced = "DIVERTER";
            blockPlacedVal = 100;
        }
    }
    void paint()
    {
        if (General.getCash() > 0 && General.getCash() - blockPlacedVal >= 0)
        {
            audio.Play();
            GameObject go = Instantiate(obj, sp, rot).gameObject;
            go.AddComponent<paintScript>();
            go.GetComponent<paintScript>().setBlockPlaced(blockPlaced, blockDir);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name.Contains("Conveyor") || other.name.Contains("Chopper") || other.name.Contains("Carver") || other.name == "TheMiddle" || other.name.Contains("Assembler") || other.name.Contains("Diverter") || other.name.Contains("Filter"))
        {
            placeable = false;
        }
        else if (other.name.Contains("Tree"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (other.GetComponent<treeScript>().getType())
                {
                    case "OAK":
                        General.changeCash(1);
                        break;
                    case "SPRUCE":
                        General.changeCash(2);
                        break;
                    case "DARKOAK":
                        General.changeCash(5);
                        break;
                    case "ACACIA":
                        General.changeCash(4);
                        break;
                    case "JUNGLE":
                        General.changeCash(3);
                        break;
                    case"CHERRY":
                        General.changeCash(6);
                        break;
                }
            }
        }

        if (other.name.Contains("Carver"))
        {
            if (Input.GetMouseButtonDown(1))
            {
                other.GetComponent<CarverScript>().EnterMenu();
            }
        }
        else if(other.name == "TheMiddle")
        {
            if (Input.GetMouseButtonDown(1))
            {
                MiddleMenu.openMenu(true);
            }
        }
        else if (other.name.Contains("Filter"))
        {
            if (Input.GetMouseButtonDown(1))
            {
                other.GetComponent<FilterScript>().EnterMenu();
            }
        }
        else if (other.name.Contains("Assembler"))
        {
            if (Input.GetMouseButtonDown(1))
            {
                other.GetComponent<AssemblerScript>().EnterMenu();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        placeable = true;
    }

    public bool getDelete()
    {
        return (deleted);
    }

    public static int getCurrentTree()
    {
        return (currTree);
    }
}
