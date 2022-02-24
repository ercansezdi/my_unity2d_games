using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private float mySpeedX;
    [SerializeField] float speed;
    private Rigidbody2D myBody;
    private Vector3 defaultScale;
    public bool onGround;
    private bool canDoubleJump = false ;
    [SerializeField] GameObject arrow;
    [SerializeField] bool attacked;
    [SerializeField] float currentAttackTimer;
    [SerializeField] float defaultAttackTimer;
    private Animator myAnimator;

    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        defaultScale = transform.localScale;
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        mySpeedX = Input.GetAxis("Horizontal");
        myBody.velocity = new Vector2(mySpeedX * speed, myBody.velocity.y);

        myAnimator.SetFloat("speed", Mathf.Abs(mySpeedX)); // animasyondaki speed değişkenine hız ayarlandı.


        #region oyuncunun sağa ve  sola hareket etmesini sağlayan kısım
        if (mySpeedX > 0)
            transform.localScale = new Vector3(defaultScale.x, defaultScale.y, defaultScale.z);
        else if (mySpeedX < 0)
            transform.localScale = new Vector3(defaultScale.x*-1f, defaultScale.y, defaultScale.z);
        #endregion

        #region oyuncunun zıplama animasyonu
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(onGround)
            { 
                myBody.velocity = new Vector2(myBody.velocity.x, 5f);
                canDoubleJump = true;
                myAnimator.SetTrigger("jump");
            }
            else if (canDoubleJump)
            {
                myAnimator.SetTrigger("jump");
                myBody.velocity = new Vector2(myBody.velocity.x, 5f);
                canDoubleJump = false;
            }

        }
        #endregion


        #region ok atma kontrolu

        if(Input.GetKeyDown(KeyCode.Space)) // space bastığımızda anlamamızı sağlar.
        {
            if (!attacked)
            {
                attacked = true;
                myAnimator.SetTrigger("attack");
                Invoke("fire", 0.3f);

            }
        }
        #endregion

        if(attacked)
        {
            currentAttackTimer -= Time.deltaTime;
        }
        else
        {
            currentAttackTimer = defaultAttackTimer;
        }

        if (currentAttackTimer <= 0)
            attacked = false;
        
        
        

    }
    void fire()
    {
        //Instantiate(arrow); // verilen gameObjeyi oyunda oluştutur.

        GameObject arrowObject = Instantiate(arrow, transform.position, Quaternion.identity);

        if (transform.localScale.x < 0)
        {
            arrowObject.transform.localScale = new Vector3(defaultScale.x * -1f, defaultScale.y, defaultScale.z); //ok x eksenine göre yön değiştirilmesi
            arrowObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f, arrowObject.GetComponent<Rigidbody2D>().velocity.y); // ok hızı ve gideceği yön
        }
        else
        {
            arrowObject.GetComponent<Rigidbody2D>().velocity = new Vector2(10f, arrowObject.GetComponent<Rigidbody2D>().velocity.y);// ok hızı ve gideceği yön
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            die();
        }
    }

    void die()
    {
        myAnimator.SetFloat("speed", 0);
        myAnimator.SetTrigger("die");
        myBody.constraints = RigidbodyConstraints2D.FreezePosition;
        enabled = false;
        
    }
}
