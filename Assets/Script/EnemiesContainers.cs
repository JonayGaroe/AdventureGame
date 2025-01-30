using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemiesContainers : MonoBehaviour
{

    public static EnemiesContainers instance { get; private set; }
    public int enemyFix;
    public int enemigosBroken;
    [SerializeField]
    TextMeshProUGUI textoFix, textoBroken;
    //public int enemigosBrokencount;


    // Start is called before the first frame update
    void Awake()
    {

        instance = this;



    }

    void Start()
    {

        enemigosBroken = 1;

        

    }

    // Update is called once per frame
    void Update()
    {
        






    }


    public void AddEnemie()
    {
        enemigosBroken = enemigosBroken + 1;
        textoBroken.text = enemigosBroken.ToString();


        // enemigosBroken = enemigosBrokencount; 

    }
    // objetotext.text = objeto.tostring

    public void RemoveEnemie()
    {


        enemyFix = enemyFix + 1;
        Debug.Log("+1 de 3");
        textoFix.text = enemyFix.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        EnemyController enemy = other.GetComponent<EnemyController>();

           



        


    }




}