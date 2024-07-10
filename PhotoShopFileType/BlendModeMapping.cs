/////////////////////////////////////////////////////////////////////////////////
//
// Photoshop PSD FileType Plugin for Paint.NET
//
// This software is provided under the MIT License:
//   Copyright (c) 2006-2007 Frank Blumenberg
//   Copyright (c) 2010-2014 Tao Yue
//
// See LICENSE.txt for complete licensing and attribution information.
//
/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using PaintDotNet;
using PhotoshopFile;

namespace PaintDotNet.Data.PhotoshopFileType
{
  public static class BlendModeMapping
  {
    /// <summary>
    /// Convert between Paint.NET and Photoshop blend modes.
    /// </summary>
    public static string ToPsdBlendMode(this LayerBlendMode pdnBlendMode)
    {
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
=======
>>>>>>> origin/master
      switch (pdnBlendMode)
      {
        case LayerBlendMode.Normal:
          return PsdBlendMode.Normal;

        case LayerBlendMode.Multiply:
          return PsdBlendMode.Multiply;
        case LayerBlendMode.Additive:
          return PsdBlendMode.LinearDodge;
        case LayerBlendMode.ColorBurn:
          return PsdBlendMode.ColorBurn;
        case LayerBlendMode.ColorDodge:
          return PsdBlendMode.ColorDodge;
        case LayerBlendMode.Overlay:
          return PsdBlendMode.Overlay;
        case LayerBlendMode.Difference:
          return PsdBlendMode.Difference;
        case LayerBlendMode.Lighten:
          return PsdBlendMode.Lighten;
        case LayerBlendMode.Darken:
          return PsdBlendMode.Darken;
        case LayerBlendMode.Screen:
          return PsdBlendMode.Screen;

        // Paint.NET blend modes without a Photoshop equivalent are saved
        // as Normal.
        case LayerBlendMode.Glow:
        case LayerBlendMode.Negation:
        case LayerBlendMode.Reflect:
        case LayerBlendMode.Xor:
          return PsdBlendMode.Normal;

        default:
          Debug.Fail("Unknown Paint.NET blend mode.");
          return PsdBlendMode.Normal;
      }
<<<<<<< HEAD
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
>>>>>>> origin/master
    }

    /// <summary>
    /// Convert a Photoshop blend mode to a Paint.NET BlendOp.
    /// </summary>
    public static LayerBlendMode FromPsdBlendMode(string blendModeKey)
    {
      switch (blendModeKey)
      {
        case PsdBlendMode.Normal:
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          return LayerBlendMode.Normal;
#pragma warning restore CA1416 // プラットフォームの互換性を検証

        case PsdBlendMode.Multiply:
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          return LayerBlendMode.Multiply;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
        case PsdBlendMode.LinearDodge:
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          return LayerBlendMode.Additive;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
        case PsdBlendMode.ColorBurn:
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          return LayerBlendMode.ColorBurn;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
        case PsdBlendMode.ColorDodge:
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          return LayerBlendMode.ColorDodge;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
        case PsdBlendMode.Overlay:
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          return LayerBlendMode.Overlay;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
        case PsdBlendMode.Difference:
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          return LayerBlendMode.Difference;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
        case PsdBlendMode.Lighten:
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          return LayerBlendMode.Lighten;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
        case PsdBlendMode.Darken:
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          return LayerBlendMode.Darken;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
        case PsdBlendMode.Screen:
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          return LayerBlendMode.Screen;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
          return LayerBlendMode.Normal;

        case PsdBlendMode.Multiply:
          return LayerBlendMode.Multiply;
        case PsdBlendMode.LinearDodge:
          return LayerBlendMode.Additive;
        case PsdBlendMode.ColorBurn:
          return LayerBlendMode.ColorBurn;
        case PsdBlendMode.ColorDodge:
          return LayerBlendMode.ColorDodge;
        case PsdBlendMode.Overlay:
          return LayerBlendMode.Overlay;
        case PsdBlendMode.Difference:
          return LayerBlendMode.Difference;
        case PsdBlendMode.Lighten:
          return LayerBlendMode.Lighten;
        case PsdBlendMode.Darken:
          return LayerBlendMode.Darken;
        case PsdBlendMode.Screen:
          return LayerBlendMode.Screen;
>>>>>>> origin/master

        // Photoshop blend modes without a Paint.NET equivalent are loaded
        // as Normal.
        default:
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          return LayerBlendMode.Normal;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
          return LayerBlendMode.Normal;
>>>>>>> origin/master
      }
    }

  }
}
