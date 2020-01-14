using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleEngine
{
    public class TimeLine : MonoBehaviour
    {
        #region Private/Protected variables
        private static TimeLine instance;
        private TimeLineState state;
        private List<BattleAction> actingActions;
        #endregion

        #region Enums
        public enum TimeLineState { Active, Paused }
        #endregion

        //Private constructor so only this class can instantiate itself
        private TimeLine() { }

        //Method to get the instance of the timeline
        public static TimeLine getInstance()
        {
            if (instance == null)
                instance = new TimeLine();
            return instance;
        }

        // Start is called before the first frame update
        void Start()
        {
            state = TimeLineState.Paused;
        }

        // Update is called once per frame
        void Update()
        {
            if(state == TimeLineState.Active)
                CheckConflicts();
        }

        private void LateUpdate()
        {
            foreach (BattleAction ba in actingActions)
                ba.Act();
            actingActions.Clear();
        }

        /// <summary>
        /// This method checks the actions happening at the same time and resolves possible conflicts between them, chaining possible interruptions and executing them
        /// </summary>
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
