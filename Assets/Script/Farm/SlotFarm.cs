using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprtRender;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [SerializeField] private int digAmount; //qty de escavar


    private int initialDigAmount;



    // Start is called before the first frame update
    void Start()
    {
        initialDigAmount = digAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHit()
    {
        digAmount--;
        if(digAmount <= initialDigAmount / 2)
        {
            //spriterender buraco
            sprtRender.sprite = hole;
        }

        if(digAmount <= 0)
        {
            //plantar cenoura
            sprtRender.sprite = hole;
            sprtRender.sprite = carrot;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dig"))
        {
            OnHit();
        }
    }
}
