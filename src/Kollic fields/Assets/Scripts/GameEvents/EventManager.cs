using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static readonly PlayerEv Player = new PlayerEv();
    public static readonly AkratitEv Akratit = new AkratitEv();
    public static readonly BodiesEv Bodies = new BodiesEv();
    public static readonly IdolEv Idol = new IdolEv();
    public static readonly ZoneEv Zone = new ZoneEv();
    public static readonly EndTextEv EndText = new EndTextEv();
    public static readonly GameOverEv GameOver = new GameOverEv();
    public static readonly SaveEv Save = new SaveEv();
    public class PlayerEv
    {
        public UnityAction OnHealthChanged;
        public UnityAction OnFlashlightSwitch;
        public UnityAction OnMenuSwitch;
        public UnityAction OnTaskListSwitch;
        public UnityAction OnStaminaUseEntered;
        public UnityAction OnStaminaUseExited;
    }
    
    public class AkratitEv
    {
        public UnityAction OnAkratitFound;
        
        public UnityAction<int> OnAkratitHit;
        public UnityAction<TaskManager.TasksNames> OnAkratitDeath;
    }
    
    public class BodiesEv
    {
        public UnityAction<TaskManager.TasksNames> OnBodiesFound;
    }
    public class IdolEv
    {
        public UnityAction<TaskManager.TasksNames> OnIdolFound;
        public UnityAction<TaskManager.TasksNames> OnIdolDestroyed;
    }
    
    public class ZoneEv
    {
        public UnityAction<TaskManager.TasksNames> OnFieldEntered;
        public UnityAction<string> OnWarningEntered;
        public UnityAction OnFieldExit;
        public UnityAction OnPlayerRelease;
    }

    public class EndTextEv
    {
        public UnityAction OnTextRevealed;
    }

    public class GameOverEv
    {
        public UnityAction OnGameOver;
    }

    public class SaveEv
    {
        public UnityAction OnSaveGame;
        public UnityAction OnSaveSettings;
    }
}
