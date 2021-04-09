using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    public Text score;
    public int temp;

    // Update is called once per frame
    void Update()
    {
        temp = (int)Time.timeSinceLevelLoad;
        score.text = temp.ToString();
    }

}
