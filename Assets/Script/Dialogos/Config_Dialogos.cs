using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName  = "Novo Dialogo", menuName = "New Dialogue/Dialogue")]
public class Config_Dialogos : ScriptableObject
{
    [Header("Configuracao")]
    public GameObject actor;

    [Header ("Dialogo")]
    public Sprite speakerSprite;
    public string sentence;

    public List<Sentece> dialogues = new List<Sentece>();

}


//atributos do personagem ( nome , foto, lingua)
[System.Serializable]
public class Sentece
{
    public string actorName;
    public Sprite profile;
    public Languages sentence;
}

[System.Serializable]   
public class Languages
{
    public string portuguese;
    public string english;
    public string spanish;
}



#if UNITY_EDITOR
[CustomEditor(typeof(Config_Dialogos))]
public class BuilderEditor : Editor

{//editor da Unity - Botão 
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Config_Dialogos ds = (Config_Dialogos)target;

        Languages lan = new Languages();
        lan.portuguese = ds.sentence;

        Sentece sent = new Sentece();
        sent.profile = ds.speakerSprite;
        sent.sentence = lan;

        if(GUILayout.Button("Create Dialogue"))
        {
            if(ds.sentence != "")
            {
                ds.dialogues.Add(sent);

                ds.speakerSprite = null;
                ds.sentence = "";
            }
        }
    }


}
#endif