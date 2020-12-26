using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasScript : MonoBehaviour
{
    public float velocidad = 5f;
    public int damage = 120;
    public bool ammunition_bugged = false;

    private float recorrido;
    private float tiempoInactivo;
    private float numeroFramesLuz;
    private int frameLuz;
    private bool luzRafaga;
    private bool deshabilitado { get; set; }
    

    // Start is called before the first frame update
    void Start()
    {
        recorrido = 0;
        tiempoInactivo = 0;
        frameLuz = 0;
        numeroFramesLuz = 4f;
        luzRafaga = true;

        GetComponent<AudioSource>().Play();
        //transform.rotation = GameObject.Find("Player").transform.rotation;
        //transform.position.x += transform.forward.x;
        //transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y + 0.5f, transform.position.z + 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (frameLuz < numeroFramesLuz) frameLuz++;
        else if (luzRafaga) { GetComponent<Light>().enabled = false; luzRafaga = false; }

        if (deshabilitado) tiempoInactivo += Time.deltaTime;
        else MoverBala();

        if (recorrido >= 1000 || tiempoInactivo >= 2) Destroy(gameObject);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<CharacterController>() == null)
        {
            //Destroy(gameObject);
            deshabilitar();
        }

    }

    void MoverBala()
    {
        float deltaVelo = velocidad * Time.deltaTime;

        recorrido += deltaVelo;
        //  Al usar el Vector3.forward.z uso la rotación global del mundo, z será positivo. 
        //  Al usar transform.forward.z, uso la rotación local del gameObject
        gameObject.transform.position += new Vector3(transform.forward.x * deltaVelo, transform.forward.y * deltaVelo, transform.forward.z * deltaVelo);
    }

    void deshabilitar()
    {
        deshabilitado = true;
        //GetComponent<MeshCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }


}
