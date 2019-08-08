using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnityChan : MonoBehaviour
{
    public CharacterController characterCtrl;
    public Animator anim;
    Vector3 MovAxis, TurnAxis;
    public GameObject currentCamera;
    public bool Sword;
    public GameObject swordVisual;
    public GameObject swodAttack;

    public int attackDamagePunch = 20;
    public int attackDamageKick = 30;
    EnemyHealth enemyHealth;
    GameObject enemy;
    float timer;

    public bool dentro = true;
    public int ataque = 0;
    Collider colliderEnemy;
    
    bool pausado;
    public GameObject sound;
    public GameObject pause;
    // Start is called before the first frame update
    void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        currentCamera = Camera.main.gameObject;
        swodAttack.gameObject.SetActive(false);
        enemyHealth = GetComponent<EnemyHealth>();
        colliderEnemy = swodAttack.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        print(dentro);

        MovAxis = new Vector3(0, 0, Input.GetAxis("Vertical"));
        TurnAxis = new Vector3(0, Input.GetAxis("Horizontal"), 0) * 2;

        characterCtrl.SimpleMove(transform.TransformVector(MovAxis) * 5);
        
            anim.SetFloat("Speed", characterCtrl.velocity.magnitude);
            transform.Rotate(TurnAxis);


        if (Input.GetButtonDown("Fire1") )
        {
                anim.SetTrigger("PunchA");
            enemyHealth.TakeDamage(attackDamagePunch);
        }

        if (Input.GetButtonDown("Fire2") )
        {
            anim.SetTrigger("KickA");
            enemyHealth.TakeDamage(attackDamageKick);
        }

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("Jump");
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            if (!Sword)
            {
                attackDamagePunch = 40;
                attackDamageKick = 30;
                Sword = true;
                anim.SetBool("Sword", true);
                swordVisual.gameObject.SetActive(false);
                swodAttack.gameObject.SetActive(true);
            }
            else
            {
                attackDamagePunch = 20;
                attackDamageKick = 30;
                Sword = false;
                anim.SetBool("Sword", false);
                swodAttack.gameObject.SetActive(false);
                swordVisual.gameObject.SetActive(true);
                
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!pausado)
            {
                Time.timeScale = 0f;
                sound.gameObject.SetActive(false);
                pause.gameObject.SetActive(true);
                pausado = true;
            }
            else
            {
                Time.timeScale = 1f;
                sound.gameObject.SetActive(true);
                pause.gameObject.SetActive(false);
                pausado = false;
                
            }
        }

    }
}
