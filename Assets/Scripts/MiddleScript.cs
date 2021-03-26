using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiddleScript : MonoBehaviour
{
    int[] inventory = new int[itemScript.getNumItems()];

    public Text MiddleMenuText;

    public static bool gameComplete;
    // Start is called before the first frame update
    void Start()
    {
        gameComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        printStats();
        if (checkCompletion())
        {
            gameComplete = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "item")
        {
            inventory[other.GetComponent<itemScript>().getID()]++;
        }
    }

    private bool checkCompletion()
    {
        for(int i = 1; i < inventory.Length; i++)
        {
            if(inventory[i] < 25)
            {
                return false;
            }
        }
        return true;
    }

    private void printStats()
    {
        MiddleMenuText.text = "| Oak Wood" + inventory[1] +
            "| Spruce Wood: " + inventory[2] +
            "| Jungle Wood: " + inventory[3] +
            "| Acacia Wood: " + inventory[4] +
            "| Dark Oak Wood: " + inventory[5] +
            "| Cherry Wood: " + inventory[6] +
            "| Oak Wood Planks: " + inventory[7] +
            "| Spruce Wood Planks: " + inventory[8] +
            "| Jungle Wood Planks: " + inventory[9] +
            "| Acacia Wood Planks: " + inventory[10] +
            "| Dark Oak Wood Planks: " + inventory[11] +
            "| Cherry Wood Planks: " + inventory[12] +
            "| Oak Wood Chisel: " + inventory[13] +
            "| Spruce Wood Chisel: " + inventory[14] +
            "| Jungle Wood Chisel: " + inventory[15] +
            "| Acacia Wood Chisel: " + inventory[16] +
            "| Dark Oak Wood Chisel: " + inventory[17] +
            "| Cherry Wood Chisel: " + inventory[18] +
            "| Oak Wood Rod: " + inventory[19] +
            "| Spruce Wood Rod: " + inventory[20] +
            "| Jungle Wood Rod: " + inventory[21] +
            "| Acacia Wood Rod: " + inventory[22] +
            "| Dark Oak Wood Rod: " + inventory[23] +
            "| Cherry Wood Rod: " + inventory[24] +
            "| Oak Wood Plate: " + inventory[25] +
            "| Spruce Wood Plate: " + inventory[26] +
            "| Jungle Wood Plate: " + inventory[27] +
            "| Acacia Wood Plate: " + inventory[28] +
            "| Dark Oak Wood Plate: " + inventory[29] +
            "| Cherry Wood Plate: " + inventory[30] +
            "| Basic Table: " + inventory[31] +
            "| Basic Stool: " + inventory[32] +
            "| Basic Chair: " + inventory[33] +
            "| Fancy Table: " + inventory[34] +
            "| Fancy Stool: " + inventory[35] +
            "| Fancy Chair: " + inventory[36] +
            "| Crate: " + inventory[37] +
            "| Basic Bed: " + inventory[38] +
            "| Fancy Bed: " + inventory[39] +
            "| Model House: " + inventory[40] +
            "| Basic Doll House: " + inventory[41] +
            "| Fancy Doll House:" + inventory[42] +
            "| Drawer: " + inventory[43] +
            "| Basic Cabinet: " + inventory[44] +
            "| Fancy Cabinet: " + inventory[45] +
            "| Bed-night Stand: " + inventory[46] +
            "| Wood Blade: " + inventory[47] +
            "| Model Plane: " + inventory[48] +
            "| Waifu Sculpture: " + inventory[49] +
            "| Wheel: " + inventory[50] +
            "| Car: " + inventory[51] +
            "| Tank: " + inventory[52] +
            "| Desk: " + inventory[53] +
            "| Supreme Gaming Desk: " + inventory[54];
    }
    public static bool getGameCompletion()
    {
        return gameComplete;
    }
}
