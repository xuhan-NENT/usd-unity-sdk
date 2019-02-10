﻿// Copyright 2018 Jeremy Cowles. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using pxr;
using UnityEngine;

namespace USD.NET.Unity {

  public static class HdrpShaderExporter {

    private static string SetupTexture(Scene scene,
                                     string usdShaderPath,
                                     Material material,
                                     PreviewSurfaceSample surface,
                                     string destTexturePath,
                                     string textureName,
                                     string textureOutput) {
#if UNITY_EDITOR
      var srcPath = UnityEditor.AssetDatabase.GetAssetPath(material.GetTexture(textureName));
      srcPath = srcPath.Substring("Assets/".Length);
      srcPath = Application.dataPath + "/" + srcPath;
      var fileName = System.IO.Path.GetFileName(srcPath);
      var filePath = System.IO.Path.Combine(destTexturePath, fileName);
      System.IO.File.Copy(srcPath, filePath, overwrite: true);
#else
      // Not supported at run-time, too many things can go wrong
      // (can't encode compressed textures, etc).
      throw new System.Exception("Not supported at run-time");
#endif
      var uvReader = new PrimvarReaderSample<Vector2>();
      uvReader.varname.defaultValue = new TfToken("uv");
      scene.Write(usdShaderPath + "/uvReader", uvReader);
      var tex = new USD.NET.Unity.TextureReaderSample(filePath, usdShaderPath + "/uvReader.outputs:result");
      scene.Write(usdShaderPath + "/" + textureName, tex);
      return usdShaderPath + "/" + textureName + ".outputs:" + textureOutput;
    }

    public static void ExportLit(Scene scene,
                                 string usdShaderPath,
                                 Material material,
                                 PreviewSurfaceSample surface,
                                 string destTexturePath) {
      Color c;

      if (material.HasProperty("_BaseColorMap") && material.GetTexture("_BaseColorMap") != null) {
        var newTex = SetupTexture(scene, usdShaderPath, material, surface, destTexturePath, "_BaseColorMap", "rgb");
        surface.diffuseColor.SetConnectedPath(newTex);
      } else if (material.HasProperty("_BaseColor")) {
        c = material.GetColor("_BaseColor").linear;
        surface.diffuseColor.defaultValue = new Vector3(c.r, c.g, c.b);
      } else {
        c = Color.white;
        surface.diffuseColor.defaultValue = new Vector3(c.r, c.g, c.b);
      }

      if (material.HasProperty("_BaseColorMap") && material.GetTexture("_BaseColorMap") != null) {
        var newTex = SetupTexture(scene, usdShaderPath, material, surface, destTexturePath, "_BaseColorMap", "a");
        surface.opacity.SetConnectedPath(newTex);
      } else if (material.HasProperty("_BaseColor")) {
        c = material.GetColor("_BaseColor").linear;
        surface.opacity.defaultValue = c.a;
      } else {
        c = Color.white;
        surface.opacity.defaultValue = 1.0f;
      }

      var materialType = (int)material.GetFloat("_MaterialID");
      bool useMetallic = false;
      bool useSpec = false;

      switch (materialType) {
      case 0: // Subsurf, no metallic parameter
        surface.useSpecularWorkflow.defaultValue = 1;
        break;
      case 1: // Standard, metallic + smoothness.
      case 2: // Anisotropy, metallic + smoothness.
      case 3: // Iridescence, metallic + smoothness.
        surface.useSpecularWorkflow.defaultValue = 0;
        useMetallic = true;
        break;
      case 4: // Specular color.
        surface.useSpecularWorkflow.defaultValue = 0;
        useSpec = true;
        break;
      case 5: // Translucent, no metallic.
        surface.useSpecularWorkflow.defaultValue = 0;
        break;
      }

      if (useSpec && material.HasProperty("_SpecularColorMap") && material.GetTexture("_SpecularColorMap") != null) {
        var newTex = SetupTexture(scene, usdShaderPath, material, surface, destTexturePath, "_SpecularColorMap", "rgb");
        surface.specularColor.SetConnectedPath(newTex);
      } else if (useSpec && material.HasProperty("_SpecularColor")) {
        c = material.GetColor("_SpecularColor");
        surface.specularColor.defaultValue = new Vector3(c.r, c.g, c.b);
      } else {
        c = new Color(.5f, .5f, .5f);
        surface.specularColor.defaultValue = new Vector3(c.r, c.g, c.b);
      }

      if (useMetallic && material.HasProperty("_MaskMap") && material.GetTexture("_MaskMap") != null) {
        var newTex = SetupTexture(scene, usdShaderPath, material, surface, destTexturePath, "_MaskMap", "r");
        surface.metallic.SetConnectedPath(newTex);
      } else if (useMetallic && material.HasProperty("_Metallic")) {
        surface.metallic.defaultValue = material.GetFloat("_Metallic");
      } else {
        surface.metallic.defaultValue = 0.5f;
      }

      if (material.HasProperty("_MaskMap") && material.GetTexture("_MaskMap") != null) {
        var newTex = SetupTexture(scene, usdShaderPath, material, surface, destTexturePath, "_MaskMap", "a");
        surface.roughness.SetConnectedPath(newTex);
      } else if (material.HasProperty("_Smoothness")) {
        surface.roughness.defaultValue = 1 - material.GetFloat("_Smoothness");
      } else {
        surface.roughness.defaultValue = 0.5f;
      }

      if (material.HasProperty("_MaskMap") && material.GetTexture("_MaskMap") != null) {
        var newTex = SetupTexture(scene, usdShaderPath, material, surface, destTexturePath, "_MaskMap", "b");
        surface.displacement.SetConnectedPath(newTex);
      }

      if (material.HasProperty("_MaskMap") && material.GetTexture("_MaskMap") != null) {
        var newTex = SetupTexture(scene, usdShaderPath, material, surface, destTexturePath, "_MaskMap", "g");
        surface.occlusion.SetConnectedPath(newTex);
      }

      if (material.HasProperty("_CoatMaskMap") && material.GetTexture("_CoatMaskMap") != null) {
        var newTex = SetupTexture(scene, usdShaderPath, material, surface, destTexturePath, "_CoatMaskMap", "r");
        surface.clearcoat.SetConnectedPath(newTex);
      }

      if (material.HasProperty("_CoatMask")) {
        surface.clearcoatRoughness.defaultValue = material.GetFloat("_CoatMask");
      }

      if (material.HasProperty("_NormalMap") && material.GetTexture("_NormalMap") != null) {
        var newTex = SetupTexture(scene, usdShaderPath, material, surface, destTexturePath, "_NormalMap", "rgb");
        surface.normal.SetConnectedPath(newTex);
      }

      if (material.IsKeywordEnabled("_EMISSIVE_COLOR_MAP")) {
        if (material.HasProperty("_EmissionMap") && material.GetTexture("_EmissionMap") != null) {
          var newTex = SetupTexture(scene, usdShaderPath, material, surface, destTexturePath, "_EmissionMap", "rgb");
          surface.emissiveColor.SetConnectedPath(newTex);
        } else if (material.HasProperty("_EmissionColor")) {
          c = material.GetColor("_EmissionColor").linear;
          surface.emissiveColor.defaultValue = new Vector3(c.r, c.g, c.b);
        }
      }
    }

  }
}
