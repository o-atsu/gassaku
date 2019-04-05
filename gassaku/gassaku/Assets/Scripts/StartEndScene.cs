using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartEndScene : MonoBehaviour {

    public string next;
	public void ToNextScene()
    {
        SceneManager.LoadScene(next);
    }
    public void ToQuit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        Application.Quit();
#endif
    }
}
