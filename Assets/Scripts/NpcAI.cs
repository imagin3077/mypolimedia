using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAI : MonoBehaviour
{   
    public enum finiteState { idle, chasing, dialogue }
    public finiteState state;

    // Start is called before the first frame update
    void Start()
    {
        state = finiteState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case finiteState.idle:
                Debug.Log("Idle");
                break;
            case finiteState.chasing:
                Debug.Log("Chasing");
                break;
            case finiteState.dialogue:
                Debug.Log("Dialogue");
                break;
        }
    }
}
