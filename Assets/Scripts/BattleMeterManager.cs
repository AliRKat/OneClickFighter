using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleMeterManager : MonoBehaviour
{
    public float batteMeterTurnLength = 2.0f;
    public Slider battleMeterSlider;
    
    [System.Serializable]
    public class InteractionZone
    {
        public float minValue;
        public float maxValue;
        public InteractionType interactionType;
    }

    public enum InteractionType
    {
        SingleTap,
        LongTap,
        MultipleTaps
    }

    public InteractionZone[] interactionZones;

    public void StartBattleMeter()
    {
        StartCoroutine(AnimateBattleMeter(batteMeterTurnLength));
    }

    private IEnumerator AnimateBattleMeter(float duration)
    {
        float halfDuration = duration / 2.0f;
        float elapsedTime = 0f;

        // Increase slider value from 0 to 1
        while (elapsedTime < halfDuration)
        {
            elapsedTime += Time.deltaTime;
            battleMeterSlider.value = Mathf.Lerp(0, 1, elapsedTime / halfDuration);
            yield return null;
        }

        // Reset elapsed time for the decrease
        elapsedTime = 0f;

        // Decrease slider value from 1 to 0
        while (elapsedTime < halfDuration)
        {
            elapsedTime += Time.deltaTime;
            battleMeterSlider.value = Mathf.Lerp(1, 0, elapsedTime / halfDuration);
            yield return null;
        }

        // Ensure slider is set to 0 at the end
        battleMeterSlider.value = 0;
    }
}