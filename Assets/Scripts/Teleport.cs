using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public RectTransform teleportPoint;
    savingPosition playerPosData;

    // Start is called before the first frame update
    void Start()
    {
        playerPosData = FindObjectOfType<savingPosition>();
        teleportPoint.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        teleportPoint.LeanScale(Vector3.one, 1f).setEaseInOutExpo();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        teleportPoint.LeanScale(Vector3.zero, 1f).setEaseInOutExpo();
    }

    public void TeleportScene(string NameScene)
    {
        playerPosData.SavePos();
        SceneManager.LoadScene(NameScene);
    }
}
