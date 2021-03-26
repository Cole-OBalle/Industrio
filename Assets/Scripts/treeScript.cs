using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeScript : MonoBehaviour
{

    public string type;

    private int value;

    public SpriteRenderer sr;
    public Sprite OakSprite;
    public Sprite DarkOakSprite;
    public Sprite AcaciaSprite;
    public Sprite JungleSprite;
    public Sprite SpruceSprite;
    public Sprite CherrySprite;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GetComponent<forestGenScript>());
        Destroy(GetComponent<paintScript>());

        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case "OAK":
                sr.sprite = OakSprite;
                break;
            case "DARKOAK":
                sr.sprite = DarkOakSprite;
                break;
            case "ACACIA":
                sr.sprite = AcaciaSprite;
                break;
            case "JUNGLE":
                sr.sprite = JungleSprite;
                break;
            case "SPRUCE":
                sr.sprite = SpruceSprite;
                break;
            case "CHERRY":
                sr.sprite = CherrySprite;
                break;
        }
    }

    public void setType(string _type)
    {
        type = _type;
    }

    public string getType()
    {
        return type;
    }
}
