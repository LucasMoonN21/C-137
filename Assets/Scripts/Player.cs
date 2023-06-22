using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _veloc;
    public GameObject _pfLaser;
    private float _tempoDeDisparo = 0.3f;
    private float _podeDisparar = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Metodo Start de "+this.name);
        _veloc = 3.0f;
        transform.position = new Vector3(0,0,0);   
    }

    // Update is called once per frame
    void Update()
    {
        this.Movimento();
        
        Movimento();
        if ( Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
             Disparo();
        }

         if ( Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
             Disparo();
        }
    }
    private void Movimento()
    {
        float entradaHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * entradaHorizontal* Time.deltaTime*_veloc);
        if ( transform.position.y > 1.4685f)
        {
            transform.position = new Vector3(transform.position.x,1.4685f,0);
        }
        else if (transform.position.y < -1.6538f)
        {
            transform.position = new Vector3(transform.position.x,-1.6538f,0);
        }

        float entradaVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * entradaVertical * Time.deltaTime*_veloc);
        if ( transform.position.x > 2.8296f)
        {
            transform.position = new Vector3( 2.8296f, transform.position.y,0);
        }
        else if ( transform.position.x < -2.837f )
        {
            transform.position = new Vector3( -2.837f, transform.position.y,0);
        }
    }

    private void Disparo(){
        if ( Time.time > _podeDisparar ){
             Instantiate(_pfLaser,transform.position + new Vector3 (0,0.2f,0),Quaternion.identity);
            _podeDisparar = Time.time + _tempoDeDisparo ;
             }
    }
}
