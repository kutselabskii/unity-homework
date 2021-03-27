Shader "Custom/SlicesShader"
{
    Properties{
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Texture", 2D) = "white" {}
        _BumpMap("Bumpmap", 2D) = "bump" {}
    }
        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 200
            Cull Off
            CGPROGRAM
            #pragma surface surf Standard fullforwardshadows

            #pragma target 3.0

            sampler2D _MainTex;
            sampler2D _BumpMap;

            struct Input {
                float2 uv_MainTex;
                float2 uv_BumpMap;
                float3 worldPos;
            };

            fixed4 _Color;

            UNITY_INSTANCING_BUFFER_START(Props)
            UNITY_INSTANCING_BUFFER_END(Props)

            void surf(Input IN, inout SurfaceOutputStandard o) {
                clip(frac((IN.worldPos.y + IN.worldPos.z * 0.1) * 5) - 0.5);

                o.Albedo = (tex2D(_MainTex, IN.uv_MainTex) * _Color).rgb;
                o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
            }
            ENDCG
        }
            FallBack "Diffuse"
}
