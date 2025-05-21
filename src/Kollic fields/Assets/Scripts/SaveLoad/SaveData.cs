using UnityEngine;

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
    public class SettingsData
    {
        public float backgroundVolume;
        public float soundVolume;
        public float brightness;

        public SettingsData(SettingsManager settingsManager)
        {
            backgroundVolume = settingsManager.BackgroundVolume;
            soundVolume = settingsManager.SoundVolume;
            brightness = settingsManager.Brightness;
        }
    }
}
