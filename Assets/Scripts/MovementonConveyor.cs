using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementonConveyor : MonoBehaviour
{
    Vector2 dir;

    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {

    }

    //conveyorspeed for items is 1.6f

    // Update is called once per frame
    void Update()
    {
        sr.sprite = General.getConveyorSprite();
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
        return(dir.y);
    }

    
}
