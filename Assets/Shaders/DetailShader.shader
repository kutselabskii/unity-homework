Shader "Custom/DetailShader"
{
    Properties {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Texture", 2D) = "white" {}
        _BumpMap("Bumpmap", 2D) = "bump" {}
        _Detail("Detail", 2D) = "gray" {}
    }
    SubShader {
        Tags { "RenderType" = "Opaque" }
        LOD 200
        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows
            
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        sampler2D _Detail;

        struct Input {
            float2 uv_MainTex;
            float2 uv_BumpMap;
            float2 uv_Detail;
        };

        fixed4 _Color;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf(Input IN, inout SurfaceOutputStandard o) {
            o.Albedo = (tex2D(_MainTex, IN.uv_MainTex) * _Color).rgb;
            o.Albedo *= tex2D(_Detail, IN.uv_Detail).rgb * 2;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
        }
        ENDCG
    }
        FallBack "Diffuse"
}
