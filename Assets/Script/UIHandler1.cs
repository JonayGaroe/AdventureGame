using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler1 : MonoBehaviour
{


    public static UIHandler1 instance { get; private set; }
    private VisualElement m_Healthbar;

    //dialogo
    public float displayTime = 4.0f;
    private VisualElement m_NonPlayerDialogue1;
    private float m_TimerDisplay;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1.0f);


        m_NonPlayerDialogue1 = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue1");
        m_NonPlayerDialogue1.style.display = DisplayStyle.None;
        m_TimerDisplay = -1.0f;


    }



    private void Update()
    {
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;
            if (m_TimerDisplay < 0)
            {
                m_NonPlayerDialogue1.style.display = DisplayStyle.None;
            }


        }
    }


    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(100 * percentage);
    }


    public void DisplayDialogue()
    {
        m_NonPlayerDialogue1.style.display = DisplayStyle.Flex;
        m_TimerDisplay = displayTime;
    }

}

