using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;
    [SerializeField] private ParticleSystem leafs;

    [SerializeField] private GameObject dropPrefab;
    [SerializeField] private int totalDrop;
    
    [SerializeField] private int randomMin;
    [SerializeField] private int randomMax;
    [SerializeField] private int randomDrop;


    private bool isCut;

    //instanciar.
    private float _treeHealth;

    //propriedades para instanciar
    public float TreeHealth
    {
        get { return _treeHealth; }
        set { _treeHealth = value; }
    }



    void onHit()
    {
        treeHealth--;
        anim.SetTrigger("Hit");
        leafs.Play();
        if (randomDrop == Random.Range(randomMin,randomMax))
        {
            Instantiate(dropPrefab, transform.position + new Vector3(Random.Range(-1f, 1f),
                    Random.Range(-1f, 1f), 0f), transform.rotation);

        }
        
        //instacia a anim "cut"
        if (treeHealth <= 0)     
        {
            for (int i = 0; i < totalDrop; i++)
            {
                Instantiate(dropPrefab, transform.position + new Vector3(Random.Range(-1f, 1f),
                Random.Range(-1f, 1f), 0f), transform.rotation);
            }
            

                anim.SetTrigger("Cut");
                isCut = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe") && !isCut)
        {   
            onHit();
        }
    }

}
