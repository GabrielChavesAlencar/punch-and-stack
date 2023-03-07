using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evento : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(jogo.pontuacao>=6){
            Destroy(gameObject);
        }
    }
}
