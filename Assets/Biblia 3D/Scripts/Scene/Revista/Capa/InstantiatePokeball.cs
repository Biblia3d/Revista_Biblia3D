using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePokeball : MonoBehaviour
{

    public GameObject pokeballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instanciar()
    {
        Instantiate(pokeballPrefab, transform.position, transform.rotation);
    }
}
