
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float run;
    [SerializeField] private int itemEquipe = 0;

   
    

    //componentes
    private Rigidbody2D rig;
    private Item_Player limitWater;
    

    private Vector2 _direcao;
    private bool _isRun;
    private bool _isRoll;
    private float initialSpeed;
    private bool _isCutting;
    private bool _isDig;
    private bool _isAtack;
    private bool _isWater;
    

  




    //ENUM para usar o switch 
    public enum Item
    {
        Item1,
        Item2,
        Item3,
        Item4
        

    }

    //declarando o Enum
    private Item itemObj;


    //propriedades
    #region Encapsulamento

    public Vector2 Direcao
    {
    get { return _direcao;}
    set { _direcao = value; }
    }

    public bool isRun
    {
        get { return _isRun; }
        set { _isRun = value; }
    }

    public bool isRoll
    {
        get { return _isRoll; }
        set { _isRoll = value; }
    }

    public bool isCutting
    {
        get { return _isCutting; }
        set { _isCutting = value; }
    }

    public bool isDig
    {
        get { return _isDig; }
        set { _isDig = value; }
    }

    public bool isAtack
    {
        get { return _isAtack; }
        set { _isAtack = value; }
    }

    public bool isWater
    {
        get { return _isWater; }
        set { _isWater = value; }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        limitWater = GetComponent<Item_Player>();
        initialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            itemObj ++ ;
            
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            itemObj--;

        }

        switch (itemObj)
        {
            case Item.Item1:
                itemEquipe = 1;
                break;

            case Item.Item2:
                itemEquipe = 2;
                break;

            case Item.Item3:
                itemEquipe = 3;
                break;

            case Item.Item4:
                itemEquipe = 4;
                break;

            default:

                
                break;





        }


        OnInput();
        
        OnRun();
        OnAxe();
        OnDig();
        OnAtack();
        OnRegar();
       
       
        
        

    }

  

    private void FixedUpdate()
    {

        OnMove();
    }

    #region Movement

    void OnInput()
    {
        Direcao = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        
            rig.MovePosition(rig.position + Direcao * speed * Time.fixedDeltaTime);

    }

    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            speed = run;
            _isRun = true;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            speed = initialSpeed;
            _isRun = false;
        }

    }

    void OnAxe()
    {
        if (itemEquipe == 3)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                isCutting = true;
                speed = 0;
                
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                isCutting = false;
                speed = initialSpeed;
            }
        }
            
    }

    void OnDig()
    {
        if(itemEquipe == 2)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                isDig = true;
                speed = 0;
                
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                isDig = false;
                speed = initialSpeed;
            }
        }
    }


    void OnAtack()
    {
        if (itemEquipe == 1)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                isAtack = true;
                speed = 0;
                
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                isAtack = false;
                speed = initialSpeed;
            }
        }
   

    }

    void OnRegar()
    {
        if (itemEquipe == 4 )
        {
            if ( Input.GetKeyDown(KeyCode.X) && limitWater.TotalWater > 0 )
            {
                isWater = true;
                speed = 0;
            
                

            }
            if (Input.GetKeyUp(KeyCode.X) || limitWater.TotalWater < 0)
            {
                isWater = false;
                speed = initialSpeed;
            }

            if(isWater)
            {
                limitWater.TotalWater -= 0.1f;
            }
        }

    }




        #endregion
    }
