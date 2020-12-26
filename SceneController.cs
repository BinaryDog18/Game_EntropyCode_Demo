using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    Text HealthText;
    HealthSystem playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<HealthSystem>();
        HealthText = GameObject.Find("Text").GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Health: " + playerHealth.GetHealth().ToString();
    }
}
