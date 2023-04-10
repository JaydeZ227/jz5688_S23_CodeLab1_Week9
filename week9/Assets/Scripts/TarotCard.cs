using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotCard : MonoBehaviour
{
    public string cardName;

    private void OnMouseDown()
    {
        FindObjectOfType<GameManager>().DisplayCardInfo(cardName);
    }
}
