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
        public enum ActionType { Attack, StatusEffect, Buff, Debuff, Heal, Interrupt, Interruptable};
        #endregion

        #region Private/Protected Variables
        protected float startTimeStamp;
        protected float actionTime;
        protected float coolDownTime;
        protected Character author;
        protected Action<List<Character>> actionEffect;
        protected List<Character> targets;
        protected ActionState state;
        protected List<ActionType> ActionTypes;
        protected bool hasBeenInterrupted;
        #endregion
        public BattleAction(Character author, Action<List<Character>> actionEffect,List<Character> targets)
        {
            this.author = author;
            this.actionEffect = actionEffect;
            this.targets = targets;
            this.state = ActionState.Acting;
            hasBeenInterrupted = false;
        }

        public List<ActionType> GetActionTypes()
        {
            return ActionTypes;
        }

        public Character getAuthor()
        {
            return author;
        }

        public List<Character> getTargets()
        {
            return targets;
        }
        public void Act()
        {
            if(!hasBeenInterrupted)
                actionEffect(targets);
        }

        public void TimeLineStep()
        {

        }

        public void Interrupt()
        {
            state = ActionState.CoolDown;
            startTimeStamp = Time.time;
            hasBeenInterrupted = true;
            author.Interrupt();
        }

        public void Finish()
        {
            author.DecideNextAction();
        }
    }
}
