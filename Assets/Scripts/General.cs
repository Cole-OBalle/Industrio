using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class General : MonoBehaviour
{
    static int cash;

    public Text cashText;

    public Text mousePositionText;

    public Transform placementCube;

    public static GameObject carverToUpdate;
    public static GameObject filterToUpdate;
    public static GameObject assemblerToUpdate;
    public GameObject gameCompleteButton;

    public bool gameComplete;

    public Sprite[] conveyorSprite = new Sprite[10];
    static int currConveyorSprite;
    static int time;

    public static bool paused;
    // Start is called before the first frame update
    void Start()
    {
        gameComplete = false;
        gameCompleteButton.SetActive(false);
        cash = 125;
        cashText.text = ": 100";
        currConveyorSprite = 0;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameComplete)
        {
            SceneManager.LoadScene("End");
        }
        mousePositionText.text = "X:" + placementCube.position.x + " | Y:" + placementCube.position.y;

        if (!paused)
        {
            time++;
            if (time >= 30)
            {
                time = 0;
            }
            currConveyorSprite = time / 3;
            cashText.text = ": " + cash;
        }

        if (MiddleScript.getGameCompletion())
        {
            gameCompleteButton.SetActive(true);
        }
        
    }

    public static void changeCash(int change)
    {
        cash += change;
    }

    public static void setGameStatus(bool status)
    {
        paused = !status;
    }

    public static void setCarverToUpdate(GameObject carver)
    {
        carverToUpdate = carver;
    }

    public void updateCarver(string newProduction)
    {
        carverToUpdate.GetComponent<CarverScript>().setProduction(newProduction);
        carverToUpdate.GetComponent<CarverScript>().LeaveMenu();
    }

    public static void setAssemblerToUpdate(GameObject assembler)
    {
        assemblerToUpdate = assembler;
    }

    public void updateAssembler(string newProduction)
    {
        assemblerToUpdate.GetComponent<AssemblerScript>().setProduction(newProduction);
        assemblerToUpdate.GetComponent<AssemblerScript>().LeaveMenu();
    }

    public static void setFilterToUpdate(GameObject filter)
    {
        filterToUpdate = filter;
    }

    public void updateFilter(InputField input)
    {
        filterToUpdate.GetComponent<FilterScript>().setFilter(input);
        filterToUpdate.GetComponent<FilterScript>().LeaveMenu();
    }

    public void GameComplete()
    {
        gameComplete = true;
    }

    public static Sprite getConveyorSprite()
    {
        return (Camera.main.GetComponent<General>().conveyorSprite[currConveyorSprite]);
    }

    public static int getCash()
    {
        return(cash);
    }
}
