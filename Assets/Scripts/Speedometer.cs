using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] RectTransform arrow;


    // Update is called once per frame
    void Update()
    {
        speedText.text = (int)SpeedControl.speed + " km/h";
        arrow.localEulerAngles = new Vector3(0, 0, SpeedControl.speed / SpeedControl.maxSpeed * (-180));
    }
}
