using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vie : MonoBehaviour
{

    public float maxVie = 100;

    public float currentVie; /*{ get; set; }*/

    public float pEn, gEn;

    public bool invincible;

    public bool isPlayer;
    public bool isHurting=false;
    public bool isdeying = false;

    

    ElementScript m_element;
    CharacterAnimation m_charecterAnim;
    Animator anim;

    PlayerMouvement m_playerM;
    PlayerAttack m_playerA;
    EnnemiMouvement m_ennemiM;
    GameManager gm;


    float LastTimeSecure = Mathf.NegativeInfinity;
    float delay = 1f;


    // Start is called before the first frame update
    void Start()
    {
        m_element = GetComponent<ElementScript>();
        m_charecterAnim = GetComponent<CharacterAnimation>();
        anim = GetComponent<Animator>();
        currentVie = maxVie;
        m_playerA = GameObject.Find("Player").GetComponent<PlayerAttack>();
        gm = FindObjectOfType<GameManager>();
        if(isPlayer)
		{
            m_playerM = GetComponent<PlayerMouvement>();
            
		}
        else
		{
            m_ennemiM = GetComponent<EnnemiMouvement>();
        }

        

    }

	private void Update()
	{
		if(!m_playerA.IsGarding && invincible && (LastTimeSecure + delay < Time.time))
		{
            invincible = false;
            isHurting = false;
        }
	}

	public void Soin(float healAmount)
	{
        float vieAvant = currentVie;
        currentVie += healAmount;
        currentVie = Mathf.Clamp(currentVie, 0f, maxVie);

       
    }

   

    public void TakeDamage(float degat, int element)
    {
        if (m_charecterAnim.frameInvaincible || invincible)
        {
            return;
        }

       

        

        if(m_element.typeElement==element)
		{
            currentVie -= degat;
        }
        if ((m_element.typeElement == 1 && element == 2)
            || (m_element.typeElement==2 && element==3)
            || (m_element.typeElement==3 && element==1))
        {
            currentVie -= degat*2;
        }
        if ((m_element.typeElement == 1 && element == 3)
            || (m_element.typeElement == 2 && element == 1)
            || (m_element.typeElement == 3 && element == 2))
        {
            currentVie -= degat/2;
        }


        if (currentVie <= 0 && !isdeying)
        {
            Die();
            Debug.Log("coucou");
        }

        if(currentVie >= 0 && !isdeying && isPlayer)
        {
            HurtP();
        }

        if (currentVie >= 0 && !isdeying && !isPlayer)
        {
            HurtM();

        }



    }

    void HurtP()
	{
  //      if(!isdeying)
		//{
            Debug.Log("j'ai mal");
            invincible = true;
            isHurting = true;
            anim.SetTrigger("Hurt");

            LastTimeSecure = Time.time;
        //}
    }
        

    void HurtPFinish()
	{
        Debug.Log("j'ai plus mal");
        invincible = false;
        isHurting = false;
	}

    void HurtM()
	{
        anim.SetTrigger("Hurt");
        anim.SetBool("Walk", false);
        m_ennemiM.currentSpeed = 0f;
        isHurting = true;
    }

    void Die()
    {

        if(isPlayer)
		{
            isdeying = true;
            Debug.Log("je suis mort !!!!");
            m_playerM.moveSpeed = 0f;
            anim.SetTrigger("Dead");

        }
        else
		{
            isdeying = true;
            anim.SetBool("isDying", isdeying);
            anim.SetBool("Walk", false);
            m_ennemiM.currentSpeed = 0f;
            gm.RemoveListe(gameObject);
            if (m_ennemiM.isAdvance)
			{
                m_playerA.currentEnergie += gEn;
			}
            else
			{
                m_playerA.currentEnergie += pEn;
            }
            if(m_playerA.currentEnergie>100)
			{
                m_playerA.currentEnergie = 100;
			}

            if(m_ennemiM.TryDropItem())
			{
                m_ennemiM.DropItem();
			}

            anim.SetTrigger("Dead");

            Debug.Log("je me meur !!!!");
            
            
		}
        

        //Destroy(gameObject);
    }

    void IsDead()
	{
        Destroy(gameObject);
    }

    void DeadPlayer()
	{
        m_playerM.enabled = false;
        gm.PlayerIsDead();
	}
}
