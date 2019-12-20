using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleEngine
{
    public class TimeLine : MonoBehaviour
    {
        #region Private/Protected variables
        private TimeLineState state;
        private List<BattleAction> actingActions;
        #endregion

        #region Enums
        public enum TimeLineState { Active, Paused }
        #endregion

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void LateUpdate()
        {
            foreach (BattleAction ba in actingActions)
                ba.Act();
            actingActions.Clear();
        }

        private void CheckConflicts()
        {
            List<int> indexToRemove = new List<int>();
            actingActions.Sort((a, b) => b.getAuthor().getSpeed().CompareTo(a.getAuthor().getSpeed()));
            for (int i = 0; i < actingActions.Count; i++)
            {
                for (int j = i + 1; j < actingActions.Count; j++)
                {
                    if (!indexToRemove.Contains(i)
                        && actingActions[i].GetActionTypes().Contains(BattleAction.ActionType.Interrupt)
                        && actingActions[i].getTargets().Contains(actingActions[j].getAuthor())
                        && actingActions[j].GetActionTypes().Contains(BattleAction.ActionType.Interruptable))
                        indexToRemove.Add(j);
                }
            }
            foreach (int n in indexToRemove)
                actingActions[n].Interrupt();
        }

        public void AddAction(BattleAction action)
        {

        }
    }
}
