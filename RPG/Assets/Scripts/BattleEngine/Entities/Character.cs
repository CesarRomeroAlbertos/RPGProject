﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
namespace BattleEngine.Entities
{
    public class Character
    {
        #region Private/Public variables
        [SerializeField] protected int currentLife;
        [SerializeField] protected int maxLife;
        protected BattleAction currentAction;
        #endregion
        
        public virtual void DecideNextAction() { }

        public virtual void Interrupt() { }
    }
}
