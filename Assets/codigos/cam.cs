using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Vector3.Lerp(transform.position,Player.transform.position,0.05f));
        transform.position = Vector3.Lerp(transform.position,Player.transform.position+new Vector3(2.5f,7f,-3f),0.05f);
    }
}
