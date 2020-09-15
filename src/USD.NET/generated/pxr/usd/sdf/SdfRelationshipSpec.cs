//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace pxr {

public class SdfRelationshipSpec : SdfPropertySpec {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal SdfRelationshipSpec(global::System.IntPtr cPtr, bool cMemoryOwn) : base(UsdCsPINVOKE.SdfRelationshipSpec_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SdfRelationshipSpec obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~SdfRelationshipSpec() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          UsdCsPINVOKE.delete_SdfRelationshipSpec(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public static SdfRelationshipSpecHandle New(SdfPrimSpecHandle owner, string name, bool custom, SdfVariability variability) {
    SdfRelationshipSpecHandle ret = new SdfRelationshipSpecHandle(UsdCsPINVOKE.SdfRelationshipSpec_New__SWIG_0(SdfPrimSpecHandle.getCPtr(owner), name, custom, (int)variability), true);
    if (UsdCsPINVOKE.SWIGPendingException.Pending) throw UsdCsPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static SdfRelationshipSpecHandle New(SdfPrimSpecHandle owner, string name, bool custom) {
    SdfRelationshipSpecHandle ret = new SdfRelationshipSpecHandle(UsdCsPINVOKE.SdfRelationshipSpec_New__SWIG_1(SdfPrimSpecHandle.getCPtr(owner), name, custom), true);
    if (UsdCsPINVOKE.SWIGPendingException.Pending) throw UsdCsPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static SdfRelationshipSpecHandle New(SdfPrimSpecHandle owner, string name) {
    SdfRelationshipSpecHandle ret = new SdfRelationshipSpecHandle(UsdCsPINVOKE.SdfRelationshipSpec_New__SWIG_2(SdfPrimSpecHandle.getCPtr(owner), name), true);
    if (UsdCsPINVOKE.SWIGPendingException.Pending) throw UsdCsPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public SWIGTYPE_p_SdfTargetsProxy GetTargetPathList() {
    SWIGTYPE_p_SdfTargetsProxy ret = new SWIGTYPE_p_SdfTargetsProxy(UsdCsPINVOKE.SdfRelationshipSpec_GetTargetPathList(swigCPtr), true);
    return ret;
  }

  public bool HasTargetPathList() {
    bool ret = UsdCsPINVOKE.SdfRelationshipSpec_HasTargetPathList(swigCPtr);
    return ret;
  }

  public void ClearTargetPathList() {
    UsdCsPINVOKE.SdfRelationshipSpec_ClearTargetPathList(swigCPtr);
  }

  public void ReplaceTargetPath(SdfPath oldPath, SdfPath newPath) {
    UsdCsPINVOKE.SdfRelationshipSpec_ReplaceTargetPath(swigCPtr, SdfPath.getCPtr(oldPath), SdfPath.getCPtr(newPath));
    if (UsdCsPINVOKE.SWIGPendingException.Pending) throw UsdCsPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveTargetPath(SdfPath path, bool preserveTargetOrder) {
    UsdCsPINVOKE.SdfRelationshipSpec_RemoveTargetPath__SWIG_0(swigCPtr, SdfPath.getCPtr(path), preserveTargetOrder);
    if (UsdCsPINVOKE.SWIGPendingException.Pending) throw UsdCsPINVOKE.SWIGPendingException.Retrieve();
  }

  public void RemoveTargetPath(SdfPath path) {
    UsdCsPINVOKE.SdfRelationshipSpec_RemoveTargetPath__SWIG_1(swigCPtr, SdfPath.getCPtr(path));
    if (UsdCsPINVOKE.SWIGPendingException.Pending) throw UsdCsPINVOKE.SWIGPendingException.Retrieve();
  }

  public bool GetNoLoadHint() {
    bool ret = UsdCsPINVOKE.SdfRelationshipSpec_GetNoLoadHint(swigCPtr);
    return ret;
  }

  public void SetNoLoadHint(bool noload) {
    UsdCsPINVOKE.SdfRelationshipSpec_SetNoLoadHint(swigCPtr, noload);
  }

}

}
