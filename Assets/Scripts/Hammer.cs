using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;

public class Hammer : MonoBehaviour
{

    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " "; // assigned to allow first line to be read below

    //public GameObject CreateMaze;

    private Animator animator;

    public int damageAmount = 10;
    public int hammerCurrentHealth;
    public int hammerMaxHealth = 100;

    Renderer rend;
    public Material[] textures;
    int i = 0;
    int hammers=0;



    void Start(){


        theSourceFile = new FileInfo("Assets/Resources/file.maz");
        reader = theSourceFile.OpenText();
        char[] spearator = { '=', ' ' };
        reader.ReadLine();
        reader.ReadLine();
        text = reader.ReadLine();
        String[] kArr = text.Split(spearator);
        hammers= int.Parse(kArr[1]);

        //used for color change
        rend = GetComponent<Renderer>();
        GetComponent<MeshRenderer>().sharedMaterial = textures[i];

        animator = GetComponent<Animator>();
        hammerCurrentHealth = hammerMaxHealth;
	}

    // Update is called once per frame
    void Update()
    {

        if (hammerCurrentHealth <= 0)
        {
            //die hammer
            if (hammers > 0){
                NextHammer();
                hammers--;
            }
            else{
                Destroy(gameObject);
            }
        }

        //when H is pressed hammer hits
        if (Input.GetKeyDown(KeyCode.H))
        {
            GetComponent<Animation>().Play("Hit");
		}
    }

    void OnTriggerEnter(Collider col){
        if (col.gameObject.tag == "hit")
        {
            hammerCurrentHealth -= 5;

            //make hammer more red
            GetComponent<MeshRenderer>().sharedMaterial = textures[i++];

            Damage obj = col.gameObject.GetComponent<Damage>();
            obj.TakeDamage(damageAmount);
        }
    }

    void NextHammer()
    {
        GetComponent<Animation>().Play("New");
        hammerCurrentHealth = hammerMaxHealth;
        i = 0;
        GetComponent<MeshRenderer>().sharedMaterial = textures[i];
    }

    public int getHammers()
    {
        return hammers;
    }
}
