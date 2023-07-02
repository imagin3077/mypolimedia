using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [Header("Chasing Player")]
    public GameObject player;
    public float speed;
    public float distanceBetween;
    private float distance;
    public bool isChasing;
    private Animator anim;

    [Header("Dialogue")]
    public GameObject dialog;
    public int npcdibaca = 0;

    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("NPC")]
    [SerializeField] private Transform npc;

    [Header("Movement Parameters")]
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    private NpcAI _npcAI;

    private void Awake()
    {
        initScale = npc.localScale;
    }

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
        if (isChasing)
        {
            _npcAI.state = NpcAI.finiteState.chasing;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        }
        else
        {
            distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < distanceBetween && npcdibaca == 0)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                _npcAI.state = NpcAI.finiteState.chasing;
                isChasing = true;
            }

            else if (distance > distanceBetween && npcdibaca == 0) 
            {
                isChasing = false;
                if (movingLeft)
                {
                    if (npc.position.x >= leftEdge.position.x)
                        NpcPatrol(-1);
                    else
                    {
                        DirectionChange();
                    }
                }
                else
                {
                    if (npc.position.x <= rightEdge.position.x)
                        NpcPatrol(1);
                    else
                    {
                        DirectionChange();
                    }

                }

            }
        }

            if (npcdibaca == 1)
            {
                anim.SetBool("moving", false);
                _npcAI.state = NpcAI.finiteState.idle;
                isChasing = false;
            }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true && npcdibaca == 0)
        {
            isChasing = false;
            dialog.SetActive(true);
            npcdibaca = 1;
            PlayerPrefs.SetInt("npc", 1);
            PlayerPrefs.Save();
            _npcAI.state = NpcAI.finiteState.dialogue;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (npcdibaca == 1)
        {
            isChasing = false;
            _npcAI.state = NpcAI.finiteState.idle;
            dialog.SetActive(false);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    /*private void ChasingPlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < distanceBetween && npcdibaca == 0)
        {
            _npcAI.state = NpcAI.finiteState.chasing;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        else
        {
            _npcAI.state = NpcAI.finiteState.patrol;
        }
    }*/

    private void DirectionChange()
    {
        anim.SetBool("moving", false);

       // _npcAI.state = NpcAI.finiteState.patrol;
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void NpcPatrol(int _direction)
    {
        anim.SetBool("moving", true);

        if (npcdibaca == 0)
        {
            idleTimer = 0;
            //_npcAI.state = NpcAI.finiteState.patrol;


            npc.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
                initScale.y, initScale.z);

            npc.position = new Vector3(npc.position.x + Time.deltaTime * _direction * speed,
                npc.position.y, npc.position.z);
        }
    }
}
