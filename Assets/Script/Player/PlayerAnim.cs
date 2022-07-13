using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    //componentes
    private Player player;
    private Animator anim;

    




    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        OnMove();
        OnRun();
        onCutting();
        onDig();
        onAtack();
        onWater();
    }

    #region Movimentos

    void OnMove()
    {

        if (player.Direcao.sqrMagnitude > 0)
        {
            anim.SetInteger("transicao", 1);
        }

        else
        {
            anim.SetInteger("transicao", 0);

        }


        if (player.Direcao.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
            
        }

        if (player.Direcao.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            
        }

        

    }
    void OnRun()
        {
            if(player.isRun)
            {
                anim.SetInteger("transicao",2);
            }
            else
            {
                anim.SetInteger("transicao", 0);
                
            }

   
        }
    void onCutting()
    {
        if (player.isCutting)
        {
            anim.SetInteger("transicao", 3);

        }
     

    }

    void onDig()
    {
        if (player.isDig)
        {
            anim.SetInteger("transicao", 5);
        }
  
    }


    void onAtack()
    {
        if (player.isAtack)
        {
            anim.SetInteger("transicao", 4);
        }

    }


    void onWater()
    {
        if (player.isWater)
        {
            anim.SetInteger("transicao", 9);

        }

    }






    #endregion





}
