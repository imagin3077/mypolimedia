using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickControl : MonoBehaviour
{
    public static string itemObj;
    public GameObject itemClue;

    public RectTransform item;

    public HiddenObjectControl1 hiddenObject;

    public AudioSource benar;
    public AudioSource salah;


    // Start is called before the first frame update
    void Start()
    {
        hiddenObject.wrongChanceText.GetComponent<Text>().text = "" + hiddenObject.wrongChance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        if (Time.timeScale == 1)
        {
            if (gameObject.tag == "benar")
            {
                benar.Play();
                itemObj = gameObject.name;
                hiddenObject.totalItem -= 1;
                //totalItemObj.totalItemText.text = totalItemObj.totalItem + " objek";
                item.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
                Destroy(gameObject, 0.5f);
                Destroy(itemClue);
            }

            if (gameObject.tag == "salah")
            {
                salah.Play();
                hiddenObject.wrongChance -= 1;
                hiddenObject.wrongChanceText.GetComponent<Text>().text = "" + hiddenObject.wrongChance;
                item.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
                Destroy(gameObject, 0.5f);
            }
        }
    }
}
