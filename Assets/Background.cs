using UnityEngine;

public class Background : MonoBehaviour
{
    public Sprite[] backgrounds;

    private void Start()
    {
        SetRandomBackground();
    }

    private void SetRandomBackground()
    {
        if (backgrounds.Length > 0)
        {
            int randomIndex = Random.Range(0, backgrounds.Length);
            Sprite randomBackground = backgrounds[randomIndex];
            GetComponent<SpriteRenderer>().sprite = randomBackground;
        }
    }
}
