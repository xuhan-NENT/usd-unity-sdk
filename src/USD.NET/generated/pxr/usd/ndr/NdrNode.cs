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

public class NdrNode : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal NdrNode(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(NdrNode obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~NdrNode() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          UsdCsPINVOKE.delete_NdrNode(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public NdrNode(TfToken identifier, NdrVersion version, string name, TfToken family, TfToken context, TfToken sourceType, string definitionURI, string implementationURI, SWIGTYPE_p_std__vectorT_std__unique_ptrT_NdrProperty_t_t properties, SWIGTYPE_p_std__unordered_mapT_TfToken_std__string_TfToken__HashFunctor_t metadata, string sourceCode) : this(UsdCsPINVOKE.new_NdrNode__SWIG_0(TfToken.getCPtr(identifier), NdrVersion.getCPtr(version), name, TfToken.getCPtr(family), TfToken.getCPtr(context), TfToken.getCPtr(sourceType), definitionURI, implementationURI, SWIGTYPE_p_std__vectorT_std__unique_ptrT_NdrProperty_t_t.getCPtr(properties), SWIGTYPE_p_std__unordered_mapT_TfToken_std__string_TfToken__HashFunctor_t.getCPtr(metadata), sourceCode), true) {
    if (UsdCsPINVOKE.SWIGPendingException.Pending) throw UsdCsPINVOKE.SWIGPendingException.Retrieve();
  }

  public NdrNode(TfToken identifier, NdrVersion version, string name, TfToken family, TfToken context, TfToken sourceType, string definitionURI, string implementationURI, SWIGTYPE_p_std__vectorT_std__unique_ptrT_NdrProperty_t_t properties, SWIGTYPE_p_std__unordered_mapT_TfToken_std__string_TfToken__HashFunctor_t metadata) : this(UsdCsPINVOKE.new_NdrNode__SWIG_1(TfToken.getCPtr(identifier), NdrVersion.getCPtr(version), name, TfToken.getCPtr(family), TfToken.getCPtr(context), TfToken.getCPtr(sourceType), definitionURI, implementationURI, SWIGTYPE_p_std__vectorT_std__unique_ptrT_NdrProperty_t_t.getCPtr(properties), SWIGTYPE_p_std__unordered_mapT_TfToken_std__string_TfToken__HashFunctor_t.getCPtr(metadata)), true) {
    if (UsdCsPINVOKE.SWIGPendingException.Pending) throw UsdCsPINVOKE.SWIGPendingException.Retrieve();
  }

  public NdrNode(TfToken identifier, NdrVersion version, string name, TfToken family, TfToken context, TfToken sourceType, string definitionURI, string implementationURI, SWIGTYPE_p_std__vectorT_std__unique_ptrT_NdrProperty_t_t properties) : this(UsdCsPINVOKE.new_NdrNode__SWIG_2(TfToken.getCPtr(identifier), NdrVersion.getCPtr(version), name, TfToken.getCPtr(family), TfToken.getCPtr(context), TfToken.getCPtr(sourceType), definitionURI, implementationURI, SWIGTYPE_p_std__vectorT_std__unique_ptrT_NdrProperty_t_t.getCPtr(properties)), true) {
    if (UsdCsPINVOKE.SWIGPendingException.Pending) throw UsdCsPINVOKE.SWIGPendingException.Retrieve();
  }

  public TfToken GetIdentifier() {
    TfToken ret = new TfToken(UsdCsPINVOKE.NdrNode_GetIdentifier(swigCPtr), false);
    return ret;
  }

  public NdrVersion GetVersion() {
    NdrVersion ret = new NdrVersion(UsdCsPINVOKE.NdrNode_GetVersion(swigCPtr), true);
    return ret;
  }

  public string GetName() {
    string ret = UsdCsPINVOKE.NdrNode_GetName(swigCPtr);
    return ret;
  }

  public TfToken GetFamily() {
    TfToken ret = new TfToken(UsdCsPINVOKE.NdrNode_GetFamily(swigCPtr), false);
    return ret;
  }

  public TfToken GetContext() {
    TfToken ret = new TfToken(UsdCsPINVOKE.NdrNode_GetContext(swigCPtr), false);
    return ret;
  }

  public TfToken GetSourceType() {
    TfToken ret = new TfToken(UsdCsPINVOKE.NdrNode_GetSourceType(swigCPtr), false);
    return ret;
  }

  public string GetResolvedDefinitionURI() {
    string ret = UsdCsPINVOKE.NdrNode_GetResolvedDefinitionURI(swigCPtr);
    return ret;
  }

  public string GetResolvedImplementationURI() {
    string ret = UsdCsPINVOKE.NdrNode_GetResolvedImplementationURI(swigCPtr);
    return ret;
  }

  public string GetSourceCode() {
    string ret = UsdCsPINVOKE.NdrNode_GetSourceCode(swigCPtr);
    return ret;
  }

  public virtual bool IsValid() {
    bool ret = UsdCsPINVOKE.NdrNode_IsValid(swigCPtr);
    return ret;
  }

  public virtual string GetInfoString() {
    string ret = UsdCsPINVOKE.NdrNode_GetInfoString(swigCPtr);
    return ret;
  }

  public TfTokenVector GetInputNames() {
    TfTokenVector ret = new TfTokenVector(UsdCsPINVOKE.NdrNode_GetInputNames(swigCPtr), false);
    return ret;
  }

  public TfTokenVector GetOutputNames() {
    TfTokenVector ret = new TfTokenVector(UsdCsPINVOKE.NdrNode_GetOutputNames(swigCPtr), false);
    return ret;
  }

  public NdrProperty GetInput(TfToken inputName) {
    global::System.IntPtr cPtr = UsdCsPINVOKE.NdrNode_GetInput(swigCPtr, TfToken.getCPtr(inputName));
    NdrProperty ret = (cPtr == global::System.IntPtr.Zero) ? null : new NdrProperty(cPtr, false);
    if (UsdCsPINVOKE.SWIGPendingException.Pending) throw UsdCsPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public NdrProperty GetOutput(TfToken outputName) {
    global::System.IntPtr cPtr = UsdCsPINVOKE.NdrNode_GetOutput(swigCPtr, TfToken.getCPtr(outputName));
    NdrProperty ret = (cPtr == global::System.IntPtr.Zero) ? null : new NdrProperty(cPtr, false);
    if (UsdCsPINVOKE.SWIGPendingException.Pending) throw UsdCsPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public SWIGTYPE_p_std__unordered_mapT_TfToken_std__string_TfToken__HashFunctor_t GetMetadata() {
    SWIGTYPE_p_std__unordered_mapT_TfToken_std__string_TfToken__HashFunctor_t ret = new SWIGTYPE_p_std__unordered_mapT_TfToken_std__string_TfToken__HashFunctor_t(UsdCsPINVOKE.NdrNode_GetMetadata(swigCPtr), false);
    return ret;
  }

}

}
