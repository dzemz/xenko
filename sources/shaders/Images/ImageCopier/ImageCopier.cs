﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.

using SiliconStudio.Core.Mathematics;
using SiliconStudio.Paradox.Graphics;

namespace SiliconStudio.Paradox.Effects.Images
{
    /// <summary>
    /// Copies from an input texture to an output texture.
    /// </summary>
    /// <remarks>This effect can be used for downscaling or upscaling if the output rendertarget is smaller/larger than
    /// the input texture</remarks>
    public sealed class ImageCopier : ImageEffect
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageCopier"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ImageCopier(ImageEffectContext context) : base(context, "ImageCopierEffect")
        {
        }

        /// <summary>
        /// Gets or sets the color multiplier. Default is <see cref="SiliconStudio.Core.Mathematics.Color.White"/>
        /// </summary>
        /// <value>The color multiplier.</value>
        public Color4 Color
        {
            get
            {
                return Parameters.Get(ImageCopierShaderKeys.Color);
            }
            set
            {
                Parameters.Set(ImageCopierShaderKeys.Color, value);
            }
        }

        /// <summary>
        /// Copy only the red channel. Default is <c>false</c>
        /// </summary>
        /// <value><c>true</c> if this instance is only channel red; otherwise, <c>false</c>.</value>
        public bool IsOnlyChannelRed
        {
            get
            {
                return !MathUtil.IsZero(Parameters.Get(ImageCopierShaderKeys.IsOnlyChannelRed));
            }
            set
            {
                Parameters.Set(ImageCopierShaderKeys.IsOnlyChannelRed, value ? 1.0f : 0.0f);
            }
        }

        /// <summary>
        /// Gets or sets the sampler used to sample the input texture. Default is <see cref="SamplerStateFactory.LinearClamp"/>
        /// </summary>
        /// <value>The sampler.</value>
        public SamplerState Sampler
        {
            get
            {
                return Parameters.Get(TexturingKeys.Sampler);
            }
            set
            {
                Parameters.Set(TexturingKeys.Sampler, value);
            }
        }

        protected override void SetDefaultParameters()
        {
            base.SetDefaultParameters();
            Color = Color4.White;
            IsOnlyChannelRed = false;
        }
    }
}