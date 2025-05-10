using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static readonly PlayerEv Player = new PlayerEv();
    public static readonly AkratitEv Akratit = new AkratitEv();
    public static readonly BodiesEv Bodies = new BodiesEv();
    public static readonly IdolEv Idol = new IdolEv();
    public static readonly TasksEv Tasks = new TasksEv();
    public class PlayerEv
    {
        public UnityAction OnHealthChanged;
    }
    
    public class AkratitEv
    {
        public UnityAction OnAkratitFound;
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
    
    public class TasksEv
    {
        
    }
}
