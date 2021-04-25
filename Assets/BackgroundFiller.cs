using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFiller : MonoBehaviour
{
    public ResourceFetcher resourceFetcher;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBackground(Level level)
    {
        var backgroundSprites = resourceFetcher.GetBackgroundSprites();
        switch (level)
        {
            case Level.Level1:
                GetComponent<UnityEngine.UI.Image>().sprite = backgroundSprites.level1;
                break;
            case Level.Level2:
                GetComponent<UnityEngine.UI.Image>().sprite = backgroundSprites.level2;
                break;
            case Level.Level3:
                GetComponent<UnityEngine.UI.Image>().sprite = backgroundSprites.level3;
                break;
            case Level.Level4:
                GetComponent<UnityEngine.UI.Image>().sprite = backgroundSprites.level4;
                break;
            case Level.Level5:
                GetComponent<UnityEngine.UI.Image>().sprite = backgroundSprites.level5;
                break;
        }
    }
}
