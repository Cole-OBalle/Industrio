using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paintScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBlockPlaced(string block, Vector2 blockDir)
    {
        switch (block)
        {
            case "CHOPPER":
                gameObject.AddComponent<ChopperScript>();
                BoxCollider bc = gameObject.AddComponent<BoxCollider>();
                bc.isTrigger = true;
                General.changeCash(-15);
                break;
            case "CONVEYOR":
                gameObject.GetComponent<MovementonConveyor>().setDirection(blockDir);
                General.changeCash(-5);
                break;
            case "CARVER":
                gameObject.GetComponent<CarverScript>().setDirection(blockDir);
                General.changeCash(-100);
                break;
            case "TREE":
                gameObject.transform.Translate(0.5f, 0.5f, 0);
                int currentTree = PlacementScript.getCurrentTree();
                switch (currentTree)
                {
                    case 0:
                        gameObject.GetComponent<treeScript>().setType("OAK");
                        General.changeCash(-100);
                        break;
                    case 1:
                        gameObject.GetComponent<treeScript>().setType("SPRUCE");
                        General.changeCash(-200);
                        break;
                    case 2:
                        gameObject.GetComponent<treeScript>().setType("DARKOAK");
                        General.changeCash(-500);
                        break;
                    case 3:
                        gameObject.GetComponent<treeScript>().setType("ACACIA");
                        General.changeCash(-400);
                        break;
                    case 4:
                        gameObject.GetComponent<treeScript>().setType("JUNGLE");
                        General.changeCash(-300);
                        break;
                    case 5:
                        gameObject.GetComponent<treeScript>().setType("CHERRY");
                        General.changeCash(-600);
                        break;
                }
                break;
            case "ASSEMBLER":
                gameObject.GetComponent<AssemblerScript>().setDirection(blockDir);
                General.changeCash(-700);
                break;
            case "FILTER":
                gameObject.GetComponent<FilterScript>().setDirection(blockDir);
                General.changeCash(-200);
                break;
            case "DIVERTER":
                gameObject.GetComponent<DiverterScript>().setDirection(blockDir);
                General.changeCash(-100);
                break;
        }

        Destroy(GetComponent<PlacementScript>());
    }
}
