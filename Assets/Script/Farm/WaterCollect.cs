using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollect : MonoBehaviour
{
    
    [SerializeField] private bool detectPlay;
    [SerializeField] private int waterValue;


    private Item_Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Item_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(detectPlay && Input.GetKeyDown(KeyCode.E))
        {
            player.WaterLimit(waterValue);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectPlay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            detectPlay = false;
        }
    }
}
