using System;
using UnityEngine;

public class Tramp : NPC
{
        private Item _medallion = new Item(); //Для примера
        private float _Money = 50;

        private void Start()
        {
                _medallion.name = "Медальон";
        }
        
       
        public override void Action()
        {
                Player.Singleton.AddItem(_medallion);
                Player.Singleton.AddMoney(_Money);
                WasThereTalk = true;
        }

       
}
