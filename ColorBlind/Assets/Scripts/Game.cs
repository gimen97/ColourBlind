using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using TMPro;

[DisallowMultipleComponent]
public class Game : MonoBehaviour
{

    //Variable for prefabs.
    [SerializeField]
    public GameObject[] pref;

    //Variable for location of the panels.
    public GameObject[] panel;

    //Variable for Questions.
    string[] questions = { "Blue Sphere", "Green Sphere", "Red Sphere", "Blue Square", "Green Square", "Red Square", "Blue Triangle", "Green Triangle", "Red Triangle" };

    //Text for the Question.
    GameObject questionTexts;

    //NAme of all the prefabs
    static GameObject prefab1, prefab2, prefab3, prefab4, prefab5, prefab6, prefab7, prefab8, prefab9;

    //list of the prefabs.
    List<GameObject> prefab;

    //variable for all the Panes.
    GameObject firstPane, secondPane, thirdPane, fourthPane, fifthtPane, sixthPane;

    //Background collour of the Game
    public GameObject backgroundTop, backgroundMiddle, backgroundBottom;

    //Timer
    GameObject theTimer;

    //Colours
    Color blue = new Color(0,0.5686275f,1);
    Color red = new Color(0.8490566f, 0.1321645f, 0.132f);
    Color green = new Color(0.01254893f,0.7960784f,0.057f);
    List<Color> colours = new List<Color>();

    // Use this for initialization
    void Start()
    {
        //Adding the colours to the list of colours
        colours = new List<Color> { red, green, blue };

        //New background Colour
        BackgroundColour(backgroundTop, backgroundMiddle, backgroundBottom);

        //Playing the game sound
        AudioManager.instance.Play("Game");﻿

        //Variables of the objects
        GameObject prefab10, prefab11, prefab12, prefab13, prefab14, prefab15;

        //Instantiating all the Prefabs.
        prefab1 = Instantiate(pref[0]) as GameObject;
        prefab2 = Instantiate(pref[1]) as GameObject;
        prefab3 = Instantiate(pref[2]) as GameObject;
        prefab4 = Instantiate(pref[3]) as GameObject;
        prefab5 = Instantiate(pref[4]) as GameObject;
        prefab6 = Instantiate(pref[5]) as GameObject;
        prefab7 = Instantiate(pref[6]) as GameObject;
        prefab8 = Instantiate(pref[7]) as GameObject;
        prefab9 = Instantiate(pref[8]) as GameObject;

        prefab = new List<GameObject>
        {
            //Adds the prefabs to the list.
            prefab1,
            prefab2,
            prefab3,
            prefab4,
            prefab5,
            prefab6,
            prefab7,
            prefab8,
            prefab9
        };

        //Adding all the prefabs to the fist panel 
        //so it keeps the size of the panels.
        prefab1.transform.SetParent(panel[0].transform, false);
        prefab2.transform.SetParent(panel[0].transform, false);
        prefab3.transform.SetParent(panel[0].transform, false);
        prefab4.transform.SetParent(panel[0].transform, false);
        prefab5.transform.SetParent(panel[0].transform, false);
        prefab6.transform.SetParent(panel[0].transform, false);
        prefab7.transform.SetParent(panel[0].transform, false);
        prefab8.transform.SetParent(panel[0].transform, false);
        prefab9.transform.SetParent(panel[0].transform, false);

        //Randomises the question
        questionTexts = GameObject.FindWithTag("Question");
        //questionTexts.GetComponent<Text>().text = questions[Random.Range(0, 9)];
        questionTexts.GetComponent<TextMeshProUGUI>().text = questions[Random.Range(0, 9)];
        //Choosing a random colour
        questionTexts.GetComponent<TextMeshProUGUI>().color = colours[Random.Range(0, 3)];
        string fakeColour = WordColour(questionTexts);
        //Finds the shape corresponding to the answer
        var answer = GameObject.FindWithTag(questionTexts.GetComponent<TextMeshProUGUI>().text);
        //Getting the fake object
        GameObject fakeObject = CheckColourIsSame(answer, fakeColour);

        //Setting all the prefabs off so they can't be seen.
        prefab1.SetActive(false);
        prefab2.SetActive(false);
        prefab3.SetActive(false);
        prefab4.SetActive(false);
        prefab5.SetActive(false);
        prefab6.SetActive(false);
        prefab7.SetActive(false);
        prefab8.SetActive(false);
        prefab9.SetActive(false);

        //Adding the answer to the game
        answer.SetActive(true);
        answer.transform.SetParent(panel[Random.Range(0,6)].transform, false);

        //Checking if the question text coloue is the same colour as the answer
        if (fakeObject != answer)
        {
            //setting the fake image to true 
            fakeObject.SetActive(true);
            //getting a pane for the fake image
            var paneOfFakeObject = panel[Random.Range(0, 6)].transform;
            //Checking if the answer is already a child of the fake object
            while (answer.transform.IsChildOf(paneOfFakeObject.transform))
            {
                paneOfFakeObject = panel[Random.Range(0, 6)].transform;
            }
            fakeObject.transform.SetParent(paneOfFakeObject, false);
        }

        // Making random objects
        //1.1
        //Setting It's Position
        //Checking if the prefab answer is in the panel
        if (answer.transform.IsChildOf(panel[0].transform))
        {
            prefab10 = answer;
        }
        //If the fake answer is in the Panel
        else if (fakeObject.transform.IsChildOf(panel[0].transform))
        {
            prefab10 = fakeObject;
        }
        else
        {
            prefab10 = prefab[Random.Range(0, 9)];
            //This checks if the object is already active
            while (prefab10.activeSelf)
            {
                //Debug.Log(prefab10.name + "1.2");
                prefab10 = prefab[Random.Range(0, 9)];
            }
            prefab10.SetActive(true);
            prefab10.transform.SetParent(panel[0].transform, false);
        }

        //1.2
        //Checking if the prefab is answer in the panel
        if (answer.transform.IsChildOf(panel[1].transform))
        {
            prefab11 = answer;
        }
        //If the fake answer is in the Panel
        else if (fakeObject.transform.IsChildOf(panel[1].transform))
        {
            prefab11 = fakeObject;
        }
        else
        {
            prefab11 = prefab[Random.Range(0, 9)];
            //Making sure the shape isn't already shown
            //This checks if the object is already active
            while (prefab11.activeSelf)
            {
                //Debug.Log(prefab11.name + "1.2");
                prefab11 = prefab[Random.Range(0, 9)];
            }
            //setting it active
            prefab11.SetActive(true);
            prefab11.transform.SetParent(panel[1].transform, false);
        }

        //2.1
        //Checking if the prefab is answer in the panel
        if (answer.transform.IsChildOf(panel[2].transform))
        {
            prefab12 = answer;
        }
        //If the fake answer is in the Panel
        else if (fakeObject.transform.IsChildOf(panel[2].transform))
        {
            prefab12 = fakeObject;
        }
        else
        {
            prefab12 = prefab[Random.Range(0, 9)];
            //Making sure the shape isn't already shown
            //This checks if the object is already active
            while (prefab12.activeSelf)
            {
                //Debug.Log(prefab12.name + "2.1");
                prefab12 = prefab[Random.Range(0, 9)];
            }
            //setting it active
            prefab12.SetActive(true);
            prefab12.transform.SetParent(panel[2].transform, false);
        }

        //2.2
        //Checking if the prefab is answer in the panel
        if (answer.transform.IsChildOf(panel[3].transform))
        {
            prefab13 = answer;
        }
        //If the fake answer is in the Panel
        else if (fakeObject.transform.IsChildOf(panel[3].transform))
        {
            prefab13 = fakeObject;
        }
        else
        {
            prefab13 = prefab[Random.Range(0, 9)];
            //Making sure the shape isn't already shown
            //This checks if the object is already active
            while (prefab13.activeSelf)
            {
                //Debug.Log(prefab13.name + "2.2");
                prefab13 = prefab[Random.Range(0, 9)];
            }
            //setting it active
            prefab13.SetActive(true);
            prefab13.transform.SetParent(panel[3].transform, false);
        }

        //3.1
        //Checking if the prefab answer is in the panel
        if (answer.transform.IsChildOf(panel[4].transform))
        {
            prefab14 = answer;
        }
        //If the fake answer is in the Panel
        else if (fakeObject.transform.IsChildOf(panel[4].transform))
        {
            prefab14 = fakeObject;
        }
        else
        {
            prefab14 = prefab[Random.Range(0, 9)];
            //Making sure the shape isn't already shown
            //This checks if the object is already active
            while (prefab14.activeSelf)
            {
                //Debug.Log(prefab14.name + "3.1");
                prefab14 = prefab[Random.Range(0, 9)];
            }
            //setting it active
            prefab14.SetActive(true);
            prefab14.transform.SetParent(panel[4].transform, false);
        }

        //3.2
        //Checking if the prefab answer is in the panel
        if (answer.transform.IsChildOf(panel[5].transform))
        {
            prefab15 = answer;
        }
        //If the fake answer is in the Panel
        else if (fakeObject.transform.IsChildOf(panel[5].transform))
        {
            prefab15 = fakeObject;
        }
        else
        {
            prefab15 = prefab[Random.Range(0, 9)];
            //Making sure the shape isn't already shown
            //This checks if the object is already active
            while (prefab15.activeSelf)
            {
                //Debug.Log(prefab15.name + "3.2");
                prefab15 = prefab[Random.Range(0, 9)];
            }
            //setting it active
            prefab15.SetActive(true);
            prefab15.transform.SetParent(panel[5].transform, false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    //When an shape is selected
    public void OnPointerClicked()
    {
        //Checks if the answer is right
        Check(gameObject);

        //Makes a new Question
        NewQuestion();
    }


    //Checks if the object clicked matches the question
    void Check(GameObject gameObjects){
        theTimer = GameObject.FindWithTag("Timebar");

        //Randomises new question
        questionTexts = GameObject.FindWithTag("Question");
        //Gets the prefab corresponding to the question
        var answer = GameObject.FindWithTag(questionTexts.GetComponent<TextMeshProUGUI>().text);

        //Checking if the answer clicked is right
        if (gameObjects == answer)
        {
            //Gets the current time
            Timer playerScript = theTimer.GetComponent<Timer>();
            //adds 2 seconds to the time left
            playerScript.timeLeft = playerScript.timeLeft + 1.2f;
            //Plays the right sound effect
            FindObjectOfType<AudioManager>().Play("Right");
            Debug.Log("right");
        }

        else
        {
            //Gets the current time
            Timer playerScript = theTimer.GetComponent<Timer>();
            //removes 1 seconds to the time left
            playerScript.timeLeft = playerScript.timeLeft - 0.5f;
            //Plays the wrong sound effect
            FindObjectOfType<AudioManager>().Play("Wrong");
            Debug.Log("wrong");
        }
    }

    //Destroying all the prefabs
    void NewQuestion()
    {
        //Adding the colours to the list of colours
        colours = new List<Color> { red, green, blue };

        //Variables of the objects
        GameObject prefab10, prefab11, prefab12, prefab13, prefab14, prefab15;

        prefab = new List<GameObject>
        {
            //Adds the prefabs to the list.
            prefab1,
            prefab2,
            prefab3,
            prefab4,
            prefab5,
            prefab6,
            prefab7,
            prefab8,
            prefab9
        };

        //Finding all the Panes
        firstPane = GameObject.FindWithTag("1.1");
        secondPane = GameObject.FindWithTag("1.2");
        thirdPane = GameObject.FindWithTag("2.1");
        fourthPane = GameObject.FindWithTag("2.2");
        fifthtPane = GameObject.FindWithTag("3.1");
        sixthPane = GameObject.FindWithTag("3.2");

        //sets all the children from Active() to true to deal with errors
        SetActiveAllChildren(firstPane.transform, true);
        SetActiveAllChildren(secondPane.transform, true);
        SetActiveAllChildren(thirdPane.transform, true);
        SetActiveAllChildren(fourthPane.transform, true);
        SetActiveAllChildren(fifthtPane.transform, true);
        SetActiveAllChildren(sixthPane.transform, true);

        //Randomises new question
        questionTexts = GameObject.FindWithTag("Question");
        questionTexts.GetComponent<TextMeshProUGUI>().text = questions[Random.Range(0, 9)];
        //Choosing a random colour
        questionTexts.GetComponent<TextMeshProUGUI>().color = colours[Random.Range(0, 3)];
        string fakeColour = WordColour(questionTexts);
        //Gets the prefab corresponding to the question
        var answer = GameObject.FindWithTag(questionTexts.GetComponent<TextMeshProUGUI>().text);
        //Getting the fake object
        GameObject fakeObject= CheckColourIsSame(answer, fakeColour);

        //list of the panes.
        List<GameObject> panes = new List<GameObject>{
            firstPane,
            secondPane,
            thirdPane,
            fourthPane,
            fifthtPane,
            sixthPane
        };

        //sets all the children from Active() to false
        SetActiveAllChildren(firstPane.transform, false);
        SetActiveAllChildren(secondPane.transform, false);
        SetActiveAllChildren(thirdPane.transform, false);
        SetActiveAllChildren(fourthPane.transform, false);
        SetActiveAllChildren(fifthtPane.transform, false);
        SetActiveAllChildren(sixthPane.transform, false);

        //Adding the answer to the game
        answer.SetActive(true);
        answer.transform.SetParent(panes[Random.Range(0, 6)].transform, true);
        answer.transform.localPosition = new Vector3(0, 0, 0);

        //Checking if the question text is the same colour as the answer
        if(fakeObject!=answer)
        {
            //setting the fake image to true 
            fakeObject.SetActive(true);
            //getting a pane for the fake image
            var paneOfFakeObject = panes[Random.Range(0, 6)].transform;
            //Checking if the answer is already a child of the fake object
            while (answer.transform.IsChildOf(paneOfFakeObject.transform))
            {
                paneOfFakeObject = panes[Random.Range(0, 6)].transform;
            }
            fakeObject.transform.SetParent(paneOfFakeObject, true);
            fakeObject.transform.localPosition = new Vector3(0, 0, 0);  
        }

        //1.1
        //Checking if the prefab answer is in the first panel
        //if the answer is in the first Panel
        if (answer.transform.IsChildOf(firstPane.transform))
        {
            prefab10 = answer;
        }
        //If the fake answer is in the first Panel
        else if(fakeObject.transform.IsChildOf(firstPane.transform))
        {
            prefab10 = fakeObject;
        }
        //When the first panel has not active children
        else{
      
            prefab10 = prefab[Random.Range(0, 9)];
            //This checks if the object is already active
            while (prefab10.activeSelf)
            {
                prefab10 = prefab[Random.Range(0, 9)];
            }
            prefab10.SetActive(true);
            prefab10.transform.SetParent(firstPane.transform, true);
            prefab10.transform.localPosition = new Vector3(0, 0, 0); 
        }
        //1.2
        //Checking if the prefab answer is in the panel
        if (answer.transform.IsChildOf(secondPane.transform))
        {
            prefab11 = answer;
        }
        //If the fake answer is in the Panel
        else if (fakeObject.transform.IsChildOf(secondPane.transform))
        {
            prefab11 = fakeObject;
        }
        //When the panel has not active children
        else
        {
            prefab11 = prefab[Random.Range(0, 9)];
            //Making sure the shape isn't already shown
            //This checks if the object is already active
            while (prefab11.activeSelf)
            {
                prefab11 = prefab[Random.Range(0, 9)];
            }
            //setting it active
            prefab11.SetActive(true);
            prefab11.transform.SetParent(secondPane.transform, true);
            prefab11.transform.localPosition = new Vector3(0, 0, 0);
        }
        //2.1
        //Checking if the prefab answer is in the panel
        if (answer.transform.IsChildOf(thirdPane.transform))
        {
            prefab12 = answer;

        }
        //Checking If the fake answer is in the Panel
        else if (fakeObject.transform.IsChildOf(thirdPane.transform))
        {
            prefab12 = fakeObject;
        }
        //When the panel has not active children
        else
        {
            prefab12 = prefab[Random.Range(0, 9)];
            //Making sure the shape isn't already shown
            //This checks if the object is already active
            while (prefab12.activeSelf)
            {
                prefab12 = prefab[Random.Range(0, 9)];
            }
            //setting it active
            prefab12.SetActive(true);
            prefab12.transform.SetParent(thirdPane.transform, true);
            prefab12.transform.localPosition = new Vector3(0, 0, 0);
        }
        //2.2
        //Checking if the prefab answer is in the panel
        if (answer.transform.IsChildOf(fourthPane.transform))
        {
            prefab13 = answer;
        }
        //Checking If the fake answer is in the Panel
        else if (fakeObject.transform.IsChildOf(fourthPane.transform))
        {
            prefab13 = fakeObject;
        }
        //When the panel has not active children
        else
        {
            prefab13 = prefab[Random.Range(0, 9)];
            //Making sure the shape isn't already shown
            //This checks if the object is already active
            while (prefab13.activeSelf)
            {
                prefab13 = prefab[Random.Range(0, 9)];
            }
            //setting it active
            prefab13.SetActive(true);
            prefab13.transform.SetParent(fourthPane.transform, true);
            prefab13.transform.localPosition = new Vector3(0, 0, 0);
        }
        //3.1
        //Checking if the prefab answer is in the panel
        if (answer.transform.IsChildOf(fifthtPane.transform))
        {
            prefab14 = answer;
        }
        //Checking If the fake answer is in the Panel
        else if (fakeObject.transform.IsChildOf(fifthtPane.transform))
        {
            prefab14 = fakeObject;
        }
        //When the panel has not active children
        else
        {
            prefab14 = prefab[Random.Range(0, 9)];
            //Making sure the shape isn't already shown
            //This checks if the object is already active
            while (prefab14.activeSelf)
            {
                prefab14 = prefab[Random.Range(0, 9)];
            }
            //setting it active
            prefab14.SetActive(true);
            prefab14.transform.SetParent(fifthtPane.transform, true);
            prefab14.transform.localPosition = new Vector3(0, 0, 0);
        }
        //3.2
        //Checking if the prefab answer is in the panel
        if (answer.transform.IsChildOf(sixthPane.transform))
        {
            prefab15 = answer;
        }
        //Checking If the fake answer is in the Panel
        else if (fakeObject.transform.IsChildOf(sixthPane.transform))
        {
            prefab15 = fakeObject;
        }
        //When the panel has not active children
        else
        {
            prefab15 = prefab[Random.Range(0, 9)];
            //Making sure the shape isn't already shown
            //This checks if the object is already active
            while (prefab15.activeSelf)
            {
                prefab15 = prefab[Random.Range(0, 9)];
            }
            //setting it active
            prefab15.SetActive(true);
            prefab15.transform.SetParent(sixthPane.transform, true);
            prefab15.transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    //used to set children from active to inactive
    private void SetActiveAllChildren(Transform transform1, bool value)
    {
        foreach (Transform child in transform1)
        {
            child.gameObject.SetActive(value);
            SetActiveAllChildren(child, value);
        }
    }


    //Method to get the right colour of the word
    private string WordColour(GameObject colourWanted){
        float colourOfWord= colourWanted.GetComponent<TextMeshProUGUI>().color.g;
        //Colour of the woed is blue
            if (colourOfWord == 0.5686275f)
        {
            return "Blue";
        }

        //Colour of the word is red
        if (colourOfWord == 0.1321645f)
        {
            return "Red";
        }
        //Colour of the Word is green
        return "Green";
    }

    //method to get the fake  from the colour of the question
    private GameObject CheckColourIsSame(GameObject realAnswer, string colourOfFakeWord)
    {
        //Variable for the fake GameObject
        GameObject fakeObject;

        //Splitting the tag of the real object and putting the words ina list
        //We do this so we can find the corresponding gameobject to the fake colour 
        string nameOfObject = realAnswer.tag;
        string[] objectName = nameOfObject.Split(' ');

        //if the colour of the word is the same as the object 
        if (objectName[0].Equals(colourOfFakeWord))
        {
            fakeObject = realAnswer;
        }
        //If the word and the object of the question are not the same 
        else
        {
            fakeObject = GameObject.FindWithTag(colourOfFakeWord + " " + objectName[1]);
        }
        return fakeObject;
    }

    //Changing the colour of the backGround
    void BackgroundColour(GameObject top, GameObject middle, GameObject bottom){
        //Variable for the colour of the backgtound
        Color topColourBlue = new Color(0.863f, 0.942f, 1.000f, 1.000f);
        Color topColourGreen = new Color(0.788f, 1.000f, 0.824f, 1.000f);
        Color topColourRed = new Color(1.000f, 0.910f, 0.910f, 1.000f);
        //list of colours
        List<Color> BackgroundColours = new List<Color>{topColourBlue,topColourGreen,topColourRed};
        //Getting a random colour 
        Color topColour = BackgroundColours[Random.Range(0,3)];

        //Setting the top of the colour tot he random colour
        top.GetComponent<Image>().color = topColour;

        //If it's blue
        if(top.GetComponent<Image>().color==topColourRed)
        {
            middle.GetComponent<Image>().color = new Color(1.000f, 0.816f, 0.816f, 1.000f);
            bottom.GetComponent<Image>().color = new Color(1.000f, 0.816f, 0.816f, 1.000f);
        }
        //If the top is red
        else if(top.GetComponent<Image>().color == topColourBlue)
        {
            middle.GetComponent<Image>().color = new Color(0.665f, 0.778f, 0.887f, 1.000f);
            bottom.GetComponent<Image>().color = new Color(0.665f, 0.778f, 0.887f, 1.000f);
        }
        //If the top is green 
        else
        {
            middle.GetComponent<Image>().color = new Color(0.770f, 0.943f, 0.774f, 1.000f);
            bottom.GetComponent<Image>().color = new Color(0.732f, 0.887f, 0.736f, 1.000f);
        }
    }
}