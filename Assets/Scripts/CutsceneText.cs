using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneText : MonoBehaviour
{
    public AudioSource audio;

    public Text speech;

    public Text loadingText;

    public GameObject nextButton;

    public GameObject mrYeeImage;

    private int time, time2;

    private bool firstFrame;

    private string speak;

    private string spoken;

    private int currChar;

    private int currSpeech;

    private bool isLoading;
    // Start is called before the first frame update
    void Start()
    {
        isLoading = false;
        loadingText.text = "";
        mrYeeImage.SetActive(false);
        currSpeech = 0;
        currChar = 0;
        speak = "";
        spoken = "";
        time = 0;
        time2 = 0;
        firstFrame = true;
    }

    // Update is called once per frame
    void Update()
    {
        time++;

        speech.text = spoken;

        if (firstFrame)
        {
            nextButton.SetActive(false);
            if (time == 50)
            {
                time = 0;
                firstFrame = false;
                speak = "Hello? Anyone there?";
            }
        }
        else
        {
            nextButton.SetActive(true);
        }

        if(speak != "")
        {
            nextButton.SetActive(false);
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            if (time == 4)
            {
                if(currChar < speak.Length)
                {
                    spoken = spoken + speak.Substring(currChar, 1);
                    currChar++;
                    time = 0;
                    
                }
                else
                {
                    speak = "";
                }
                
            }         
        }
        else
        {
            audio.Stop();
        }

        if (isLoading)
        {
            time2++;
            if (time2 > 5)
            {
                time2 = 0;
                loadingText.text = loadingText.text + ".";
                if(loadingText.text == "Loading....")
                {
                    loadingText.text = "Loading";
                }
            }
        }
    }

    public void updateSpeech()
    {
        time = 0;
        currChar = 0;
        spoken = "";
        currSpeech++;
        switch (currSpeech)
        {
            case 1:
                speak = "Oh, its you.";
                break;
            case 2:
                speak = "Glad to see you are okay.";
                break;
            case 3:
                speak = "Incase you can't recognize me, I'm Mr. Yee.";
                mrYeeImage.SetActive(true);
                break;
            case 4:
                speak = "Your memory seems damaged, so let me give you a run-down of what has happened.";
                break;
            case 5:
                speak = "My students have taken over my class, and are being mind controlled by a mysterious force known as League of Legends.";
                break;
            case 6:
                speak = "They have lost all wilingness to go outside, and have booted me from my own classroom.";
                break;
            case 7:
                speak = "The only solution I can think of at the top of my head is to summon the Spirit of the Wilderness";
                break;
            case 8:
                speak = "It will require atleast 25 of every item in this game, and should be powerful enough to break the League of Legends curse.";
                break;
            case 9:
                speak = "Thankfully, I have connections to a forestry group that can help us out.";
                break;
            case 10:
                speak = "Once you get to the location, there should be a big cube in the center of the map.";
                break;
            case 11:
                speak = "This is called 'The Middle', and it will be where you will send your items to for progress and cash.";
                break;
            case 12:
                speak = "You will have access to an assortment of tools that will provide you the ability to chop wood, maneuver, and construct new products.";
                break;
            case 13:
                speak = "Thankfully, all of these items are powered by eco-friendly McNuclear Energy";
                break;
            case 14:
                speak = "Anyways, I'd like to wish you good luck, but before we get going...";
                break;
            case 15:
                speak = "I would like to say that this game is sponsored by Raid Shadow Legends. Enter code xXxYEE69xXx for 100 free gems for the first 420 users!";
                break;
            case 16:
                speak = "All right, my time has now come. To the wilderness you go!";
                isLoading = true;
                loadingText.text = "Loading";
                break;
            case 17:
                SceneManager.LoadScene("Main");
                break;
        }
    }
}
