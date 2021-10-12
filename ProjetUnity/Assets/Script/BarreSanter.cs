using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreSanter : MonoBehaviour
{

    public Image vieFillImage;

    Vie m_playerVie;

    // Start is called before the first frame update
    void Start()
    {
        m_playerVie = GameObject.Find("Player").GetComponent<Vie>();
    }

    // Update is called once per frame
    void Update()
    {
        vieFillImage.fillAmount = m_playerVie.currentVie / m_playerVie.maxVie;
    }
}
