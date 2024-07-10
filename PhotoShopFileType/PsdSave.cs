/////////////////////////////////////////////////////////////////////////////////
//
// Photoshop PSD FileType Plugin for Paint.NET
//
// This software is provided under the MIT License:
//   Copyright (c) 2006-2007 Frank Blumenberg
//   Copyright (c) 2010-2020 Tao Yue
//
// See LICENSE.txt for complete licensing and attribution information.
//
/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PhotoshopFile;

namespace PaintDotNet.Data.PhotoshopFileType
{
  public static class PsdSave
  {
    public static void Save(Document input, Stream output, PsdSaveConfigToken psdToken,
      Surface scratchSurface, ProgressEventHandler progressCallback)
    {
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      var psdVersion = ((input.Height > 30000) || (input.Width > 30000))
        ? PsdFileVersion.PsbLargeDocument
        : PsdFileVersion.Psd;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
      var psdFile = new PsdFile(psdVersion);

#pragma warning disable CA1416 // プラットフォームの互換性を検証
      psdFile.RowCount = input.Height;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      psdFile.ColumnCount = input.Width;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
      var psdVersion = ((input.Height > 30000) || (input.Width > 30000))
        ? PsdFileVersion.PsbLargeDocument
        : PsdFileVersion.Psd;
      var psdFile = new PsdFile(psdVersion);

      psdFile.RowCount = input.Height;
      psdFile.ColumnCount = input.Width;
>>>>>>> origin/master

      // We only save in RGBA format, 8 bits per channel, which corresponds to
      // Paint.NET's internal representation.

      psdFile.ChannelCount = 4; 
      psdFile.ColorMode = PsdColorMode.RGB;
      psdFile.BitDepth = 8;
      psdFile.Resolution = GetResolutionInfo(input);
      psdFile.ImageCompression = psdToken.RleCompress
        ? ImageCompression.Rle
        : ImageCompression.Raw;

      // Treat the composite image as another layer when reporting progress.
      var progress = new ProgressNotifier(progressCallback);
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      var percentPerLayer = percentStoreImages
        / (input.Layers.Count + 1);
#pragma warning restore CA1416 // プラットフォームの互換性を検証

      // Render the composite image.  This operation is parallelized within
      // Paint.NET using its own private thread pool.
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      using (var ra = new RenderArgs(scratchSurface))
      {
#pragma warning disable CA1416 // プラットフォームの互換性を検証
        input.Flatten(scratchSurface);
#pragma warning restore CA1416 // プラットフォームの互換性を検証
        progress.Notify(percentRenderComposite);
      }
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
      var percentPerLayer = percentStoreImages
        / (input.Layers.Count + 1);

      // Render the composite image.  This operation is parallelized within
      // Paint.NET using its own private thread pool.
      using (var ra = new RenderArgs(scratchSurface))
      {
        input.Flatten(scratchSurface);
        progress.Notify(percentRenderComposite);
      }
>>>>>>> origin/master

      // Delegate to store the composite
      Action storeCompositeAction = () =>
      {
        // Allocate space for the composite image data
        int imageSize = psdFile.RowCount * psdFile.ColumnCount;
        for (short i = 0; i < psdFile.ChannelCount; i++)
        {
          var channel = new Channel(i, psdFile.BaseLayer);
          channel.ImageData = new byte[imageSize];
          channel.ImageCompression = psdFile.ImageCompression;
          psdFile.BaseLayer.Channels.Add(channel);
        }

        var channelsArray = psdFile.BaseLayer.Channels.ToIdArray();
        StoreLayerImage(channelsArray, channelsArray[3],
          scratchSurface, psdFile.BaseLayer.Rect);

        progress.Notify(percentPerLayer);
      };

      // Delegate to store the layers
      Action storeLayersAction = () =>
      {
        // LayerList is an ArrayList, so we have to cast to get a generic
        // IEnumerable that works with LINQ.
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
        var pdnLayers = input.Layers.Cast<BitmapLayer>();
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
=======
        var pdnLayers = input.Layers.Cast<BitmapLayer>();
>>>>>>> origin/master
        var psdLayers = pdnLayers.AsParallel().AsOrdered().Select(pdnLayer =>
        {
          var psdLayer = new PhotoshopFile.Layer(psdFile);
          StoreLayer(pdnLayer, psdLayer, psdToken);

          progress.Notify(percentPerLayer);
          return psdLayer;
        });
<<<<<<< HEAD
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
>>>>>>> origin/master
        psdFile.Layers.AddRange(psdLayers);
      };

      // Process composite and layers in parallel
      Parallel.Invoke(storeCompositeAction, storeLayersAction);

      psdFile.Save(output, Encoding.Default);
    }

    private static ResolutionInfo GetResolutionInfo(Document input)
    {
      var resInfo = new ResolutionInfo();

      resInfo.HeightDisplayUnit = ResolutionInfo.Unit.Inches;
      resInfo.WidthDisplayUnit = ResolutionInfo.Unit.Inches;

<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
=======
>>>>>>> origin/master
      if (input.DpuUnit == MeasurementUnit.Inch)
      {
        resInfo.HResDisplayUnit = ResolutionInfo.ResUnit.PxPerInch;
        resInfo.VResDisplayUnit = ResolutionInfo.ResUnit.PxPerInch;

<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
        resInfo.HDpi = new UFixed16_16(input.DpuX);
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
        resInfo.VDpi = new UFixed16_16(input.DpuY);
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
        resInfo.HDpi = new UFixed16_16(input.DpuX);
        resInfo.VDpi = new UFixed16_16(input.DpuY);
>>>>>>> origin/master
      }
      else
      {
        resInfo.HResDisplayUnit = ResolutionInfo.ResUnit.PxPerCm;
        resInfo.VResDisplayUnit = ResolutionInfo.ResUnit.PxPerCm;

        // Always stored as pixels/inch even if the display unit is
        // pixels/centimeter.
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
        resInfo.HDpi = new UFixed16_16(input.DpuX * 2.54);
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
        resInfo.VDpi = new UFixed16_16(input.DpuY * 2.54);
#pragma warning restore CA1416 // プラットフォームの互換性を検証
      }
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
        resInfo.HDpi = new UFixed16_16(input.DpuX * 2.54);
        resInfo.VDpi = new UFixed16_16(input.DpuY * 2.54);
      }
>>>>>>> origin/master

      return resInfo;
    }

    /// <summary>
    /// Determine the real size of the layer, i.e., the smallest rectangle
    /// that includes all non-transparent pixels.
    /// </summary>
    private static Rectangle FindImageRectangle(Surface surface)
    {
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
=======
>>>>>>> origin/master
      var rectPos = new Util.RectanglePosition
      {
        Left = surface.Width,
        Top = surface.Height,
        Right = 0,
        Bottom = 0
      };
<<<<<<< HEAD
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
>>>>>>> origin/master

      unsafe
      {
        // Search for top non-transparent pixel
        bool fPixelFound = false;
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
        for (int y = 0; y < surface.Height; y++)
        {
#pragma warning disable CA1416 // プラットフォームの互換性を検証
=======
        for (int y = 0; y < surface.Height; y++)
        {
>>>>>>> origin/master
          if (ExpandImageRectangle(surface, y, 0, surface.Width, ref rectPos))
          {
            fPixelFound = true;
            break;
          }
<<<<<<< HEAD
#pragma warning restore CA1416 // プラットフォームの互換性を検証
        }
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
        }
>>>>>>> origin/master

        // Narrow down the other dimensions of the image rectangle
        if (fPixelFound)
        {
          // Search for bottom non-transparent pixel
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          for (int y = surface.Height - 1; y > rectPos.Bottom; y--)
          {
#pragma warning disable CA1416 // プラットフォームの互換性を検証
=======
          for (int y = surface.Height - 1; y > rectPos.Bottom; y--)
          {
>>>>>>> origin/master
            if (ExpandImageRectangle(surface, y, 0, surface.Width, ref rectPos))
            {
              break;
            }
<<<<<<< HEAD
#pragma warning restore CA1416 // プラットフォームの互換性を検証
          }
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
          }
>>>>>>> origin/master

          // Search for left and right non-transparent pixels.  Because we
          // scan horizontally, we can't just break, but we can examine fewer
          // candidate pixels on the remaining rows.
          for (int y = rectPos.Top + 1; y < rectPos.Bottom; y++)
          {
            ExpandImageRectangle(surface, y, 0, rectPos.Left, ref rectPos);
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
            ExpandImageRectangle(surface, y, rectPos.Right + 1, surface.Width, ref rectPos);
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
            ExpandImageRectangle(surface, y, rectPos.Right + 1, surface.Width, ref rectPos);
>>>>>>> origin/master
          }
        }
        else
        {
          rectPos.Left = 0;
          rectPos.Top = 0;
        }

      }

      Debug.Assert(rectPos.Left <= rectPos.Right);
      Debug.Assert(rectPos.Top <= rectPos.Bottom);

      var result = new Rectangle(rectPos.Left, rectPos.Top,
        rectPos.Right - rectPos.Left + 1, rectPos.Bottom - rectPos.Top + 1);
      return result;
    }

    /// <summary>
    /// Check for non-transparent pixels in a row, or portion of a row.
    /// Expands the size of the image rectangle if any were found.
    /// </summary>
    /// <returns>True if non-transparent pixels were found, false otherwise.</returns>
    unsafe private static bool ExpandImageRectangle(Surface surface, int y,
      int xStart, int xEnd, ref Util.RectanglePosition rectPos)
    {
      bool fPixelFound = false;

<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      ColorBgra* rowStart = surface.GetRowPointer(y);
#pragma warning restore CA1416 // プラットフォームの互換性を検証
      ColorBgra* pixel = rowStart + xStart;
      for (int x = xStart; x < xEnd; x++)
      {
#pragma warning disable CA1416 // プラットフォームの互換性を検証
=======
      ColorBgra* rowStart = surface.GetRowAddress(y);
      ColorBgra* pixel = rowStart + xStart;
      for (int x = xStart; x < xEnd; x++)
      {
>>>>>>> origin/master
        if (pixel->A > 0)
        {
          // Expand the rectangle to include the specified point.  
          if (x < rectPos.Left)
          {
            rectPos.Left = x;
          }
          if (x > rectPos.Right)
          {
            rectPos.Right = x;
          }
          if (y < rectPos.Top)
          {
            rectPos.Top = y;
          }
          if (y > rectPos.Bottom)
          {
            rectPos.Bottom = y;
          }
          fPixelFound = true;
        }
<<<<<<< HEAD
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
>>>>>>> origin/master
        pixel++;
      }

      return fPixelFound;
    }

    /// <summary>
    /// Store layer metadata and image data.
    /// </summary>
    public static void StoreLayer(BitmapLayer layer,
      PhotoshopFile.Layer psdLayer, PsdSaveConfigToken psdToken)
    {
      // Set layer metadata
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      psdLayer.Name = layer.Name;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      psdLayer.Rect = FindImageRectangle(layer.Surface);
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      psdLayer.BlendModeKey = layer.BlendMode.ToPsdBlendMode();
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      psdLayer.Opacity = layer.Opacity;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
=======
      psdLayer.Name = layer.Name;
      psdLayer.Rect = FindImageRectangle(layer.Surface);
      psdLayer.BlendModeKey = layer.BlendMode.ToPsdBlendMode();
      psdLayer.Opacity = layer.Opacity;
>>>>>>> origin/master
      psdLayer.Visible = layer.Visible;
      psdLayer.Masks = new MaskInfo();
      psdLayer.BlendingRangesData = new BlendingRanges(psdLayer);

      // Store channel metadata
      int layerSize = psdLayer.Rect.Width * psdLayer.Rect.Height;
      for (int i = -1; i < 3; i++)
      {
        var ch = new Channel((short)i, psdLayer);
        ch.ImageCompression = psdToken.RleCompress ? ImageCompression.Rle : ImageCompression.Raw;
        ch.ImageData = new byte[layerSize];
        psdLayer.Channels.Add(ch);
      }

      // Store and compress channel image data
      var channelsArray = psdLayer.Channels.ToIdArray();
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
      StoreLayerImage(channelsArray, psdLayer.AlphaChannel, layer.Surface, psdLayer.Rect);
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
=======
      StoreLayerImage(channelsArray, psdLayer.AlphaChannel, layer.Surface, psdLayer.Rect);
>>>>>>> origin/master
    }

    /// <summary>
    /// Stores and compresses the image data for the layer.
    /// </summary>
    /// <param name="channels">Destination channels.</param>
    /// <param name="alphaChannel">Destination alpha channel.</param>
    /// <param name="surface">Source image from Paint.NET.</param>
    /// <param name="rect">Image rectangle to store.</param>
    unsafe private static void StoreLayerImage(Channel[] channels, Channel alphaChannel,
      Surface surface, Rectangle rect)
    {
      for (int y = 0; y < rect.Height; y++)
      {
        int destRowIndex = y * rect.Width;
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
        ColorBgra* srcRow = surface.GetRowPointer(y + rect.Top);
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
        ColorBgra* srcRow = surface.GetRowAddress(y + rect.Top);
>>>>>>> origin/master
        ColorBgra* srcPixel = srcRow + rect.Left;

        for (int x = 0; x < rect.Width; x++)
        {
          int destIndex = destRowIndex + x;

<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          channels[0].ImageData[destIndex] = srcPixel->R;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          channels[1].ImageData[destIndex] = srcPixel->G;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          channels[2].ImageData[destIndex] = srcPixel->B;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          alphaChannel.ImageData[destIndex] = srcPixel->A;
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
          channels[0].ImageData[destIndex] = srcPixel->R;
          channels[1].ImageData[destIndex] = srcPixel->G;
          channels[2].ImageData[destIndex] = srcPixel->B;
          alphaChannel.ImageData[destIndex] = srcPixel->A;
>>>>>>> origin/master
          srcPixel++;
        }
      }

      Parallel.ForEach(channels, channel =>
        channel.CompressImageData()
      );
    }

    #region Progress notification

    // We only report progress to 90%, reserving 10% for writing out to disk.
    private static double percentRenderComposite = 20.0;
    private static double percentStoreImages = 70.0;

    private class ProgressNotifier
    {
      private ProgressEventHandler callback;
      private double percent;

      internal ProgressNotifier(ProgressEventHandler progressCallback)
      {
        callback = progressCallback;
        percent = 0;
      }

      internal void Notify(double percentIncrement)
      {
        lock (this)
        {
          percent += percentIncrement;
<<<<<<< HEAD
#pragma warning disable CA1416 // プラットフォームの互換性を検証
#pragma warning disable CA1416 // プラットフォームの互換性を検証
          callback.Invoke(null, new ProgressEventArgs(percent));
#pragma warning restore CA1416 // プラットフォームの互換性を検証
#pragma warning restore CA1416 // プラットフォームの互換性を検証
=======
          callback.Invoke(null, new ProgressEventArgs(percent));
>>>>>>> origin/master
        }
      }
    }

    #endregion
  }

}
