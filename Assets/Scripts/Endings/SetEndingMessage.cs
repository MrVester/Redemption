using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEndingMessage : MonoBehaviour
{
    public Text message;
    private void Awake()
    {
        message.text = MessageBank.message;
    }
}
