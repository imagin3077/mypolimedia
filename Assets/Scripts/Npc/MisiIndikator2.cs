using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MisiIndikator2 : MonoBehaviour
{
    private NPCMovement4 dialog;
    public GameObject misi;
    public GameObject misiSelesai;
    
    HiddenObjectControl1 puzzle;
    savingPosition playerPosData;

    private void Start()
    {
        dialog = GetComponent<NPCMovement4>();
        dialog.npc4dibaca = PlayerPrefs.GetInt("npc4");
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
        if (dialog.npc4dibaca == 1)
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
