// Copyright 2022 Niantic, Inc. All Rights Reserved.

using System;
using System.Collections.Generic;

using Niantic.ARDK.AR.Awareness.Depth.Generators;
using Niantic.ARDK.AR.ReferenceImage;
using Niantic.ARDK.AR.SLAM;
using Niantic.ARDK.Utilities.Collections;

namespace Niantic.ARDK.AR.Configuration
{
  public interface IARWorldTrackingConfiguration:
    IARConfiguration
  {
    /// A value specifying how and whether the session will detect real-world surfaces.
    /// @note Defaults to PlaneDetection.None.
    PlaneDetection PlaneDetection { get; set; }

    /// Used to get or set the reference images to detect when running this configuration.
    /// @note Not supported in Editor.
    IReadOnlyCollection<IARReferenceImage> DetectionImages { get; set; }

    /// A value specifying whether the camera should use autofocus or not when running.
    bool IsAutoFocusEnabled { get; set; }

    /// A boolean specifying whether the session will generate the necessary data to enable peer-to-peer AR experiences.
    /// Defaults to false
    bool IsSharedExperienceEnabled { get; set; }

    /// A boolean specifying whether or not depths are enabled.
    bool IsDepthEnabled { get; set; }

    /// A boolean specifying whether or not depth point cloud generation are enabled.
    bool IsDepthPointCloudEnabled { get; set; }

    /// A value specifying how many times the depth generation routine
    /// should target running per second.
    UInt32 DepthTargetFrameRate { get; set; }

    /// A boolean specifying whether or not semantic segmentation is enabled.
    bool IsSemanticSegmentationEnabled { get; set; }

    /// A value specifying how many times the semantic segmentation routine
    /// should target running per second.
    UInt32 SemanticTargetFrameRate { get; set; }

    /// A boolean specifying whether or not meshing is enabled.
    bool IsMeshingEnabled { get; set; }

    /// A value specifying how many times the meshing routine
    /// should target running per second.
    UInt32 MeshingTargetFrameRate { get; set; }

    /// A value specifying the radius in meters of the meshed area around the player. The minimum value is 5 meters.
    /// The default value is 0, meaning that there is no limitations while the mesh grows forever.
    float MeshingRadius { get; set; }

    /// A value specifying the target size of a mesh block in meters.
    float MeshingTargetBlockSize { get; set; }

    /// A boolean specifying whether or not palms are detected.
    /// @note This is an experimental feature. Experimental features should not be used in
    /// production products as they are subject to breaking changes, not officially supported, and
    /// may be deprecated without notice
    bool IsPalmDetectionEnabled { get; set; }

    /// <summary>
    /// Set the detection images for this configuration asynchronously. The provided callback will
    ///   be called upon completion.
    /// </summary>
    void SetDetectionImagesAsync
    (
      IReadOnlyCollection<IARReferenceImage> detectionImages,
      Action completionHandler
    );
  }
}
