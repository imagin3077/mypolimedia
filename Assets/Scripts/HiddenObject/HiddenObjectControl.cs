using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HiddenObjectControl : MonoBehaviour
{
    public GameObject itemParent;
    public SaveItemPos saveItemPos;

    public GameObject[] itemTarget;

    public Text textClue;
    public TextClue scriptTextClue;

    public int[] indexNumberClue;
    public int indexUrutanClue;

    // Start is called before the first frame update
    void Start()
    {
        RandomItemPosition();

        IndexNumberClue();
        TextClue();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void IndexNumberClue()
    {
        for (int i= 0; i < indexNumberClue.Length; i++)
        {
            int a = indexNumberClue[i];
            int b = Random.Range(0, indexNumberClue.Length);
            indexNumberClue[i] = indexNumberClue[b];
            indexNumberClue[b] = a;            
        }
    }

    void TextClue()
    {
            int[] randomClue = indexNumberClue;
            scriptTextClue.numberClue = randomClue;

            textClue.text = scriptTextClue.clues[randomClue[indexUrutanClue]].stringClueItems[Random.Range(0, scriptTextClue.clues[randomClue[indexUrutanClue]].stringClueItems.Length)];
    }

    void RandomItemPosition()
    {
        int randomSave = Random.Range(0, saveItemPos.saveItemPos.Count);

        for (int i = 0; i < itemParent.transform.childCount; i++)
        {
            itemParent.transform.GetChild(i).transform.localPosition = saveItemPos.saveItemPos[randomSave].itemPos[i];
        }
        Debug.Log(randomSave);
    }

    /*public void ButtonItem()
    {
        for (int i = 0; i < itemTarget.Length; i++)
        {
            if (EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite == itemTarget[i].GetComponent<Image>().sprite)
            {
                Debug.Log("benar");
            }
            else
            {
                if (i == itemTarget.Length - 1)
                {
                    Debug.Log("salah");
                }
            }
        }
    }*/

    public void ButtonItem(int numberItem)
    {
        if (numberItem == scriptTextClue.numberClue[indexUrutanClue])
        {
            Debug.Log("BENAR!!!");
            itemParent.transform.GetChild(numberItem).gameObject.SetActive(false);
            indexUrutanClue += 1;

            TextClue();
        }
        else
        {
            Debug.Log("SALAH!!!");
        }
    }
}
