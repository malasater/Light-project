using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //public HitPoints hitPoints;

    //[HideInInspector]
    public Character character;

    float hitPoints;

    public Image meterImage;

    //public Text hpText;

    float maxHitPoints;

    void Start()
    {
        maxHitPoints = character.maxHitPoints;
    }

    void Update()
    {
        if (character != null)
        {
            hitPoints = character.GetComponent<Player>().hitPoints;
            meterImage.fillAmount = hitPoints / maxHitPoints;
            //hpText.text = "HP:" + (meterImage.fillAmount * 100);
        }
    }
}
