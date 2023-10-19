using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class TestBakeLight : MonoBehaviour
{
    public Texture2D[] BrightMapsDir;
    public Texture2D[] BrightMapsColor;
    public Texture2D[] DarkMapsDir;
    public Texture2D[] DarkMapsColor;

    public LightmapData[] BrightLightMaps;
    public LightmapData[] DarkLightMaps;
    public Light[] Lights;
    public Vector2 BlickTime;

    public MeshRenderer LightRenderer;
    public Material BrightMat;
    public Material DarkMat;

    private bool IsBlicking;

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
    }

    [ContextMenu("Turn On Light")]
    public void TurnOnLights()
    {
        foreach (var light in Lights)
        {
            light.enabled = true;
        }
        LightRenderer.materials[1] = BrightMat;
        LightmapSettings.lightmaps = BrightLightMaps;
    }

    [ContextMenu("Turn Off Light")]
    public void  TurnOffLights()
    {
        foreach (var light in Lights)
        {
            light.enabled = false;
        }
        LightRenderer.materials[1] = DarkMat;
        LightmapSettings.lightmaps = DarkLightMaps;
    }

    [ContextMenu("Blick Light")]
    public void BlickLight()
    {
        IsBlicking= true;
        StartCoroutine(LightCou());
    }

    [ContextMenu("Stop Blick Light")]
    public void StopBlickLight()
    {
        IsBlicking = false;
    }

    private IEnumerator LightCou()
    {
        while(IsBlicking)
        {
            foreach (var light in Lights)
            {
                if (light.enabled)
                {
                    light.enabled = false;
                    LightRenderer.sharedMaterials[1] = BrightMat;
                    LightmapSettings.lightmaps = DarkLightMaps;

                }
                else
                {
                    light.enabled = true;
                    LightRenderer.sharedMaterials[1] = DarkMat;
                    LightmapSettings.lightmaps = BrightLightMaps;
                }
            }

            yield return new WaitForSeconds(Random.Range(BlickTime.x, BlickTime.y));
        }    
    }
}
