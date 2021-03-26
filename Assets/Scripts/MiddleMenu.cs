using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleMenu : MonoBehaviour
{
    public static bool middleMenuOpen = false;

    public GameObject middleMenu;

    // Update is called once per frame
    void Update()
    {
        print(middleMenuOpen);
        if (middleMenuOpen)
        {
            EnterMenu();
        }
    }

    public void ExitMenu()
    {
        middleMenu.SetActive(false);
        Time.timeScale = 1f;
        middleMenuOpen = false;
        General.setGameStatus(true);
    }
    void EnterMenu()
    {
        middleMenu.SetActive(true);
        Time.timeScale = 0f;
        General.setGameStatus(false);
    }

    public static void openMenu(bool menuStatus)
    {
        middleMenuOpen = menuStatus;
    }
}
