using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forestGenScript : MonoBehaviour
{
    public int numChunks;

    static Vector2[] chunkStartPos;

    string type;

    public Transform tree;

    public Vector2 minXAndY;

    public Vector2 maxXAndY;

    public float forestDensity; // 0 to 1

    public int forestSize; // > 0
    // Start is called before the first frame update
    void Start()
    {
        chunkStartPos = createStartingPoints(numChunks);
        for(int i = 0; i < chunkStartPos.Length; i++)
        {
            int randType = Random.Range(1, 7);
            switch (randType)
            {
                case 1:
                    type = "SPRUCE";
                    break;
                case 2:
                    type = "DARKOAK";
                    break;
                case 3:
                    type = "OAK";
                    break;
                case 4: 
                    type = "CHERRY";
                    break;
                case 5:
                    type = "ACACIA";
                    break;
                case 6:
                    type = "JUNGLE";
                    break;
            }

            for(int r = 0; r < forestSize * 2; r += 2)
            {
                for(int c = 0; c < forestSize * 2; c += 2)
                {
                    Vector3 pos = new Vector3(chunkStartPos[i].x + c, chunkStartPos[i].y + r, -3);
                    generateTree(type, pos);
                }
            }
            
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector2[] createStartingPoints(int arraySize)
    {
        Vector2[] array = new Vector2[arraySize];
        float xpos, ypos;
        List<float> preXPos = new List<float>();
        preXPos.Add(0);
        List<float> preYPos = new List<float>();
        preYPos.Add(0);

        for (int i = 0; i < arraySize; i++){
            xpos = (int)Random.Range(minXAndY.x, maxXAndY.x) + 0.5f;
            ypos = (int)Random.Range(minXAndY.y, maxXAndY.y) + 0.5f;
            while( spawnInterference(xpos, ypos, preXPos, preYPos))
            {
                xpos = (int)Random.Range(minXAndY.x, maxXAndY.x) + 0.5f;
                ypos = (int)Random.Range(minXAndY.y, maxXAndY.y) + 0.5f;
            }

            preXPos.Add(xpos);
            preYPos.Add(ypos);
            array[i] = new Vector2(xpos, ypos);

        }

        return (array);
    }
    private bool spawnInterference(float x, float y, List<float> preX, List<float> preY)
    {
        for (int i = 0; i < preX.Count; i++)
        {
            if (x + forestSize * 2 >= preX[i] && x <= preX[i] + forestSize * 2 && y + forestSize * 2 >= preY[i] && y <= preY[i] + forestSize * 2)
            {
                return (true);
            }

        }
        return (false);
    }
    void generateTree(string type, Vector3 pos)
    {
        float randVal = Random.Range(0, 100);
        print(randVal);
        if(randVal / 100 <= forestDensity)
        {
            GameObject go = Instantiate(tree, pos, new Quaternion(0, 0, 0, 0)).gameObject;
            go.GetComponent<treeScript>().setType(type);
        }
        
    }

    public int getForestSize()
    {
        return forestSize;
    }
}
