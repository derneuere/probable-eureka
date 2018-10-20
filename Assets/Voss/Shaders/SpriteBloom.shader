// Instructions:
// Camera enable [x] HDR
// Add Bloom cinematic image effect to Camera, with Threshold 1.1 (so only values over 1.1 will get bloomy)

Shader "UnityCommunity/Sprites/HDRBloom"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		_BloomThreshold ("BloomThreshold", Float) = 0.9
		_Intensity ("Intensity", Float) = 1.5
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile _ PIXELSNAP_ON
			#pragma multi_compile _ ETC1_EXTERNAL_ALPHA
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				float4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
			};
			
			float4 _Color;
			float _BloomThreshold;
			float _Intensity;

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color * _Color;
				#ifdef PIXELSNAP_ON
				OUT.vertex = UnityPixelSnap (OUT.vertex);
				#endif

				return OUT;
			}

			sampler2D _MainTex;
			sampler2D _AlphaTex;

			// http://theorangeduck.com/page/avoiding-shader-conditionals
			float when_gt(float x, float y) {
			  return sqrt(max(sign(x - y), 0.0));
			}
			/*
			float when_gt(float x, float y) {
			  return max(sign(x - y), 0.0);
			}
            */
			float4 SampleSpriteTexture (float2 uv)
			{
				float4 color = tex2D (_MainTex, uv);

#if ETC1_EXTERNAL_ALPHA
				// get the color from an external texture (usecase: Alpha support for ETC1 on android)
				//color.a = tex2D (_AlphaTex, uv).r;
#endif //ETC1_EXTERNAL_ALPHA

				return color;
			}

			float4 frag(v2f IN) : SV_Target
			{
				float4 tex = SampleSpriteTexture (IN.texcoord);
				float4 c = tex * IN.color;

				c.r += _Intensity * when_gt(c.r, _BloomThreshold); // if r+g+b > threshold, then make this color brighter than 1
				c.g += _Intensity * when_gt(c.g, _BloomThreshold); // if r+g+b > threshold, then make this color brighter than 1
				c.b += _Intensity * when_gt(c.b, _BloomThreshold); // if r+g+b > threshold, then make this color brighter than 1

				c.rgb *= c.a;
                                       
				return c;
			}
		ENDCG
		}
	}
}