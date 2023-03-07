using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public DynamicJoystick joyStick;
    public Animator anim;
    public float mov_h,mov_v,velocidade;
    public Rigidbody rig;
    public GameObject NPCtemp;
    public GameObject NPCtempbase;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        jogo.capacidademax = 2;
    }


    // Update is called once per frame
    void Update()
    {
         Move_Player();
         /*
         if(Input.GetKeyDown(KeyCode.Space)&&NPCtempbase!=null){
            NPCtempbase.GetComponent<NPC>().carregado = false;
            NPCtempbase.transform.position = transform.position + new Vector3(2,1f,0);
            NPCtemp = null;
            NPCtempbase = null;
            quantidade = 0;
            
         }
         */
    }
    public void Move_Player () {
        mov_h = joyStick.Horizontal;
        mov_v = joyStick.Vertical;
        
        Vector3 dir = new Vector3(mov_h,0,mov_v);
        if(dir != Vector3.zero){
            transform.Translate(Vector3.forward*Time.deltaTime*velocidade);
            
            anim.SetBool("andando",true);
            transform.LookAt(transform.position + dir);
        }
        else{anim.SetBool("andando",false);}
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag =="NPC"){
            
            if(!other.gameObject.GetComponent<NPC>().carregado&&other.GetComponent<NPC>().anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")
            &&jogo.quantidade<jogo.capacidademax){
                anim.SetTrigger("soco");
                StartCoroutine(Soco(other));
            }
        }
        if(other.gameObject.tag =="objetivo"&&NPCtempbase!=null){
            NPCtempbase.GetComponent<NPC>().carregado = false;
            NPCtempbase.transform.position = transform.position + new Vector3(2,1f,0);
            NPCtemp = null;
            NPCtempbase = null;
            jogo.money += jogo.quantidade*10;
            jogo.quantidade = 0;

        }
        if(other.gameObject.tag =="upgrade"&&jogo.money>10){
            jogo.capacidademax++;
            jogo.money -=10; 
        }
    }
    IEnumerator Soco(Collider other){
        other.gameObject.GetComponent<NPC>().carregado=true;
        yield return new WaitForSeconds(0.3f);
        if(NPCtemp==null){other.gameObject.GetComponent<NPC>().obj_seguir = gameObject;}
            else{other.gameObject.GetComponent<NPC>().obj_seguir = NPCtemp;}
            NPCtemp=other.gameObject;
        if(NPCtempbase==null){NPCtempbase=NPCtemp;}
        jogo.quantidade++;

            
    }
}
