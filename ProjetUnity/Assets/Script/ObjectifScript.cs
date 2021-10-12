using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectifScript : MonoBehaviour
{

    public Text ObjctifTxt;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();


    }

    // Update is called once per frame
    void Update()
    {
        ObjctifTxt.text = gm.EnnemiMort + "/" + gm.MaxEnnemi + " Monstre éléminié";
    }
}
