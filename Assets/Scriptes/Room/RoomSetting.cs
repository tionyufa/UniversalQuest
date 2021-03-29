using System.Collections.Generic;
using UnityEngine;
public enum Room {Road,Other}
public abstract class RoomSetting : MonoBehaviour 
{
    //Настройка комнаты, можно задать стартовый текст,указать какая комната, сколько персонажей в ней и какие диалоги
    [HideInInspector] public string _startText;
    [HideInInspector] public  Room _NameRoom;
    [TextArea(2,10)]  public List <string> RoomDialog;
    public  List<NPC> _npc;

}
