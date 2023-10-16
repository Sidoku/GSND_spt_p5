using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBakeLight : MonoBehaviour
{
    public Texture2D[] BrightMapsDir;
    public Texture2D[] BrightMapsColor;
    public Texture2D[] DarkMapsDir;
    public Texture2D[] DarkMapsColor;

    public LightmapData[] BrightLightMaps;
    public LightmapData[] DarkLightMaps;
    public Light PointLight;
    public Vector2 BlickTime;

    private void Start()
    {
        List<LightmapData> dlightMap = new List<LightmapData>();
        for (int i = 0; i < DarkMapsDir.Length; i++)
        {
            LightmapData lData = new LightmapData();
            lData.lightmapDir = DarkMapsDir[i];
            lData.lightmapColor = DarkMapsColor[i];

            dlightMap.Add(lData);
        }

        DarkLightMaps = dlightMap.ToArray();

        List<LightmapData> blightMap = new List<LightmapData>();
        for (int i = 0; i < BrightMapsDir.Length; i++)
        {
            LightmapData lData = new LightmapData();
            lData.lightmapDir = BrightMapsDir[i];
            lData.lightmapColor = BrightMapsColor[i];

            blightMap.Add(lData);
        }

        BrightLightMaps = blightMap.ToArray();

        SwitchLight();
    }

    [ContextMenu("²âÊÔ")]
    public void SwitchLight()
    {
        StartCoroutine(LightCou());
    }

    private IEnumerator LightCou()
    {
        while(true)
        {
            if (PointLight.enabled)
            {
                PointLight.enabled = false;
                LightmapSettings.lightmaps = DarkLightMaps;

            }
            else
            {
                PointLight.enabled = true;
                LightmapSettings.lightmaps = BrightLightMaps;
            }
            yield return new WaitForSeconds(Random.Range(BlickTime.x, BlickTime.y));
        }    
    }
}
