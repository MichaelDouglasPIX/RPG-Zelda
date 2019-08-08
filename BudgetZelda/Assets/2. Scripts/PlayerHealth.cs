using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealt = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    MoveUnityChan playerMovement;
    bool isDead;
    bool damaged;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<MoveUnityChan>();
        currentHealth = startingHealt;
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
            
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
        
    }

    public void TakeDamage (int amount)
    {
        anim.SetTrigger("Damage");

        currentHealth -= amount;      

        healthSlider.value = currentHealth;

        damaged = true;

        if (currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }

    public void Death ()
    {
        isDead = true;

        playerMovement.enabled = false;

        anim.SetTrigger("Die");
       
    
    }
}
