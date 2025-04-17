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
            None,
            WaitingPhase,
            FindPlanePhase,
            SelectPhase,
            CountdownPhase,
            PlantPhase,
            LevelLosePhase,
            LevelWinPhase,
        }

        public EGameState CurGameState => _curState.StateKey;

        public void Init()
        {
            _stateDict.Add(EGameState.WaitingPhase, new WaitingPhaseState(EGameState.WaitingPhase));
            _stateDict.Add(EGameState.FindPlanePhase, new FindPlanePhaseState(EGameState.FindPlanePhase));
            _stateDict.Add(EGameState.SelectPhase, new SelectPhaseState(EGameState.SelectPhase));
            _stateDict.Add(EGameState.CountdownPhase, new CountdownPhase(EGameState.CountdownPhase));
            _stateDict.Add(EGameState.PlantPhase, new PlantPhaseState(EGameState.PlantPhase));
            _stateDict.Add(EGameState.LevelLosePhase, new LevelLosePhaseState(EGameState.LevelLosePhase));
            _stateDict.Add(EGameState.LevelWinPhase, new LevelWinPhaseState(EGameState.LevelWinPhase));

            ChangeState(EGameState.WaitingPhase);
        }

        public void FinishCurState() => (_curState as BaseGameState).FinishState();

        public void ChoseNextState(EGameState state) => ChangeState(state);
    }
}
