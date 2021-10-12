using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{


    public GameObject left_Arm_Attack_Point, right_Arm_Attack_Point, left_Leg_Attack_Point, right_Leg_Attack_Point,genou_Attack_Point,bouche_Attack_Point, attaque_SpeF_Point, attaque_SpeEau_Point;
	public bool frameInvaincible = false;


	PlayerMouvement m_playerM;
	PlayerAttack m_playerA;

	AudioSource audioS;
	public AudioClip fxWhoosh, fxChargeAttspF, fxLF, fxChargeAttspEau, fxChargeAttspE,fxGroundHit;

	private void Start()
	{
		m_playerM = GetComponent<PlayerMouvement>();
		m_playerA = GetComponentInParent<PlayerAttack>();
		audioS = GetComponent<AudioSource>();
	}


	void Left_Arm_Attack_On()
	{
		
		left_Arm_Attack_Point.SetActive(true);
		frameInvaincible = true;
	}

	void Left_Arm_Attack_Off()
	{
		if(left_Arm_Attack_Point.activeInHierarchy)
		{
			
			left_Arm_Attack_Point.SetActive(false);
			
		}
		frameInvaincible = false;
	}


	void right_Arm_Attack_On()
	{
		
		right_Arm_Attack_Point.SetActive(true);
		frameInvaincible = true;
	}

	void right_Arm_Attack_Off()
	{
		if (right_Arm_Attack_Point.activeInHierarchy)
		{
			
			right_Arm_Attack_Point.SetActive(false);
			
		}
		frameInvaincible = false;
	}


	void left_Leg_Attack_On()
	{
		
		left_Leg_Attack_Point.SetActive(true);
		frameInvaincible = true;
	}

	void left_Leg_Attack_Off()
	{
		if (left_Leg_Attack_Point.activeInHierarchy)
		{
			
			left_Leg_Attack_Point.SetActive(false);
			
		}
		frameInvaincible = false;
	}

	void right_Leg_Attack_On()
	{
		
		right_Leg_Attack_Point.SetActive(true);
		frameInvaincible = true;
	}

	void right_Leg_Attack_Off()
	{
		if (right_Leg_Attack_Point.activeInHierarchy)
		{
			
			right_Leg_Attack_Point.SetActive(false);
			
		}
		frameInvaincible = false;
	}


	void Genou_Attack_On()
	{
		
		genou_Attack_Point.SetActive(true);
		frameInvaincible = true;
	}

	void Genou_Attack_Off()
	{
		if (genou_Attack_Point.activeInHierarchy)
		{
			
			genou_Attack_Point.SetActive(false);
			
		}
		frameInvaincible = false;
	}


	void Morsure_Attack_On()
	{
		frameInvaincible = true;
		bouche_Attack_Point.SetActive(true);
		
	}

	void Morsure_Attack_Off()
	{
		
		if (bouche_Attack_Point.activeInHierarchy)
		{

			bouche_Attack_Point.SetActive(false);
			
		}
		frameInvaincible = false;
	}

	void Attaque_SpecielF_On()
	{
		m_playerM.ismove = false;
		frameInvaincible = true;
		attaque_SpeF_Point.SetActive(true);
	}

	void Attaque_SpecielF_Off()
	{
		m_playerM.ismove = true;
		frameInvaincible = false;
		attaque_SpeF_Point.SetActive(false);
	}

	void Attaque_SpecielEau_On()
	{
		m_playerM.ismove = false;
		frameInvaincible = true;
		attaque_SpeEau_Point.SetActive(true);
	}

	void Attaque_SpecielEau_Off()
	{
		m_playerM.ismove = true;
		frameInvaincible = false;
		attaque_SpeEau_Point.SetActive(false);

		
	}

	void Attaque_SpecialEl_On()
	{
		m_playerM = GetComponentInParent<PlayerMouvement>();
		m_playerM.ismove = false;
		frameInvaincible = true;
	}

	void Attaque_SpecialEl_Off()
	{
		m_playerM.ismove = true;
		frameInvaincible = false;
		transform.parent.gameObject.SetActive(false);
		m_playerA.spR.enabled = true;
		
	}

	public void WhooshFxSound()
	{
		audioS.volume = 0.2f;
		audioS.clip = fxWhoosh;
		audioS.Play();
	}

	public void ChargeFxFire()
	{
		audioS.volume = 1f;
		audioS.clip = fxChargeAttspF;
		audioS.Play();

	}

	public void ChargeFxEau()
	{
		audioS.volume = 1f;
		audioS.clip = fxChargeAttspEau;
		audioS.Play();

	}

	public void Stopfx()
	{
		audioS.Stop();
	}

	public void ChargeFxEl()
	{
		audioS.volume = 1f;
		audioS.clip = fxChargeAttspE;
		audioS.Play();

	}

	public void FxlanceFlamme()
	{
		audioS.volume = 1f;
		audioS.clip = fxLF;
		audioS.Play();

	}

	public void FxGroundHit()
	{
		audioS.volume = 1f;
		audioS.clip = fxGroundHit;
		audioS.Play();
	}
}
