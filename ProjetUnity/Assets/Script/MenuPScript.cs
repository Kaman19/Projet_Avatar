using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPScript : MonoBehaviour
{
    LevelLoader levelLoad;

    // Start is called before the first frame update
    void Start()
    {
        levelLoad = FindObjectOfType<LevelLoader>();
    }



    public void BtnPlay()
    {

        levelLoad.LoadNextlevel(1);

    }

    public void BtnMP()
    {
        levelLoad.LoadNextlevel(0);
    }

    public void BtnQuitterGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
