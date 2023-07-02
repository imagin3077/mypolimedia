using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextClue : MonoBehaviour
{
    public int[] numberClue;

    [System.Serializable]
    public class ItemClues
    {
        public string[] stringClueItems;
        public int numberClue;
    }

    public ItemClues[] clues;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
