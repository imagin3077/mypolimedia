using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager2 : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;
    public Button nextButton;
    public GameObject panelDialog;
    public GameObject backgroundDialog;

    [SerializeField] AudioSource openDialog;
    [SerializeField] AudioSource typeDialog;

    public Message[] currentMessages;
    Actor[] currentActors;
    public int activeMessage = 0;
    public static bool isActive = false;

    public GameObject posPlayer;
    public GameObject player;
    public Vector3 tempPos;

    public int sudahDibaca2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        //sudahDibaca2 = PlayerPrefs.GetInt("dibaca2", sudahDibaca2);
        sudahDibaca2 = PlayerPrefs.GetInt("dibaca", sudahDibaca2);
        activeMessage = 0;
        backgroundBox.transform.localScale = Vector3.zero;
        panelDialog.SetActive(false);
        backgroundDialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextMessage();
        }

    }
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {

        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;

        openDialog.Play();
        Debug.Log("Started Conversation! Loaded Message: " + messages.Length);
        DisplayMessage();
    }

    void DisplayMessage()
    {
        panelDialog.SetActive(true);
        backgroundDialog.SetActive(true);
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentMessages[activeMessage]));
    }

    

    public void NextMessage()
    {

        if (Time.timeScale != 0)
        {
            activeMessage++;

            if (activeMessage < currentMessages.Length)
            {
                DisplayMessage();
            }
            else if (activeMessage == currentMessages.Length)
            {
                nextButton.gameObject.SetActive(true);
                isActive = false;
            }
            else
            {
                sudahDibaca2 = 1;
                PlayerPrefs.SetInt("dibaca", 1);
                PlayerPrefs.Save();
                
                //PlayerPrefs.SetInt("dibaca2", 1);
                //PlayerPrefs.Save();
                //sudahDibaca2 = 1;
                CloseDialog();
            }
            Debug.Log("activeMessage = "+ activeMessage);
        }
    }

    IEnumerator TypeSentence (Message sentence)
    {
        messageText.text = "";
        foreach (char letter in sentence.message)
        {
            messageText.text += letter;
            yield return null;
        }
    }

    public void CloseDialog()
    {
        isActive = false;
        panelDialog.SetActive(false);
        backgroundDialog.SetActive(false);
        nextButton.gameObject.SetActive(false);
        backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
        openDialog.Play();
        Debug.Log("Conversation Ended!");
    }

    public void GoToNextScene(string nextSceneName)
    {
        SceneManager.LoadScene(nextSceneName);
    }

    /*public void TaskCheck()
    {
        if (sudahDibaca != 0 && npc == true)
        {
            completeTask.SetActive(true);
            askHelp.SetActive(false);
        }
        else if (sudahDibaca != 0 && npc2 == true)
        {
            completeTask2.SetActive(true);
            askHelp2.SetActive(false);
        }
        else
        {
            askHelp.SetActive(true);
            completeTask.SetActive(false);
            askHelp2.SetActive(true);
            completeTask2.SetActive(false);
        }
    }*/
}
