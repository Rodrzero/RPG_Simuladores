using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.rigidbody.gameObject.CompareTag("Player"))
            {
                
            }
    }
}
