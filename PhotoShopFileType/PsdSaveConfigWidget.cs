﻿/////////////////////////////////////////////////////////////////////////////////
//
// Photoshop PSD FileType Plugin for Paint.NET
//
// This software is provided under the MIT License:
//   Copyright (c) 2006-2007 Frank Blumenberg
//   Copyright (c) 2010-2017 Tao Yue
//
// See LICENSE.txt for complete licensing and attribution information.
//
/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

using PaintDotNet;

namespace PaintDotNet.Data.PhotoshopFileType
{
  /// <summary>
  /// Summary description for TgaSaveConfigWidget.
  /// </summary>
  public class PsdSaveConfigWidget 
      : PaintDotNet.SaveConfigWidget
  {
    private System.Windows.Forms.CheckBox rleCompressCheckBox;

    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public PsdSaveConfigWidget()
    {
      // This call is required by the Windows.Forms Form Designer.
      InitializeComponent();

      //this.bpp24Radio.Text = PdnResources.GetString("TgaSaveConfigWidget.Bpp24Radio.Text");
      //this.bpp32Radio.Text = PdnResources.GetString("TgaSaveConfigWidget.Bpp32Radio.Text");
      //this.bppLabel.Text = PdnResources.GetString("TgaSaveConfigWidget.BppLabel.Text");
      //this.rleCompressCheckBox.Text = PdnResources.GetString("TgaSaveConfigWidget.RleCompressCheckBox.Text");
    }

    protected override void InitFileType()
    {
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
        this.fileType = new PhotoshopFileType();
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
        this.fileType = new PhotoshopFileType();
>>>>>>> origin/master
    }

    protected override void InitTokenFromWidget()
    {
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      ((PsdSaveConfigToken)this.token).RleCompress = this.rleCompressCheckBox.Checked;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
      ((PsdSaveConfigToken)this.token).RleCompress = this.rleCompressCheckBox.Checked;
>>>>>>> origin/master
    }

    protected override void InitWidgetFromToken(SaveConfigToken token)
    {
      if (token is PsdSaveConfigToken psdToken)
      {
        this.rleCompressCheckBox.Checked = psdToken.RleCompress;
      }
      else
      {
        this.rleCompressCheckBox.Checked = true;
      }
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }
      }

<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      base.Dispose(disposing);
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
      base.Dispose(disposing);
>>>>>>> origin/master
    }

    #region Component Designer generated code
    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.rleCompressCheckBox = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // rleCompressCheckBox
      // 
      this.rleCompressCheckBox.Location = new System.Drawing.Point(0, 0);
      this.rleCompressCheckBox.Name = "rleCompressCheckBox";
      this.rleCompressCheckBox.Size = new System.Drawing.Size(184, 24);
      this.rleCompressCheckBox.TabIndex = 0;
      this.rleCompressCheckBox.Text = PsdPluginResources.GetString("SaveDialog_RleCompression");
      this.rleCompressCheckBox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
      // 
      // PsdSaveConfigWidget
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.Controls.Add(this.rleCompressCheckBox);
      this.Name = "PsdSaveConfigWidget";
      this.Size = new System.Drawing.Size(180, 104);
      this.ResumeLayout(false);

    }
    #endregion

    private void OnCheckedChanged(object sender, System.EventArgs e)
    {
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
        this.UpdateToken();
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
        this.UpdateToken();
>>>>>>> origin/master
    }
  }
}
