using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    [Header("Chasing Player")]
    public GameObject player;
    public float speed;
    public float distanceBetween;
    private float distance;
    private Animator anim;

    [Header("Dialogue")]
    //public DialogueManager dialogue;
    //public DialogueTrigger trigger;
    public GameObject dialog;
    public int npcdibaca = 0;

    private NpcAI _npcAI;
   
    // Start is called before the first frame update
    void Start()
    {
        npcdibaca = PlayerPrefs.GetInt("npc");
        anim = GetComponent<Animator>();
        _npcAI = GetComponent<NpcAI>();
    }

    // Update is called once per frame
    void Update()
    {
        ChasingPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true && npcdibaca == 0)
        {
            //trigger.StartDialogue();
            dialog.SetActive(true);
            npcdibaca = 1;
            PlayerPrefs.SetInt("npc", 1);
            PlayerPrefs.Save();
            _npcAI.state = NpcAI.finiteState.dialogue;
            anim.SetBool("moving", false);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (npcdibaca == 1)
        {
            dialog.SetActive(false);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            _npcAI.state = NpcAI.finiteState.idle;
            anim.SetBool("moving", false);
        }
    }

    private void ChasingPlayer()
    {    
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceBetween && npcdibaca == 0)
        {
            anim.SetBool("moving", true);
            transform.position = Vector2.MoveTowards(this.transform.position, 
                player.transform.position, speed * Time.deltaTime);
            _npcAI.state = NpcAI.finiteState.chasing;
        }
        else
        {
            _npcAI.state = NpcAI.finiteState.idle;
            anim.SetBool("moving", false);
        }
    }
}
