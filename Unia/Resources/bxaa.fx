#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1

SamplerState TexSampler : register(s0);
Texture2D TextureSampler : register(t0);
Texture2D RefractSampler : register(t1);

float3 screen = float3(320, 640, 0);
float3 pos = float3(0.5, 0.5, 0);
float angle;
float altangle;
float blurscale = 2;

float4 Blur(Texture2D tex, float2 uv)
{
    float dx;
    float dy;
    tex.GetDimensions(dx, dy);
    dx = 1.0f / (900 * blurscale);
    dy = 1.0f / (420 * blurscale);

    float4 colorSum = float4(0, 0, 0, 0);

    colorSum += tex.Sample(TexSampler, uv + float2(-3 * dx, -3 * dy)) * 1;
    colorSum += tex.Sample(TexSampler, uv + float2(-2 * dx, -2 * dy)) * 2;

    colorSum += tex.Sample(TexSampler, uv + float2(-2 * dx, -2 * dy)) * 1;
    colorSum += tex.Sample(TexSampler, uv + float2(-1 * dx, -2 * dy)) * 2;
    colorSum += tex.Sample(TexSampler, uv + float2(-1 * dx, -1 * dy)) * 3;
    colorSum += tex.Sample(TexSampler, uv + float2(0, 0 * dy)) * 4;
    colorSum += tex.Sample(TexSampler, uv + float2(1 * dx, -1 * dy)) * 3;
    colorSum += tex.Sample(TexSampler, uv + float2(1 * dx, -2 * dy)) * 2;
    colorSum += tex.Sample(TexSampler, uv + float2(2 * dx, -2 * dy)) * 1;

    colorSum += tex.Sample(TexSampler, uv + float2(2 * dx, -2 * dy)) * 2;
    colorSum += tex.Sample(TexSampler, uv + float2(3 * dx, -3 * dy)) * 1;

    //colorSum += tex.Sample(TexSampler, uv + float2(-2 * dx,  2 * dy)) * 1;
    //colorSum += tex.Sample(TexSampler, uv + float2(-1 * dx,  1 * dy)) * 4;
    //colorSum += tex.Sample(TexSampler, uv + float2(      0,  0 * dy)) * 5;
    //colorSum += tex.Sample(TexSampler, uv + float2( 1 * dx,  1 * dy)) * 4;
    //colorSum += tex.Sample(TexSampler, uv + float2( 2 * dx,  2 * dy)) * 1;

    return colorSum / 16;
}


float4 main(float4 pos : SV_POSITION, float4 col : COLOR, float2 uv : TEXCOORD0) : COLOR
{
    float4 t1 = Blur(TextureSampler, uv);
    float4 ret = t1 * col;
    //ret.r += uv.y * pow(t1.g,5)*1;
    //ret.a = 1;
    return ret;
}

technique Warper
{
    pass P0
    {
        //VertexShader = compile VS_SHADERMODEL vs_main();
        PixelShader = compile PS_SHADERMODEL main();
    }
};