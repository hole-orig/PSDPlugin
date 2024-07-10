﻿/////////////////////////////////////////////////////////////////////////////////
//
// Photoshop PSD FileType Plugin for Paint.NET
//
// This software is provided under the MIT License:
//   Copyright (c) 2006-2007 Frank Blumenberg
//   Copyright (c) 2010-2012 Tao Yue
//
// See LICENSE.txt for complete licensing and attribution information.
//
/////////////////////////////////////////////////////////////////////////////////

using System;

using PaintDotNet;

namespace PaintDotNet.Data.PhotoshopFileType
{
  [Serializable]
  public class PsdSaveConfigToken
      : SaveConfigToken
  {
    public override object Clone()
    {
      return new PsdSaveConfigToken(this);
    }

    public bool RleCompress { get; set; }

    public PsdSaveConfigToken(bool rleCompress)
    {
      this.RleCompress = rleCompress;
    }

    protected PsdSaveConfigToken(PsdSaveConfigToken copyMe)
    {
      this.RleCompress = copyMe.RleCompress;
    }

    public override void Validate()
    {
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      base.Validate();
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
      base.Validate();
>>>>>>> origin/master
    }

  }
}
