using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jogo : MonoBehaviour
{
    public static int quantidade;
    public static int capacidademax;
    public static int money;

    public Text money_tex;

    public Text capacidade_text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        money_tex.text = "Money $"+money;
        capacidade_text.text = "Capacity "+quantidade+"/"+capacidademax;

    }
}
