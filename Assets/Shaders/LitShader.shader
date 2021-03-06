Shader "Custom/LitShader"
{
    Properties{
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Texture", 2D) = "white" {}
        _BumpMap("Bumpmap", 2D) = "bump" {}
        _RimColor("Rim color", Color) = (0.26, 0.19, 0.16, 0.0)
        _RimPower("Rim power", Range(0.5, 8.0)) = 3.0
    }
        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 200
            CGPROGRAM
            #pragma surface surf Standard fullforwardshadows

            #pragma target 3.0

            sampler2D _MainTex;
            sampler2D _BumpMap;
            float4 _RimColor;
            float _RimPower;

            struct Input {
                float2 uv_MainTex;
                float2 uv_BumpMap;
                float3 viewDir;
            };

            fixed4 _Color;

            UNITY_INSTANCING_BUFFER_START(Props)
            UNITY_INSTANCING_BUFFER_END(Props)

            void surf(Input IN, inout SurfaceOutputStandard o) {
                o.Albedo = (tex2D(_MainTex, IN.uv_MainTex) * _Color).rgb;
                o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

                half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
                o.Emission = _RimColor.rgb * pow(rim, _RimPower);
            }
            ENDCG
    }
        FallBack "Diffuse"
}
