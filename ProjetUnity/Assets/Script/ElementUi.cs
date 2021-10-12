using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementUi : MonoBehaviour
{

    public Image IndcationElement;

    public Sprite fireSprite;
    public Sprite waterSprite;
    public Sprite lightingSprite;
    

    ElementScript m_element;



    // Start is called before the first frame update
    void Start()
    {
        m_element = GameObject.Find("Player").GetComponent<ElementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(m_element.typeElement==1)
		{
            IndcationElement.sprite = lightingSprite;
		}
        if(m_element.typeElement==2)
		{
            IndcationElement.sprite = fireSprite;
        }
        if (m_element.typeElement == 3)
        {
            IndcationElement.sprite = waterSprite;
        }

    }
}
