using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogo : MonoBehaviour
{

    public float DialogoRange;
    public LayerMask playerLayer;

    public Config_Dialogos dialogue;

    bool playerhit;


    private List<string> sentences = new List<string>();

    private void Start()
    {
        GetNPCInfo();
    }


    // Update é chamado a cada Frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerhit)
        {
            Controle_Dialogo.instance.Speech(sentences.ToArray());
        }
        else
        {
            playerhit = false;
        }
    }

    void GetNPCInfo()
    {
        for (int  i = 0; i < dialogue.dialogues.Count; i++)
        {
            sentences.Add(dialogue.dialogues[i].sentence.portuguese);
        }
    }

    // FixedUpdate é usado pela fisica
    void FixedUpdate()
    {
        ColisorNPC();
        
    }


    void ColisorNPC()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, DialogoRange, playerLayer);

        if(hit != null)
        {
            playerhit = true;
        }
        else
        {
            playerhit = false;
            
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, DialogoRange);
    }
}
