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
    public static readonly GameEv Game = new GameEv();
    public static readonly SaveEv Save = new SaveEv();
    public class PlayerEv
    {
        public UnityAction OnFlashlightSwitch;
        public UnityAction OnMenuSwitch;
        public UnityAction OnTaskListSwitch;
        public UnityAction OnStaminaUseEntered;
        public UnityAction OnStaminaUseExited;
        public UnityAction<float> OnStaminaChanged;
        public UnityAction<float> OnHealthChanged;

        public UnityAction OnPlayerDeath;
    }
    
    public class AkratitEv
    {
        public UnityAction OnAkratitFound;
        
        public UnityAction<int> OnAkratitHit;
        public UnityAction<TaskManager.TasksNames> OnAkratitDeath;
        public UnityAction<TaskManager.TasksNames> RunFromAkratit;
        
        public UnityAction<int> OnAkratitSpotPlayer;
        public UnityAction<int> OnAkratitLosePlayer;
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

    public class GameEv
    {
        public UnityAction OnGameOver;
        public UnityAction<int> OnSceneTransition;
        public UnityAction<float> OnSoundVolumeChanged;
        public UnityAction<float> OnMusicVolumeChanged;
        public UnityAction<float> OnVoiceChanged;
    }

    public class SaveEv
    {
        public UnityAction OnSaveGame;
        public UnityAction OnSaveSettings;
        public UnityAction OnSaveAllDisable;
        public UnityAction OnSaveAllEnable;
    }
}
