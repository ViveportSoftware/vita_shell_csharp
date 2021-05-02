using System;
using System.Runtime.InteropServices;
using System.Text;
using Htc.Vita.Core.Util;

namespace Htc.Vita.Shell.Interop
{
    internal static partial class Windows
    {
        internal const string ComInterfaceClsidShellLink = "00021401-0000-0000-c000-000000000046";
        internal const string ComInterfaceIPropertyStore = "886d8eeb-8cf2-4446-8d02-cdba1dbdcf99";
        internal const string ComInterfaceIShellLinkW = "000214f9-0000-0000-c000-000000000046";

        [ComImport]
        [Guid(ComInterfaceClsidShellLink)]
        internal class ClsidShellLink
        {
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid(ComInterfaceIPropertyStore)]
        internal interface IPropertyStore
        {
            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertystore-getcount")]
            [PreserveSig]
            HResult GetCount(
                    /* __RPC__out DWORD* */ [Out] out uint cProps
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertystore-getat")]
            [PreserveSig]
            HResult GetAt(
                    /*            DWORD        */ [In] uint iProp,
                    /* __RPC__out PROPERTYKEY* */ [Out] out PropertyKey pKey
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertystore-getvalue")]
            [PreserveSig]
            HResult GetValue(
                    /* __RPC__in  REFPROPERTYKEY */ [In] ref PropertyKey key,
                    /* __RPC__out PROPVARIANT*   */ [Out] out PropVariant pv
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertystore-setvalue")]
            [PreserveSig]
            HResult SetValue(
                    /* __RPC__in REFPROPERTYKEY */ [In] ref PropertyKey key,
                    /* __RPC__in REFPROPVARIANT */ [In] ref PropVariant propVar
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/propsys/nf-propsys-ipropertystore-commit")]
            [PreserveSig]
            HResult Commit();
        }

        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid(ComInterfaceIShellLinkW)]
        internal interface IShellLinkW
        {
            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-getpath")]
            [PreserveSig]
            HResult GetPath(
                    /* __RPC__out_ecount_full_string LPWSTR            */ [Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile,
                    /*                               int               */ [In] int cch,
                    /* __RPC__inout_opt              WIN32_FIND_DATAW* */ [Out] Win32FindDataW pfd,
                    /*                               DWORD             */ [In] uint fFlags
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-getidlist")]
            [PreserveSig]
            HResult GetIDList(
                    /* __RPC__deref_out_opt PIDLIST_ABSOLUTE* */ [Out] out IntPtr ppidl
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-setidlist")]
            [PreserveSig]
            HResult SetIDList(
                    /* __RPC__in PCIDLIST_ABSOLUTE */ [In] IntPtr pidl
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-getdescription")]
            [PreserveSig]
            HResult GetDescription(
                    /* __RPC__out_ecount_full_string LPSTR */ [Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName,
                    /*                               int   */ [In] int cch
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-setdescription")]
            [PreserveSig]
            HResult SetDescription(
                    /* __RPC__in_string LPCSTR */ [In] string pszName
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-getworkingdirectory")]
            [PreserveSig]
            HResult GetWorkingDirectory(
                    /* __RPC__out_ecount_full_string LPSTR */ [Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir,
                    /*                               int   */ [In] int cch
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-setworkingdirectory")]
            [PreserveSig]
            HResult SetWorkingDirectory(
                    /* __RPC__in_string LPCSTR */ [In] string pszDir
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-getarguments")]
            [PreserveSig]
            HResult GetArguments(
                    /* __RPC__out_ecount_full_string LPSTR */ [Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs,
                    /*                               int   */ [In] int cch
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-setarguments")]
            [PreserveSig]
            HResult SetArguments(
                    /* __RPC__in_string LPCSTR */ [In] string pszArgs
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-gethotkey")]
            [PreserveSig]
            HResult GetHotkey(
                    /* __RPC__out WORD* */ [Out] out ushort pwHotkey
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-sethotkey")]
            [PreserveSig]
            HResult SetHotkey(
                    /* WORD */ [In] ushort wHotkey
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-getshowcmd")]
            [PreserveSig]
            HResult GetShowCmd(
                    /* __RPC__out int* */ [Out] out ShowWindowCommand piShowCmd
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-setshowcmd")]
            [PreserveSig]
            HResult SetShowCmd(
                    /* int */ [In] ShowWindowCommand iShowCmd
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-geticonlocation")]
            [PreserveSig]
            HResult GetIconLocation(
                    /* __RPC__out_ecount_full_string LPWSTR */ [Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath,
                    /*                               int    */ [In] int cch,
                    /* __RPC__out                    int*   */ [Out] int piIcon
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-seticonlocation")]
            [PreserveSig]
            HResult SetIconLocation(
                    /* __RPC__in_string LPCWSTR */ [In] string pszIconPath,
                    /*                  int     */ [In] int iIcon
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-setrelativepath")]
            [PreserveSig]
            HResult SetRelativePath(
                    /* __RPC__in_string LPCWSTR */ [In] string pszPathRel,
                    /*                  DWORD   */ [In] uint dwReserved
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-resolve")]
            [PreserveSig]
            HResult Resolve(
                    /* __RPC__in_opt HWND  */ [In] IntPtr hwnd,
                    /*               DWORD */ [In] uint fFlags
            );

            [ExternalReference("https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelllinkw-setpath")]
            [PreserveSig]
            HResult SetPath(
                    /* __RPC__in_string LPCWSTR */ [In] string pszFile
            );
        }
    }
}
