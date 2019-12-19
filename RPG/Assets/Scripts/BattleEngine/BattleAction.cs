using BattleEngine.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleEngine
{
    public class BattleAction
    {
        #region Private/Protected Variables
        protected float startTimeStamp;
        protected Character author;
        protected Action<List<Character>> actionEffect;
        protected List<Character> targets;
        #endregion
        public BattleAction(Character author, Action<List<Character>> actionEffect,List<Character> targets)
        {
            this.author = author;
            this.actionEffect = actionEffect;
            this.targets = targets;
            startTimeStamp = Time.time;
        }

        public void Act()
        {
            actionEffect(targets);
        }
    }
}
