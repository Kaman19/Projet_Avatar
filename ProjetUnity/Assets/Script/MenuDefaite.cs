using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDefaite : MonoBehaviour
{

    LevelLoader levelLoad;
    // Start is called before the first frame update
    void Start()
    {
        levelLoad = FindObjectOfType<LevelLoader>();
    }




    public void Recommencer()
	{
        levelLoad.LoadNextlevel(1);
    }

    public void QuitterNiveau()
    {
        
        levelLoad.LoadNextlevel(0);
    }

}
