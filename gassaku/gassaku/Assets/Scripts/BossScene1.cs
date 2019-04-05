using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScene1 : MonoBehaviour {

    public bool win = false;
    public bool lose = false;
    public string wheretogo;
    public GameObject winpanel;
    public GameObject losepanel;

    public void ToTitle()
    {
        SceneManager.LoadScene("title");
    }
    public void ToNextstage()
    {
        SceneManager.LoadScene(wheretogo);
    }

    private void Update()
    {
        winpanel.gameObject.SetActive(win);
        if (!win)
        {
            losepanel.gameObject.SetActive(lose);
        }
    }
}
