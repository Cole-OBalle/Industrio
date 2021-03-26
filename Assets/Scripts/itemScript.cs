using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemScript : MonoBehaviour
{
    int id;
    public SpriteRenderer spriteRenderer;
    private int value;


    static int numItems = 55;
    public Sprite[] sprites = new Sprite[numItems];

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void set(int newID, int newValue)
    {
        id = newID;
        value = newValue;
        changeTexture(sprites[newID]);
    }

    private void changeTexture(Sprite newTexture) {
        spriteRenderer.sprite = newTexture;
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Conveyor"))
        {
            transform.Translate(-.05f * other.GetComponent<MovementonConveyor>().getXDirection(), -.05f * other.GetComponent<MovementonConveyor>().getYDirection(), 0);
        }
        else if (other.name == "TheMiddle")
        {
            Destroy(gameObject);
            General.changeCash(value);
        }
        else if (other.name.Contains("Assembler"))
        {
            Destroy(gameObject);

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name.Contains("Conveyor"))
        {
            transform.Translate(.05f * other.GetComponent<MovementonConveyor>().getXDirection(), .05f * other.GetComponent<MovementonConveyor>().getYDirection(), 0);
        }
    }
    public int getID()
    {
        return id;
    }

    public int getValue()
    {
        return value;
    }

    public static int getNumItems()
    {
        return (numItems);
    }
}
