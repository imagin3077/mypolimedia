using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GantiScene : MonoBehaviour
{
    public Animator transitionAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void ChangeScene(string SceneName)
    {
        StartCoroutine(LoadLevel(SceneName));
    }

    public IEnumerator LoadLevel(string SceneName)
    {
        transitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadSceneAsync(SceneName);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Keluar Game");
    }
}
