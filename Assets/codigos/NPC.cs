using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool carregado;
    public Animator anim;
    public GameObject obj_seguir;
    public Rigidbody rig;
    public CapsuleCollider col;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(carregado&&obj_seguir!=null){
            anim.SetBool("carregado",true);
            transform.position = Vector3.Lerp(transform.position+new Vector3(0,0.2f,0),obj_seguir.transform.position,0.27f);
            transform.rotation = obj_seguir.transform.rotation;
            rig.useGravity = false;
            col.enabled = false;
        }else{
            rig.useGravity = true;
            col.enabled = true;
        }
    }
}
