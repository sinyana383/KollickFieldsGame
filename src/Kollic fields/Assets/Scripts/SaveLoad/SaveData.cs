using UnityEngine;
using UnityEngine.Serialization;

public class SaveData
{
    [System.Serializable]
    public class GameStateData
    {
        public int missingPeople;
        public int mainEnemy;
        public int idol;
        public int mainCharacter;

        public GameStateData(GameState gameState) 
        {
            missingPeople = (int)gameState.bodies;
            mainEnemy = (int)gameState.akratit;
            idol = (int)gameState.idol;
            mainCharacter = (int)gameState.mainCharacter;
        }
    }

    [System.Serializable]
    public class TaskManagerData
    {
        public int[] taskStates;
        public bool wasWin;

        public TaskManagerData(TaskManager taskManager)
        {
            this.wasWin = taskManager.wasWin;
            taskStates = new int[taskManager.tasksPool.Count];
            for (int i = 0; i < taskManager.tasksPool.Count; i++)
            {
                taskStates[i] = (int)taskManager.tasksPool[i].taskState;
            }
        }
    }
    
    [System.Serializable]
    public class SettingsData
    {
        public float backgroundVolume;
        public float soundVolume;
        public float brightness;
        public float voiceValume;

        public SettingsData(SettingsManager settingsManager)
        {
            backgroundVolume = settingsManager.BackgroundVolume;
            soundVolume = settingsManager.SoundVolume;
            brightness = settingsManager.Brightness;
            voiceValume = settingsManager.Voice;
        }
    }

    [System.Serializable]
    public class PlayerData
    {
        public float[] position = new float[3];
        public int hp;

        public PlayerData(Player player)
        {
            hp = player.HP;
            
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;
        }
    }
    
    [System.Serializable]
    public class GrabInteractableData
    {
        public float[] position = new float[3];
        public GrabInteractableData(GrabInteractable grabInteractable)
        {
            position[0] = grabInteractable.transform.position.x;
            position[1] = grabInteractable.transform.position.y;
            position[2] = grabInteractable.transform.position.z;
        }
    }
    
    [System.Serializable]
    public class AkratitData
    {
        public float[] position = new float[3];
        public float[] rotation = new float[3];
        public int hp;
        public bool isDead;
        public AkratitData(Akratit akratit)
        {
            hp = akratit.hp;
            isDead = akratit.isDead;
            
            position[0] = akratit.transform.position.x;
            position[1] = akratit.transform.position.y;
            position[2] = akratit.transform.position.z;
            
            rotation[0] = akratit.transform.rotation.x;
            rotation[1] = akratit.transform.rotation.y;
            rotation[2] = akratit.transform.rotation.z;
        }
    }
    
    [System.Serializable]
    public class IdolData
    {
        public int toughness;
        public IdolData(Idol idol)
        {
            toughness = idol.breakable.toughness;
        }
    }
}
