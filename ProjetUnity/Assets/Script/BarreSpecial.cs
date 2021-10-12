using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreSpecial : MonoBehaviour
{

    public Image energieFillImage;


    PlayerAttack m_playerA;

    // Start is called before the first frame update
    void Start()
    {
        m_playerA = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        energieFillImage.fillAmount = m_playerA.currentEnergie / m_playerA.maxEnergie;
    }
}
