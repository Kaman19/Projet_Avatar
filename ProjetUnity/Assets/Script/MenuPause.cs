using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MenuPause : MonoBehaviour
{


    GameManager gm;

    LevelLoader levelLoad;

    PlayerMouvement m_playerM;
    public GameObject btnReprendre;
    

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        levelLoad = FindObjectOfType<LevelLoader>();
        m_playerM = FindObjectOfType<PlayerMouvement>();
        
        
    }

    public void Reprendre()
	{
        Time.timeScale = 1f;
        gm.isPause = false;
        gameObject.SetActive(false);
	}

    public void QuitterNiveau()
	{
        m_playerM.enabled = false;
        Time.timeScale = 1f;
        levelLoad.LoadNextlevel(0);
    }


}
