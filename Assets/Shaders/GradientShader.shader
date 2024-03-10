Shader "Custom/SpriteUnlitColorChange"
{
    Properties
    {
        _MainText("Main Texture", 2D) = "white" {}
    }

    SubShader
    {        
        Cull Off
        Lighting Off

        Pass
        {
            CGPROGRAM
            #pragma surface surf

            sampler2D _MainText;

            struct Input
            {
                half2 uv_MainText;
            };

            void surf(Input IN, inout SurfaceOutput o)
            {
                o.Albedo = tex2D(_MainText, IN.uv_MainText);
            }
            
            ENDCG
        }
    }
}