using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleEngine
{
    public class TimeLine : MonoBehaviour
    {
        #region Private/Protected variables
        private List<BattleAction> actingActions;
        private List<BattleAction> coolDownActions;
        private TimeLineState state;
        #endregion

        #region Enums
        public enum TimeLineState { Active, Paused}
        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            if (state == TimeLineState.Active)
            {
                foreach (BattleAction ba in actingActions)
                    ba.TimeLineStep();
                foreach (BattleAction ba in coolDownActions)
                    ba.TimeLineStep();
            }
        }

        public void AddAction(BattleAction action)
        {

        }
    }
}
