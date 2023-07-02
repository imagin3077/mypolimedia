using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class NPCMovement6 : MonoBehaviour
{
    //public DialogueTrigger trigger;
    //public DialogueManager dialogue;
    public GameObject dialog;
    public int npc6dibaca = 0;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        npc6dibaca = PlayerPrefs.GetInt("npc6");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (DialogueManager.isActive == true)
          //  return;
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            trigger.StartDialogue();
            _npcAI.state = NpcAI.finiteState.dialogue;
            PlayerPrefs.SetInt("npcdibaca" + dialogue.sudahDibaca, dialogue.npcdibaca);
            PlayerPrefs.Save();
        }

        else if (dialogue.npcdibaca == 1)
        {
            _npcAI.state = NpcAI.finiteState.idle;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            _npcAI.state = NpcAI.finiteState.idle;
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (npc6dibaca == 0)
        {
            dialog.SetActive(true);
            npc6dibaca = 1;
            PlayerPrefs.SetInt("npc6", 1);
            PlayerPrefs.Save();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (npc6dibaca == 1)
        {
            dialog.SetActive(false);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}

