

struct PS_IN
{
	float4 position : SV_POSITION;
	float4 color : COLOR0;
	float2 texCoord : TEXCOORD0;
};


sampler TextureSampler : register(s0);

float2		gScreenLightPos;
float		gDensity;
float		gDecay;
float		gWeight;
float		gExposure;
int         NUM_SAMPLES = 2;

float4 PixelShaderFunction(PS_IN input) : SV_TARGET0
{
	float2 TexCoord = input.texCoord;
	float2 DeltaTexCoord = float2(TexCoord.xy - gScreenLightPos.xy);
	DeltaTexCoord *= 1.0 / NUM_SAMPLES * gDensity;
	float4 Color = tex2D(TextureSampler, TexCoord);
	float IlluminationDecay = 1.0;
	float4 Sample;
	//[unroll (400)]
	for (int i = 0; i < NUM_SAMPLES; ++i)
	{
		TexCoord -= DeltaTexCoord;
		Sample = tex2D(TextureSampler, TexCoord);
		Sample *= IlluminationDecay * gWeight;
		Color += Sample;
		IlluminationDecay *= gDecay;
	}
	return Color * gExposure;
}

technique Technique1
{
	pass Pass1
	{
		PixelShader = compile ps_4_0 PixelShaderFunction();
	}
}
