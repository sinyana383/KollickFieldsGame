using UnityEngine;
using UnityEngine.Events;
using static EventManager;

public static class EventManager
{
    public static readonly PlayerEv Player = new PlayerEv();
    public static readonly AkratitEv Akratit = new AkratitEv();
    public static readonly BodiesEv Bodies = new BodiesEv();
    public static readonly IdolEv Idol = new IdolEv();
    public static readonly ZoneEv Zone = new ZoneEv();
    public class PlayerEv
    {
        public UnityAction OnHealthChanged;
    }
    
    public class AkratitEv
    {
        public UnityAction OnAkratitFound;
        
        public UnityAction<int> OnAkratitHit;
        public UnityAction OnAkratitDeath;
    }
    
    public class BodiesEv
    {
        public UnityAction OnBodiesFound;
    }
    public class IdolEv
    {
        public UnityAction OnIdolFound;
        public UnityAction OnIdolDestroyed;
    }
    
    public class ZoneEv
    {
        public UnityAction OnFieldEntered;
        public UnityAction OnFieldExit;
        public UnityAction OnPlayerRelease;
    }
}
