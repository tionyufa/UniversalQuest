using UnityEngine;
using UnityEngine.Events;


public abstract class NPC : MonoBehaviour
{
    //Универсальный абстрактный класс в котором можно добавлять бесконечное количество диалогов и ответов с событиями и тд..
    public string NameNPC; 
    public DialogNote [] DialogNPC;
    public DialogNote FinishDialogNPC;
    protected bool WasThereTalk;

    public abstract void Action();
    public bool WhichDialog()
    {
        return WasThereTalk;
    }


}
[System.Serializable]
public  class DialogNote
{
    //Диалоги от НПС
    [TextArea(3,20)]
    public string NpcText;
    public Answer[] PlayerAnswar;
}

[System.Serializable]
public class Answer
{
    //Ответы от Персонажа и в зависимости от ответа можно настроить событие
    [TextArea(3,20)]
    public string Text;
    public int ToNode;
    public bool SpeakEnd;
    public UnityEvent _Event;
    
}

