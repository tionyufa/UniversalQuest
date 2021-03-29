using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRoom : RoomSetting
{
    private void Awake()
    {
        _NameRoom = Room.Road;
        _startText = "Вы попали на дорогу";
        
    }
}
