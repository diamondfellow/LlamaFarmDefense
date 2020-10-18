using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlareText : MonoBehaviour
{
    public Color color;
    RectTransform rectTransform;
    public GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "FarmText")
        {
            color.a -= Time.deltaTime * .5f;
            GetComponent<Text>().color = color;
            if (color.a < .01)
            {
                Destroy(gameObject);
            }
        }
        if (gameController.GetComponent<GameController>().gameEnded)
        {
            if (gameObject.name == "GameText")
            {
                Vector2 position = rectTransform.anchoredPosition;
                if (position.y > 109)
                {
                    position.y -= 300 * Time.deltaTime;
                    rectTransform.anchoredPosition = position;
                }
            }
            else if (gameObject.name == "EndText")
            {
                Vector2 position = rectTransform.anchoredPosition;
                if (position.y < -8)
                {
                    position.y += 300 * Time.deltaTime;
                    rectTransform.anchoredPosition = position;
                }
            }
        }
    }
}
