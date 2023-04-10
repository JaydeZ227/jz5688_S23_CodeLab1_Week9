using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Dictionary<string, string> cardDescriptions;
    public Text cardDescriptionText;
    public Image textBackground;
    void Start()
    {
        InitializeCardDescriptions();
    }

    private void InitializeCardDescriptions()
    {
        cardDescriptions = new Dictionary<string, string>
        {
            { "00", "The Fool represents new beginnings, having faith in the future, and being inexperienced." },
            { "01", "The Magician represents manifestation, resourcefulness, power, and inspired action." },
            { "02", "The High Priestess symbolizes intuition, mystery, and the power of the subconscious mind." },
            { "03", "The Empress signifies nurturing, fertility, abundance, and the power of creation." },
            { "04", "The Emperor stands for authority, stability, leadership, and the power of reason." },
            { "05", "The Hierophant embodies tradition, spiritual guidance, religious beliefs, and moral values." },
            { "06", "The Lovers represent relationships, love, choices, and the balance of opposites." },
            { "07", "The Chariot signifies victory, determination, self-control, and the triumph of willpower." },
            { "08", "Strength symbolizes courage, patience, inner strength, and the power of compassion." },
            { "09", "The Hermit represents solitude, introspection, seeking wisdom, and inner guidance." },
            { "10", "Wheel of Fortune signifies luck, cycles, destiny, and the turning points of life." },
            { "11", "Justice embodies fairness, balance, truth, and the importance of objective decision-making." },
            { "12", "The Hanged Man represents sacrifice, letting go, seeing things from a new perspective, and spiritual awakening." },
            { "13", "Death signifies transformation, endings, change, and the process of renewal." },
            { "14", "Temperance symbolizes balance, harmony, moderation, and the merging of opposites." },
            { "15", "The Devil represents temptation, bondage, materialism, and the darker aspects of our nature." },
            { "16", "The Tower signifies sudden upheaval, chaos, liberation, and the breaking down of old structures." },
            { "17", "The Star represents hope, inspiration, spiritual guidance, and the promise of a brighter future." },
            { "18", "The Moon symbolizes the subconscious mind, intuition, illusions, and the realm of dreams and emotions." },
            { "19", "The Sun signifies vitality, happiness, success, and the warmth of the spirit." },
            { "20", "Judgement represents spiritual awakening, redemption, evaluation, and the call to a higher purpose." },
            { "21", "The World signifies completion, achievement, integration, and the fulfillment of one's goals." },
        };
    }

    private IEnumerator HideCardInfoAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        cardDescriptionText.text = "";
        textBackground.gameObject.SetActive(false);
    }
    
    private Coroutine hideCoroutine;
    public void DisplayCardInfo(string cardName)
    {
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine); // 停止先前的协程
        }

        if (cardDescriptions.ContainsKey(cardName))
        {
            string description = cardDescriptions[cardName];
            cardDescriptionText.text = $"Card: {cardName}\nDescription: {description}";
            textBackground.gameObject.SetActive(true); // 激活背景

            hideCoroutine = StartCoroutine(HideCardInfoAfterDelay(2.5f)); // 启动新的协程，使文本和背景在3秒后消失
        }
        else
        {
            Debug.LogWarning($"Unknown card name: {cardName}");
        }
    }

}
