using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drop_Wood : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float timeMove;

    private float initialspeed;
    private float timeCount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        DropMove();
    }

    private void FixedUpdate()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Item_Player>().TotalWood++;
            Destroy(gameObject);
        }
    }

    private void DropMove()
    {
       
            timeCount += Time.deltaTime;

            if (timeCount < timeMove)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
    
    }

  
    




