using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceFlammeScript : MonoBehaviour
{

    [Header("Dégat")]
    public int dommage;
    ElementScript m_element;

    // Start is called before the first frame update
    void Start()
    {
        m_element = GetComponentInParent<ElementScript>();
        Debug.Log(m_element.typeElement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ennemi" || collision.tag == "Boss")
        {
            Debug.Log("je le brule !!");
            collision.GetComponent<Damageble>().InfligeDegat(dommage, m_element.typeElement);


            //GameObject ed = Instantiate(effetDest);
            //ed.transform.position = transform.position;

            // Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ennemi" || collision.tag == "Boss")
        {

            Debug.Log("vous le voulez a point ou bien cuit ?");
            collision.GetComponent<Damageble>().InfligeDegat(dommage, m_element.typeElement);


            //GameObject ed = Instantiate(effetDest);
            //ed.transform.position = transform.position;

            // Destroy(gameObject);
        }
    }
}
