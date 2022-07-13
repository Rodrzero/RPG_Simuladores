using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollider : MonoBehaviour
{

    [SerializeField] private float dropRange;
    [SerializeField] private LayerMask layerPlayer;
    [SerializeField] private Player player;


    
    private bool playerDetect;
    
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        DetectPlay();
    }

   

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dropRange);
    }

    private void DetectPlay()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dropRange, layerPlayer);
        {
            if (hit != null)
            {
                playerDetect = true;
                
                Debug.Log("proximo");

              
            }
            else
            {
                playerDetect = false;
 
            }


        }
        
    }
    }
