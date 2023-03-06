using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public DynamicJoystick joyStick;
    public Animator anim;
    public float mov_h,mov_v,velocidade;
    public Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        /*
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(Vector3.forward*Time.deltaTime*2);
            anim.SetBool("andando",true);
        }*/
        /*
        if(Input.GetKeyUp(KeyCode.UpArrow)){anim.SetBool("andando",false);}
        float direcao = Input.GetAxis("Horizontal");
         transform.Rotate(0,Time.deltaTime*direcao*30,0,Space.World);
         if(Input.GetKeyDown(KeyCode.Space)){
            anim.SetTrigger("soco");
         }
         */
         Move_Player();
    }
    public void Move_Player () {
        mov_h = joyStick.Horizontal;
        mov_v = joyStick.Vertical;
        
        Vector3 dir = new Vector3(mov_h,0,mov_v);
        //rig.velocity =new Vector3(mov_h*velocidade,rig.velocity.y,mov_v*velocidade);
        if(dir != Vector3.zero){
            transform.Translate(Vector3.forward*Time.deltaTime*2);
            
            anim.SetBool("andando",true);
            transform.LookAt(transform.position + dir);
        }
        else{anim.SetBool("andando",false);}
    }
}
