using PlantsZombiesAR.Helpers;
using System.Collections;
using System.Collections.Generic;
using static PlantsZombiesAR.GameManager.GameflowSM;

namespace PlantsZombiesAR.GameManager
{
    public class GameflowSM : BaseStateMachine<EGameState>
    {
        public enum EGameState
        {
            WaitingPhase,
            SelectPhase,
            CountdownPhase,
            PlantPhase,
            FinishPhase,
        }

        public EGameState CurGameState => _curState.StateKey;

        public void Init()
        {
            _stateDict.Add(EGameState.WaitingPhase, new WaitingPhaseState(EGameState.WaitingPhase));
            _stateDict.Add(EGameState.SelectPhase, new SelectPhaseState(EGameState.SelectPhase));
            _stateDict.Add(EGameState.CountdownPhase, new CountdownPhase(EGameState.CountdownPhase));
            _stateDict.Add(EGameState.PlantPhase, new PlantPhaseState(EGameState.PlantPhase));
            _stateDict.Add(EGameState.FinishPhase, new FinishPhaseState(EGameState.FinishPhase));

            ChangeState(EGameState.WaitingPhase);
        }

        public void FinishCurState() => (_curState as BaseGameState).FinishState();
    }
}
