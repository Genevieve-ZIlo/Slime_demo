Shader "Custom/SoftBodySlime"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)  
        _Displacement ("Displacement Strength", Range(0, 1)) = 0.2
        _Speed ("Speed", Range(0.1, 2)) = 0.5
        _Metallic ("Metallic", Range(0, 1)) = 0.5
        _Smoothness ("Smoothness", Range(0, 1)) = 0.9
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        float4 _Color;  
        float _Displacement;
        float _Speed;
        float _Metallic;
        float _Smoothness;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Sample the texture and multiply by the color

            half4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
            o.Metallic = _Metallic;
            o.Smoothness = _Smoothness;

            // Create a noise pattern for vertex displacement
            float noise = sin(_Time.y * _Speed + IN.worldPos.x + IN.worldPos.z) * _Displacement;
            o.Normal = o.Normal + float3(0, noise, 0);
        }
        ENDCG
    }
    FallBack "Diffuse"
}