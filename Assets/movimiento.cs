using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{   
    public KeyCode teclasaltar;
    public KeyCode teclacorrer;
    public float velocidad;
    public float velocidadcorrer;
    private float velocidadactual;
    public float dirx;
    public SpriteRenderer spr;
    public float fuerzasalto;
    private Animator animacion;
    private Rigidbody2D rig;
    int limitesdesaltos=2;
    int saltoshechos;
    // Start is called before the first frame update
    void Start()
    {
       animacion = GetComponent<Animator>();
       rig = GetComponent<Rigidbody2D>();
       saltoshechos = 0;
       velocidadactual = velocidad;
   }

    // Update is called once per frame
    void Update()
    {
       dirx = Input.GetAxis("Horizontal");
       transform.position += new Vector3(dirx * velocidadactual * Time.deltaTime, 0, 0);

       if (Input.GetKey(teclacorrer))
       {
           velocidadactual = velocidadcorrer;
       }
       else velocidadactual = velocidad;

       if (dirx > 0)
       {
              spr.flipX = false;
       }

       if (dirx < 0)
       {
              spr.flipX = true;
       }  
       if (Input.GetKeyDown(teclasaltar))  
       { if (saltoshechos<limitesdesaltos){
              animacion.SetBool("estaSaltando", true);
              rig.AddForce(new Vector3(0, fuerzasalto));
              saltoshechos++;
       }
       }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "suelo")
        {
            animacion.SetBool("estaSaltando", false);
            saltoshechos=0;
        }
    }
    
}
