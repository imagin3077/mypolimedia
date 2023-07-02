using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("NPC")]
    [SerializeField] private Transform npc;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Animator")]
    [SerializeField] private Animator anim;
    [SerializeField] private NpcAI _npcAI;

    private void Awake()
    {
        initScale = npc.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (npc.position.x >= leftEdge.position.x) 
                MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (npc.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }

        }
    }

    private void DirectionChange()
    {
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        _npcAI.state = NpcAI.finiteState.chasing;
        

        npc.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        npc.position = new Vector3(npc.position.x + Time.deltaTime * _direction * speed, 
            npc.position.y, npc.position.z);
        
        anim.SetInteger("state", (int)_npcAI.state);

    }

   
}
