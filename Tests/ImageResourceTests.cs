/////////////////////////////////////////////////////////////////////////////////
//
// Photoshop PSD FileType Plugin for Paint.NET
//
// This software is provided under the MIT License:
//   Copyright (c) 2006-2007 Frank Blumenberg
//   Copyright (c) 2010-2013 Tao Yue
//
// See LICENSE.txt for complete licensing and attribution information.
//
/////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace PhotoshopFile.Tests
{
  [TestFixture]
  public class ImageResourceTests
  {
    [Test]
    public void ImageResourceGetSetTest()
    {
      var psdFile = new PsdFile();
      var resources = psdFile.ImageResources;

      var versionInfo1 = new VersionInfo();
      versionInfo1.Name = "VersionInfo1";
      var resolutionInfo1 = new ResolutionInfo();
      resolutionInfo1.Name = "ResolutionInfo1";
      var versionInfo2 = new VersionInfo();
      versionInfo2.Name = "VersionInfo2";

      resources.Add(versionInfo1);
      resources.Add(resolutionInfo1);
      resources.Add(versionInfo2);

      // Can retrieve an item successfully
      var gottenResolutionInfo = resources.Get(ResourceID.ResolutionInfo);
      ClassicAssert.AreEqual(resolutionInfo1.Name, gottenResolutionInfo.Name);
      var gottenThumbnail = resources.Get(ResourceID.ThumbnailRgb);
      ClassicAssert.IsNull(gottenThumbnail);

      // Set to add item.
      var thumbnail = new Thumbnail(ResourceID.ThumbnailRgb, "Thumbnail");
      resources.Set(thumbnail);
      gottenThumbnail = resources.Get(ResourceID.ThumbnailRgb);
      ClassicAssert.AreEqual(thumbnail.Name, gottenThumbnail.Name);

      // Set to change item in-place.
      var idxResolutionInfo = resources.IndexOf(resolutionInfo1);
      var resolutionInfo2 = new ResolutionInfo();
      resolutionInfo2.Name = "ResolutionInfo2";
      resources.Set(resolutionInfo2);
      gottenResolutionInfo = resources.Get(ResourceID.ResolutionInfo);
      ClassicAssert.AreEqual(resolutionInfo2.Name, gottenResolutionInfo.Name);
      
      // Change item that appears twice.
      var count = resources.Count;
      var idxVersionInfo1 = resources.IndexOf(versionInfo1);
      var versionInfo3 = new VersionInfo();
      versionInfo3.Name = "VersionInfo3";
      resources.Set(versionInfo3);

      var gottenVersionInfo = resources.Get(ResourceID.VersionInfo);
      var idxVersionInfo3 = resources.IndexOf(versionInfo3);
      var versionInfoCount = resources.Count(x => x.ID == ResourceID.VersionInfo);
      ClassicAssert.AreEqual(count - 1, resources.Count);
      ClassicAssert.AreEqual(idxVersionInfo1, idxVersionInfo3);
      ClassicAssert.AreEqual(versionInfo3.Name, gottenVersionInfo.Name);
      ClassicAssert.AreEqual(versionInfoCount, 1);

    }
  }
}
