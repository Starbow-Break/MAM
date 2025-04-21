Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PulsePosition ("PulsePosition", float) = 0.0
        _PolyPosition ("PolyPosition", float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _PulsePosition;
            float _PolyPosition;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }
            
            float tri(float x)
            {
                return abs(fmod(x * 0.2, 2.0) - 1.0) - 0.5;
            }

            float truncSine(float x)
            {
                const float height = 100.0;
                const float sineWidth = 30.0;
                const float pi = 3.1415;
                
                if(x < 0.0 || x > sineWidth)
                {
                    return 0.0;
                }
                
                return sin(x * pi/sineWidth) * height;
            }

            float rdWave(float x, float t)
            {
                return truncSine(x - t) * tri(x);
            }

            fixed4 calcColor(float2 coord)
            {
                float4 ret;
                
                const float yOffset = -200.0;
    
                float x = coord.x;
                float y = coord.y - yOffset;
                float t = _PulsePosition * 40.0;
                
                bool center = rdWave(x, t) > y;
                bool right  = rdWave(x - 1.0, t) > y; 
                bool left   = rdWave(x + 1.0, t) > y; 
                bool up     = rdWave(x, t) > y + 1.0;
                bool down   = rdWave(x, t) > y - 1.0;

                if(center && !(right && left && up && down))
                    ret = fixed4(0.0, 1.0, 0.0, 1.0);
                else
                    ret = fixed4(0.0, 0.0, 0.0, 0.0);

                return ret;
            }

            fixed4 drawCircle(float2 coord)
            {
                float4 ret;
                
                float dx = coord.x - _PolyPosition;
                float dy = coord.y + 200.0;
                float d2 = dx * dx + dy * dy;
                if (39 * 39 <= d2 && d2 <= 40 * 40)
                {
                    ret = fixed4(0.0, 1.0, 0.0, 1.0);
                }
                else
                {
                    ret = fixed4(0.0, 0.0, 0.0, 0.0);
                }

                return ret;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float4 screenPos = ComputeScreenPos(i.vertex);

                float2 coord = screenPos/screenPos.w;
                fixed4 col = calcColor(coord);
                
                float dx = coord.x - _PolyPosition;
                float dy = coord.y + 200.0;
                float d2 = dx * dx + dy * dy;
                if (40 * 40 >= d2)
                {
                    col = drawCircle(coord);
                }
                
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
