using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MisiIndikator4 : MonoBehaviour
{
    private NPCMovement6 dialog;
    public GameObject misi;
    public GameObject misiSelesai;
    
    HiddenObjectControl1 puzzle;
    savingPosition playerPosData;

    private void Start()
    {
        dialog = GetComponent<NPCMovement6>();
        dialog.npc6dibaca = PlayerPrefs.GetInt("npc6");
        misi.SetActive(false);
        misiSelesai.SetActive(false);
        playerPosData = FindObjectOfType<savingPosition>();
        puzzle = FindObjectOfType<HiddenObjectControl1>();
    }

    private void Update()
    {
        Misi();
        //MisiComplete();
    }

    public void Misi()
    {
        if (dialog.npc6dibaca == 1)
        {
            misi.SetActive(true);
        }
        else
        {
            misi.SetActive(false);
        }
    }

    /*public void MisiComplete()
    {
        if (puzzle.menang == 1)
        {
            misiSelesai.SetActive(true);
        }
        else if(puzzle.kalah == 1)
        {
            misi.SetActive(true);
        }
    }*/

    public void MisiLevel(string namaScene)
    {
        playerPosData.SavePos();
        SceneManager.LoadScene(namaScene);
    }
}
