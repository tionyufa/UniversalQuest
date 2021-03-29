using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] private TextMeshProUGUI _textMain;
    [SerializeField] private List<Button> _buttons;
    private List<TextMeshProUGUI> _buttonsText = new List<TextMeshProUGUI>();

    [Header("Other")]
    [SerializeField] private List<RoomSetting> _rooms;
    private Room _currentEnumRoom = Room.Road;
    private RoomSetting _currentRoom;
    [SerializeField] private NPC _npc;
    public int _currentNode;
    
   
   private void Start()
   {
       for (int i = 0; i < _buttons.Count; i++) //У меня в тесте предполагается что больше 4 кнопок не нужно,
                                                //в зависимости от проекта можно добвить больше
       {
           _buttons[i].gameObject.SetActive(false);
           _buttonsText.Add(_buttons[i].GetComponentInChildren<TextMeshProUGUI>());
       }
       for (int i = 0; i < _rooms.Count; i++)
       {
           if (_currentEnumRoom == _rooms[i]._NameRoom)
           {
               _currentRoom = _rooms[i];
           }
       }

       
       SetStartButton();
   }

   public void setButton()  // Устанавливаем кнопки для разговора
   {
       RemoteButton();
       if (!_npc.WhichDialog())
       {
           _textMain.text = _npc.DialogNPC[_currentNode].NpcText;
           for (int i = 0; i < _npc.DialogNPC[_currentNode].PlayerAnswar.Length; i++)
           {
               int x = i;
               _buttons[i].gameObject.SetActive(true);
               _buttonsText[i].text = _npc.DialogNPC[_currentNode].PlayerAnswar[i].Text;
               _buttons[i].onClick.AddListener(() => _npc.DialogNPC[_currentNode].PlayerAnswar[x]._Event.Invoke());
               _buttons[i].onClick.AddListener((() => SetAnswer(_npc.DialogNPC[_currentNode].PlayerAnswar[x])));

           }
       }
       else 
       {
               _textMain.text = _npc.FinishDialogNPC.NpcText;
               for (int z = 0; z < _npc.FinishDialogNPC.PlayerAnswar.Length; z++)
               {
                   int y = z;
                   _buttons[z].gameObject.SetActive(true);
                   _buttonsText[z].text = _npc.FinishDialogNPC.PlayerAnswar[z].Text;
                   _buttons[z].onClick.AddListener((() => SetAnswer(_npc.FinishDialogNPC.PlayerAnswar[y])));
               }

       }
   }
   private void RemoteButton()  // Убираем все кнопки и очищаем их
   {
       for (int i = 0; i < _buttons.Count; i++)
       {
           _buttons[i].onClick.RemoveAllListeners();
           _buttons[i].gameObject.SetActive(false);
       }
   }
   private void SetAnswer(Answer _answer)  //Устанавливаем ответ и какие следующие действия
   {
      _currentNode = _answer.ToNode;
      setButton();
      if (_answer.SpeakEnd)
      {
          _currentNode = 0;
          RemoteButton();
          SetStartButton();
      } 
   }

   private void SetStartButton() //Стартовые кнопки в зависимости от комнаты
   {
       _textMain.text = _currentRoom._startText;
       for (int i = 0; i < _currentRoom.RoomDialog.Count; i++)
       {
            int x = i;
            _buttons[i].onClick.RemoveAllListeners();
           _buttons[i].gameObject.SetActive(true);
           _buttons[i].onClick.AddListener(() => _npc = _currentRoom._npc[x]);
           _buttons[i].onClick.AddListener(() => setButton());
           _buttonsText[i].text = _currentRoom.RoomDialog[i];
       }
   }

   public void SwithRoom(Room room)  //Меняем комнату
   {
       for (int i = 0; i < _rooms.Count; i++)
       {
           if (room == _rooms[i]._NameRoom && _currentEnumRoom != _rooms[i]._NameRoom)
           {
               _currentEnumRoom = _rooms[i]._NameRoom;
               _currentRoom = _rooms[i];
           }
       }
       SetStartButton();
   }
  
}
