using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private float horizontalInput;

    [SerializeField] SpriteRenderer sprite;
    private Rigidbody2D body;
    private Animator anim;
    private AudioSource playerFootsteps;

    public DialogueManager dialogue;

    savingPosition playerPosData;


    private enum finiteState { idle, walking }
    private finiteState state;

    private void Awake()
    {
        playerPosData = FindObjectOfType<savingPosition>();
        playerPosData.LoadPos();
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerFootsteps = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (horizontalInput > 0.01f)
        {
            state = finiteState.walking;
            sprite.flipX = false;
        }
        else if (horizontalInput < -0.01f)
        {
            state = finiteState.walking;
            sprite.flipX = true;
        }
        else
        {
            state = finiteState.idle;
        }

        anim.SetInteger("state", (int) state);
    }

    private void Footsteps()
    {
        playerFootsteps.Play();
    }
}
