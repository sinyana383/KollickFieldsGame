using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static readonly PlayerEv Player = new PlayerEv();
    public static readonly AkratitEv Akratit = new AkratitEv();
    public static readonly PeopleEv People = new PeopleEv();
    public static readonly IdolEv Idol = new IdolEv();
    public class PlayerEv
    {
        public UnityAction OnHealthChanged;
    }
    
    public class AkratitEv
    {
        public UnityAction OnAkratitFound;
    }
    
    public class PeopleEv
    {
        public UnityAction OnPeopleFound;
    }
    public class IdolEv
    {
        public UnityAction OnIdolFound;
        public UnityAction OnIdolDestroyed;
    }
}
