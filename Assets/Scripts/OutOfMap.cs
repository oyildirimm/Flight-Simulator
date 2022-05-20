using System;
using UnityEngine;
using TMPro;

public class OutOfMap : MonoBehaviour
{
    private readonly string warning = "WARNING!";
    private readonly string failed = "FAILED!";

    private float warningDistance = 300f;
    private float failedDistance = 450f;

    [SerializeField] TextMeshProUGUI warningText;
    public static event Action OnMissionFailed;

    void Update()
    {
        if(IsFailed())
        {
            DisplayWarning(failed);
            OnMissionFailed?.Invoke();
        }
        
        else if(GiveWarning())
        {
            DisplayWarning(warning);
        }

        else
        {
            warningText.text = null;
        }
    }

    private bool GiveWarning()
    {        
        return Mathf.Abs(transform.position.x) > warningDistance ||
               Mathf.Abs(transform.position.y) > warningDistance;
    }

    private bool IsFailed()
    {
        return Mathf.Abs(transform.position.x) > failedDistance ||
               Mathf.Abs(transform.position.y) > failedDistance;
    }

    private void DisplayWarning(string text)
    {
        warningText.text = text;
        warningText.alpha = Mathf.PingPong(Time.time * 3, 1f);  //Blink effect
    }
}
