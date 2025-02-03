 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float cubeSize = 0.2f;

    //death effect
    public ParticleSystem deathParticles;

    public Material[] texture;
    public ParticleSystemRenderer psRenderer;
    
    //private current
    public float currentHealth;
    public float maxHealth = 30;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int amount){
      currentHealth -= amount;
      if(currentHealth <= 0){
        //die
        psRenderer.material = texture[0];
        Instantiate(deathParticles,transform.position,Quaternion.identity);
        Destroy(gameObject);
       
      }

    }
}