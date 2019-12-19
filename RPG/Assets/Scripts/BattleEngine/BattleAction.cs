using BattleEngine.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleEngine
{
    public class BattleAction
    {
        #region Enums
        public enum ActionState { Acting, CoolDown };
        #endregion

        #region Private/Protected Variables
        protected float startTimeStamp;
        protected float actionTime;
        protected float coolDownTime;
        protected Character author;
        protected Action<List<Character>> actionEffect;
        protected List<Character> targets;
        protected ActionState state;
        #endregion
        public BattleAction(Character author, Action<List<Character>> actionEffect,List<Character> targets)
        {
            this.author = author;
            this.actionEffect = actionEffect;
            this.targets = targets;
            this.state = ActionState.Acting;
        }

        public void Act()
        {
            actionEffect(targets);
        }

        public void TimeLineStep()
        {

        }

        public void Interrupt()
        {
            state = ActionState.CoolDown;
            startTimeStamp = Time.time;
            author.Interrupt();
        }

        public void Finish()
        {
            author.DecideNextAction();
        }
    }
}
