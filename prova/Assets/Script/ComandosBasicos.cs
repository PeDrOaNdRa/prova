using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandosBasicos : MonoBehaviour
{
    // Declarando variáveis:
    public int velocidade; //define a velocidade de movimentação
    public int alturaPulo; //define a força do pulo
    private Rigidbody2D rbPlayer; //cria variável para recever os componentes de física    
    private Animator anim; //cria a variável de manipulação para animações

    public bool sensor; //sensor para verificar se está colidindo com o chão
    public Transform posicaoSensor; //Posição onde o sensor será posicionado
    public LayerMask layerChao; //Camada de interação*

    private SpriteRenderer sprite;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Código para movim
        float movimentoX = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(movimentoX * velocidade, rbPlayer.velocity.y);

        anim.SetInteger("walk", (int)movimentoX);

        //Código para pular
        if (Input.GetButtonDown("Jump") && sensor == true)
        {
            rbPlayer.AddForce(new Vector2(0, alturaPulo));
        }

        anim.SetBool("jump", sensor);

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("attack");
        }

        if (movimentoX > 0)
        {
            sprite.flipX = false; //aperta a seta para a direita o boneco vai para a direita
        }else if(movimentoX < 0)
        {
            sprite.flipX = true;//aperta a seta para a esquerda o boneco vai para a esquerda
        }
       
    }

    private void FixedUpdate()
    {

        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f, layerChao);

    }
}
