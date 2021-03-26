Shader "Custom/TextureAndNormalShader"
{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _BumpMap("Bumpmap", 2D) = "bump" {}
    }
        SubShader{
            Tags { "RenderType" = "Opaque" }
            CGPROGRAM
            #pragma surface surf Lambert

            struct Input {
                float2 uv_mainTex;
                float2 uv_bumpMap;
            };
            sampler2D _MainTex;
            sampler2D _BumpMap;

            void surf(Input IN, inout SurfaceOutput o) {
                o.Albedo = tex2D(_MainTex, IN.uv_mainTex).rgb;
                o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_bumpMap));
            }
            ENDCG
    }
        FallBack "Diffuse"
}
