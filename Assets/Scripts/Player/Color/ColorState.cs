using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;



    public class RedState : IColor
    {
        private PlayerColor playerColor;

        public RedState(PlayerColor playerColor)
        {
            this.playerColor = playerColor;
        }

        public void OnEnter()
        {
            playerColor.spriteRenderer.color = UnityEngine.Color.red;
        }
        public void OnExcute()
        {
            
        }
        public void OnExit()
        {

        }
    }

    public class BlueState : IColor
    {
        private PlayerColor playerColor;

        public BlueState(PlayerColor playerColor)
        {
            this.playerColor = playerColor;
        }

        public void OnEnter()
        {
            playerColor.spriteRenderer.color = UnityEngine.Color.blue;
        }
        public void OnExcute()
        {

        }
        public void OnExit()
        {

        }
    }


