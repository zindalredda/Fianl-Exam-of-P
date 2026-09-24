Shader "Custom/SpriteOutline"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Sprite Color", Color) = (1,1,1,1)

        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineSize ("Outline Size", Range(0,0.05)) = 0.01
        _OutlineAlpha ("Outline Alpha", Range(0,1)) = 0
    }

    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "RenderPipeline"="UniversalPipeline"
            "CanUseSpriteAtlas"="True"
        }

        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 color : COLOR;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            CBUFFER_START(UnityPerMaterial)

                float4 _MainTex_ST;
                float4 _Color;
                float4 _OutlineColor;
                float _OutlineSize;
                float _OutlineAlpha;

            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;

                output.positionHCS =
                    TransformObjectToHClip(input.positionOS.xyz);

                output.uv =
                    TRANSFORM_TEX(input.uv, _MainTex);

                output.color =
                    input.color * _Color;

                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                half4 original = SAMPLE_TEXTURE2D(
                    _MainTex,
                    sampler_MainTex,
                    input.uv
                ) * input.color;

                float2 offset = float2(_OutlineSize, _OutlineSize);

                float alphaRight = SAMPLE_TEXTURE2D(
                    _MainTex,
                    sampler_MainTex,
                    input.uv + float2(offset.x, 0)
                ).a;

                float alphaLeft = SAMPLE_TEXTURE2D(
                    _MainTex,
                    sampler_MainTex,
                    input.uv - float2(offset.x, 0)
                ).a;

                float alphaUp = SAMPLE_TEXTURE2D(
                    _MainTex,
                    sampler_MainTex,
                    input.uv + float2(0, offset.y)
                ).a;

                float alphaDown = SAMPLE_TEXTURE2D(
                    _MainTex,
                    sampler_MainTex,
                    input.uv - float2(0, offset.y)
                ).a;

                float alphaUpRight = SAMPLE_TEXTURE2D(
                    _MainTex,
                    sampler_MainTex,
                    input.uv + offset
                ).a;

                float alphaUpLeft = SAMPLE_TEXTURE2D(
                    _MainTex,
                    sampler_MainTex,
                    input.uv + float2(-offset.x, offset.y)
                ).a;

                float alphaDownRight = SAMPLE_TEXTURE2D(
                    _MainTex,
                    sampler_MainTex,
                    input.uv + float2(offset.x, -offset.y)
                ).a;

                float alphaDownLeft = SAMPLE_TEXTURE2D(
                    _MainTex,
                    sampler_MainTex,
                    input.uv - offset
                ).a;

                float surroundingAlpha = max(
                    max(alphaRight, alphaLeft),
                    max(alphaUp, alphaDown)
                );

                surroundingAlpha = max(
                    surroundingAlpha,
                    max(
                        max(alphaUpRight, alphaUpLeft),
                        max(alphaDownRight, alphaDownLeft)
                    )
                );

                float outline =
                    saturate(surroundingAlpha - original.a);

                outline *= _OutlineAlpha;

                half4 result = original;

                result.rgb = lerp(
                    result.rgb,
                    _OutlineColor.rgb,
                    outline * _OutlineColor.a
                );

                result.a = max(
                    original.a,
                    outline * _OutlineColor.a
                );

                return result;
            }

            ENDHLSL
        }
    }
}