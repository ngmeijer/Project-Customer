using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialMedia : MonoBehaviour
{
    private UIManager uiManager = null;

    [SerializeField] private List<string> positiveTweet = new List<string>();
    [SerializeField] private List<string> negativeTweet = new List<string>();

    public int newPostTreshhold = 100;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public string sendOutPositiveTweet()
    {
        int randomTweetIndex = Random.Range(0, positiveTweet.Count);

        string randomTweetText = positiveTweet[randomTweetIndex];

        return randomTweetText;
    }

    public string sendOutNegativeTweet()
    {
        int randomTweetIndex = Random.Range(0, negativeTweet.Count);

        string randomTweetText = negativeTweet[randomTweetIndex];

        return randomTweetText;
    }
}
