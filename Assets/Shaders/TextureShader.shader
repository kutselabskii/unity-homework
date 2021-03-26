Shader "Custom/TextureShader"
{
    Properties {
        _MainTex("Texture", 2D) = "white" {}
    }
    SubShader {
        Tags { "RenderType" = "Opaque" }
        CGPROGRAM
        #pragma surface surf Lambert

        struct Input {
            float2 uv_mainTex;
        };
        sampler2D _MainTex;

        void surf(Input IN, inout SurfaceOutput o) {
            o.Albedo = tex2D(_MainTex, IN.uv_mainTex).rgb;
        }
        ENDCG
    }
        FallBack "Diffuse"
}
