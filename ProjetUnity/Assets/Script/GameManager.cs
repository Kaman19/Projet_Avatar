using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    PlayerControler control;
    AudioSource audioS;

    public GameObject UIPause,bntRP, btnRC, uiDefaite;
    public EventSystem eventsy;

    public AudioClip musicClm, musicBgg;

    float lastTimeView = Mathf.NegativeInfinity;
    public bool isFighting=false,isFPlaying=false, isCPlaying = false,isPause=false;
    public float delay;

    public GameObject porte;

    public int MaxEnnemi;
    public int EnnemiMort;


    public List<EnnemiMouvement> ListE = new List<EnnemiMouvement>();
	private void Awake()
	{
        
        control = new PlayerControler();

        control.Gameplay.Pause.performed += ctx => Pause();

        foreach (var enemy in GameObject.FindObjectsOfType<EnnemiMouvement>())
        {
            ListE.Add(enemy);
        }

        MaxEnnemi = ListE.Count;
    }
	// Start is called before the first frame update
	void Start()
    {
        audioS = GameObject.Find("Son").GetComponent<AudioSource>();
        audioS.volume = 0.25f;
        audioS.clip = musicClm;
        audioS.Play();
        isCPlaying = true;

        

       

       // currentFight = isFighting;
    }


	private void Update()
	{
  //      if ((lastTimeView + delay < Time.time) && isFighting)
		//{
  //          isFighting = false;
  //          ChangeMusic();
		//}
  //      if(currentFight != isFighting || (lastTimeView + delay < Time.time) )
		//{
  //          ChangeMusic();
  //      }

        if(isFighting&&!isFPlaying)
		{
            ChangeMusic();
		}
        if ((lastTimeView + delay < Time.time) && isFPlaying)
        {
            isFighting = false;
            ChangeMusic();
        }

  //      if(control.Gameplay.Pause.triggered)
		//{

          
            
		//}

        

    }


    void Pause()
	{
        isPause = !isPause;

        if (isPause)
        {
            Time.timeScale = 0f;
            UIPause.SetActive(true);
            eventsy.SetSelectedGameObject(bntRP);
        }
        else
        {
            Time.timeScale = 1f;
            UIPause.SetActive(false);
        }
    }

    public void PlayerIsDead()
	{
        uiDefaite.SetActive(true);
        eventsy.SetSelectedGameObject(btnRC);
    }

	public void ChangeMusic()
	{

        if (isFighting)
        {
            
            audioS.volume = 0.25f;
            audioS.clip = musicBgg;
            audioS.Play();
            isFPlaying = true;
            isCPlaying = false;

        }
        else
		{
            
            audioS.volume = 0.25f;
            audioS.clip = musicClm;
            audioS.Play();
            isFPlaying = false;
            isCPlaying = true;
        }
        //currentFight = isFighting;

        lastTimeView = Time.time;

    }


    public void RemoveListe(GameObject ObjectEnnemi)
	{
        ListE.Remove(ObjectEnnemi.GetComponent<EnnemiMouvement>());
        EnnemiMort++;

        if(ListE.Count==0)
		{
            porte.SetActive(false);
		}
	}

    public void OnEnable()
    {
        control.Enable();
    }

    private void OnDisable()
    {
        control.Disable();
    }
}
