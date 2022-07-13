using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controle_Dialogo : MonoBehaviour
{
    [Header("Componentes")]
    public GameObject dialogoObj; // janela do dialogo
    public Image profileSprite; // sprite do Personagem q esta falando 
    public Text speechText; // texto da fala
    public Text atorNameText; // nome do personagem

    [Header("Configurações")]
    public float velocidadeTxt; //velocidade do texto


    //variaveis de controle
    private bool isShowing; // se a janela esta ativada
    private int index; // usado no laço de repetição , quantidade de palavra tem um texto.
    private string[] sentences; // guarda as letras da nossa fala


    public static Controle_Dialogo instance;

    //awake é chamado de antes de todos os start()
    private void Awake()
    {
        instance = this;
    }



    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letra in sentences[index].ToCharArray())
        {
            speechText.text += letra;
            yield return new WaitForSeconds(velocidadeTxt);

        }
    }

    //pular para a proxima fala
    public void NextSentence()
    {
        
            if (speechText.text == sentences[index])
            {
                if (index < sentences.Length - 1)
                {
                    index++;
                    speechText.text = "";
                    StartCoroutine(TypeSentence());
                }
                else
                {
                    speechText.text = "";
                    index = 0;
                    dialogoObj.SetActive(false);
                    sentences = null;
                    isShowing = false;
                }
            }
        
    }

    //chamar a fala do NPC
    public void Speech(string[] txt)
    {
        if(!isShowing)
        {
            dialogoObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;

        }
    }
}
