using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float velocidadhorizontal;
    public float fuerzasalto;
    public float salto_sostenido;

    public float saltosmax;
    private float saltosrest;

    bool puede_saltar;
    public LayerMask capasuelo;


    private BoxCollider2D bx;

    void Start()
    {
        bx= GetComponent<BoxCollider2D>();
        saltosrest = saltosmax;
    }


    void Update()
    {
        control_mov_horizontal();
        control_salto();
    }

    bool ensuelo()
    {
       RaycastHit2D raycast = Physics2D.BoxCast(bx.bounds.center, new Vector2(bx.bounds.size.x, bx.bounds.size.y), 0f, Vector2.down, 0.2f,capasuelo);
        return raycast.collider != null;
    }

    void control_mov_horizontal()
    {
        if (Input.GetKey("a"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3 (-velocidadhorizontal*Time.deltaTime, 0f, 0f));
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); //hace que el sprite se voltee dependiendo de la direccion a la que camine
        }
        

        if (Input.GetKey("d"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(velocidadhorizontal * Time.deltaTime, 0f, 0f));
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void control_salto()
    {
        
       

        if(Input.GetKeyDown(KeyCode.Space)&& ensuelo())
        {
            saltosrest--;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,fuerzasalto));
        }

        
    }
}
