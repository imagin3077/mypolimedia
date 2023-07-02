using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    savingPosition playerPosData;

    // Start is called before the first frame update
    void Start()
    {
        playerPosData = FindObjectOfType<savingPosition>();    
    }

    public void Quit()
    {
        playerPosData.SavePos();
        SceneManager.LoadScene("Menu");
    }
}
